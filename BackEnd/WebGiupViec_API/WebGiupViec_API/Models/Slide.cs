using System;
using System.Collections.Generic;

#nullable disable

namespace WebGiupViec_API.Models
{
    public partial class Slide
    {
        public int SlideId { get; set; }
        public string SlideName { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
        public int SortOrder { get; set; }
        public string Mota { get; set; }
        public bool? Status { get; set; }
    }
}
