using TrazabilidadAPI.Application.DTOs;
using TrazabilidadAPI.Domain.Entities;
using TrazabilidadAPI.SharedLibraries.OperationResults;

namespace TrazabilidadAPI.Application.Interfaces
{
    public interface IProcedureRepository
    {
        Task<OpertaionResult> CreateAsync(Procedure procedure);

        Task<IEnumerable<DataSetDTO>> GetDataSetsByUserIdAsync(int userId);
    }

}
