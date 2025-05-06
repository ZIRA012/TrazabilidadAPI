using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrazabilidadAPI.Application.DTOs
{
    public record CreateProcedureDTO(
    string ProcedureName,
    string Description
);
}
