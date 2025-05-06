using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrazabilidadAPI.Domain.Entities
{
    public class Role
    {
        public int RoleID { get; set; }
        public required string RoleName { get; set; }
        public required string Description { get; set; }

        public required ICollection<UserRole> UserRoles { get; set; }
    }

}
