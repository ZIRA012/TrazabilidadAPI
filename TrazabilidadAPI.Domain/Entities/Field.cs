using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrazabilidadAPI.Domain.Entities
{
    public class Field
    {
        public int FieldID { get; set; }
        public required string FieldName { get; set; }
        public required string DataType { get; set; }

        public required ICollection<DataSet> DataSets { get; set; }
    }

}
