using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrazabilidadAPI.Domain.Entities
{
    public class UserRole
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public required User User { get; set; }
        public int RoleID { get; set; }
        public required Role Role { get; set; }
    }

}
