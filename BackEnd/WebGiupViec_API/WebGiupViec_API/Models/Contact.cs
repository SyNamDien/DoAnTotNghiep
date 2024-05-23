using System;
using System.Collections.Generic;

#nullable disable

namespace WebGiupViec_API.Models
{
    public partial class Contact
    {
        public int ContactId { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int SortOrder { get; set; }
        public string Mota { get; set; }
    }
}
