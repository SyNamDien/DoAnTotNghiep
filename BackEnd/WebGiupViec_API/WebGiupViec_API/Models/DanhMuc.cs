using System;
using System.Collections.Generic;

#nullable disable

namespace WebGiupViec_API.Models
{
    public partial class DanhMuc
    {
        public DanhMuc()
        {
            Jobs = new HashSet<Job>();
        }

        public int MaDm { get; set; }
        public string TenDm { get; set; }
        public string Mota { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
