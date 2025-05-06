using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrazabilidadAPI.Application.DTOs
{
    public record DataSetDTO(
        int DataSetID,
        string DataSetName,
        string ProcedureName,
        DateTime? CreatedDate
        );
}
