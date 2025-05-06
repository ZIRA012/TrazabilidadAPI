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
    public class ProcedureRepository (ApplicationDbContext context): IProcedureRepository
    {

        public async Task<IEnumerable<DataSetDTO>> GetDataSetsByUserIdAsync(int userId)
        {
            var procedures = await context.Procedures
                .Where(p => p.CreatedByUserID == userId || p.LastModifiedUserID == userId)
                .Include(p => p.DataSets)
                .ToListAsync();

            var dtoList = procedures
                .SelectMany(p => p.DataSets!.Select(d => new DataSetDTO(
                    d!.DataSetID!,
                    d.DataSetName,
                    p.ProcedureName,
                    d.CreatedDate
                )))
                .ToList();
            return dtoList;
        }


        public async Task<OpertaionResult> CreateAsync(Procedure procedure)
        {
            await context.Procedures.AddAsync(procedure);
            await context.SaveChangesAsync();
            return new OpertaionResult(true, "Procedure creado exitosamente.");
        }



    }
}
