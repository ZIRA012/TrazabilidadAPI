using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrazabilidadAPI.Domain.Entities
{
    public class Procedure
    {
        public int ProcedureID { get; set; }
        public required string ProcedureName { get; set; }
        public required string Description { get; set; }

        public int CreatedByUserID { get; set; }
        public User? CreatedByUser { get; set; }

        public int? LastModifiedUserID { get; set; }
        public User? LastModifiedUser { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public  ICollection<DataSet?>? DataSets { get; set; }
    }

}
