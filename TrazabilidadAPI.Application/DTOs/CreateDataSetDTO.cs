using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrazabilidadAPI.Application.DTOs
{
    public record CreateDataSetDTO(
        string DataSetName,
        string Description,
        int ProcedureID,
        int FieldID
        );
}
