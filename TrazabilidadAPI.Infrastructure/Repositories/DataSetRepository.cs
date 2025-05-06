using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrazabilidadAPI.Application.DTOs;
using TrazabilidadAPI.Application.Interfaces;
using TrazabilidadAPI.Domain.Entities;
using TrazabilidadAPI.Infrastructure.Data;
using TrazabilidadAPI.SharedLibraries.OperationResults;

namespace TrazabilidadAPI.Infrastructure.Repositories
{
    public class DataSetRepository(ApplicationDbContext context): IDataSetRepository
    {
        public async Task<OpertaionResult> CreateAsync(CreateDataSetDTO dto)
        {
            var procedureExists = await context.Procedures.AnyAsync(p => p.ProcedureID == dto.ProcedureID);
            if (!procedureExists)
                return new OpertaionResult(false, "El Procedure no existe.");

            var fieldExists = await context.Fields.AnyAsync(f => f.FieldID == dto.FieldID);
            if (!fieldExists)
                return new OpertaionResult(false, "El Field no existe.");

            var newDataSet = new DataSet
            {
                DataSetName = dto.DataSetName,
                Description = dto.Description,
                ProcedureID = dto.ProcedureID,
                FieldID = dto.FieldID,
                CreatedDate = DateTime.UtcNow,
                LastModifiedDate = null
            };

            context.DataSets.Add(newDataSet);
            await context.SaveChangesAsync();

            return new OpertaionResult(true, "DataSet creado correctamente.");
        }

        public async Task<IEnumerable<DataSetWithFieldDTO>> GetByProcedureIdWithFieldAsync(int procedureId)
        {
            var dataSets = await context.DataSets
                .Where(ds => ds.ProcedureID == procedureId)
                .Include(ds => ds.Field)
                .Select(ds => new DataSetWithFieldDTO(
                    ds.DataSetID,
                    ds.DataSetName,
                    ds.Description,
                    ds.Field!.FieldName,
                    ds.Field.DataType
                ))
                .ToListAsync();

            return dataSets;
        }



    }
}
