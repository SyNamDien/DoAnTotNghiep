using System;
using System.Collections.Generic;

#nullable disable

namespace WebGiupViec_API.Models
{
    public partial class Job
    {
        public Job()
        {
            JobOffers = new HashSet<JobOffer>();
        }

        public int JobId { get; set; }
        public int? MaDm { get; set; }
        public string TenCv { get; set; }
        public int GiaGoc { get; set; }
        public int GiaDiscount { get; set; }
        public string CongTy { get; set; }
        public string MoTaNgan { get; set; }
        public string MoTaDai { get; set; }
        public string ThoiGianLam { get; set; }
        public bool? TrangThai { get; set; }

        public virtual DanhMuc MaDmNavigation { get; set; }
        public virtual ICollection<JobOffer> JobOffers { get; set; }
    }
}
