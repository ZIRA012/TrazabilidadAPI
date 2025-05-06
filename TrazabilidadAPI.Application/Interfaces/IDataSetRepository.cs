using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrazabilidadAPI.Application.DTOs;
using TrazabilidadAPI.Domain.Entities;
using TrazabilidadAPI.SharedLibraries.OperationResults;

namespace TrazabilidadAPI.Application.Interfaces
{
    public interface IDataSetRepository
    {
        Task<OpertaionResult> CreateAsync(CreateDataSetDTO dto);
        Task<IEnumerable<DataSetWithFieldDTO>> GetByProcedureIdWithFieldAsync(int procedureId);

    }
}
