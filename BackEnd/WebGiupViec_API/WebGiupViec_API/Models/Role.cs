using System;
using System.Collections.Generic;

#nullable disable

namespace WebGiupViec_API.Models
{
    public partial class Role
    {
        public Role()
        {
            Customers = new HashSet<Customer>();
            staff = new HashSet<staff>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Mota { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<staff> staff { get; set; }
    }
}
