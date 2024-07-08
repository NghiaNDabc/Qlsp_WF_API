namespace webAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSP { get; set; }

        [StringLength(50)]
        public string TenSanPham { get; set; }

        public double? DonGia { get; set; }

        public double? SoLuongBan { get; set; }

        public double? TienBan { get; set; }
    }
}
