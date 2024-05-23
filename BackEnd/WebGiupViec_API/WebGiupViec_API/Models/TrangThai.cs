using System;
using System.Collections.Generic;

#nullable disable

namespace WebGiupViec_API.Models
{
    public partial class TrangThai
    {
        public TrangThai()
        {
            JobOffers = new HashSet<JobOffer>();
        }

        public int TrangThaiId { get; set; }
        public string TrangThaiName { get; set; }
        public string Mota { get; set; }

        public virtual ICollection<JobOffer> JobOffers { get; set; }
    }
}
