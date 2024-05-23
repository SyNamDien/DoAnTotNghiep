using System;
using System.Collections.Generic;

#nullable disable

namespace WebGiupViec_API.Models
{
    public partial class staff
    {
        public staff()
        {
            JobOffers = new HashSet<JobOffer>();
        }

        public int StaffId { get; set; }
        public string TenNv { get; set; }
        public string Ngaysinh { get; set; }
        public string GioiTinh { get; set; }
        public string Avatar { get; set; }
        public string Diachi { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string NgayVaoCty { get; set; }
        public int? SoCvdaLam { get; set; }
        public int? StaffPoint { get; set; }
        public string DanhGia { get; set; }
        public int? RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<JobOffer> JobOffers { get; set; }
    }
}
