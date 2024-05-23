using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebGiupViec_API.Models
{
    public partial class JobPayment
    {
        [Key]
        public int JobPaymentId { get; set; }
        public int JobOfferId { get; set; }
        public int PaymentId { get; set; }
        public bool? TrangThai { get; set; }
        public string NgayTt { get; set; }
        public string TongTien { get; set; }
        public string Note { get; set; }

        public virtual JobOffer JobOffer { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
