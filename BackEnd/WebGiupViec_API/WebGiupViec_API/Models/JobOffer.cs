using System;
using System.Collections.Generic;

#nullable disable

namespace WebGiupViec_API.Models
{
    public partial class JobOffer
    {
        public JobOffer()
        {
            JobPayments = new HashSet<JobPayment>();
        }

        public int JobOfferId { get; set; }
        public int JobId { get; set; }
        public int CustomerId { get; set; }
        public int? StaffId { get; set; }
        public int? TrangThaiId { get; set; }
        public string NgayDang { get; set; }
        public string NgayBdlam { get; set; }
        public string Gia { get; set; }
        public string Note { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Job Job { get; set; }
        public virtual staff Staff { get; set; }
        public virtual TrangThai TrangThai { get; set; }
        public virtual ICollection<JobPayment> JobPayments { get; set; }
    }
}
