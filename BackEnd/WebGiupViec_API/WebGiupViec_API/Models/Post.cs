using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebGiupViec_API.Models
{
    public partial class Post
    {
        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }
        public string MoTaNgan { get; set; }
        public string MoTaDai { get; set; }
        public string TacGia { get; set; }
        public string NgayDang { get; set; }
        public bool? TrangThai { get; set; }
        public string Anh { get; set; }
    }
}
