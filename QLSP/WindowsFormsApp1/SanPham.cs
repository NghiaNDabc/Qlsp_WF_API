using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class SanPham
    {
        public int MaSP { get; set; }

        //[StringLength(50)]
        public string TenSanPham { get; set; }

        public double? DonGia { get; set; }

        public double? SoLuongBan { get; set; }

        public double? TienBan { get; set; }
    }
}
