using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrazabilidadAPI.Domain.Entities
{
    public class DataSet
    {
        public int DataSetID { get; set; }
        public required string DataSetName { get; set; }
        public required string Description { get; set; }

        public int ProcedureID { get; set; }
        public Procedure? Procedure { get; set; }

        public int FieldID { get; set; }
        public Field? Field { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }

}
