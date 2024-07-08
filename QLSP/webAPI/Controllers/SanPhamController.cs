using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webAPI.Models;

namespace webAPI.Controllers
{
    public class SanPhamController : ApiController
    {
        QlspContext db= new QlspContext();
        [HttpGet]
        public List<SanPham> DanhSachSP()
        {
            return db.SanPhams.ToList();
        }
        [HttpPost]
        public IHttpActionResult ThemSP([FromBody] SanPham sp)
        {
            if (DanhSachSP().Any(x => x.MaSP == sp.MaSP)) return BadRequest();

            db.SanPhams.Add(sp);
            db.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult XOASANPHAM(int ma)
        {
            SanPham sp = DanhSachSP().Where(x => x.MaSP == ma).SingleOrDefault();
            if(sp == null) return NotFound();
            db.SanPhams.Remove(sp);
            db.SaveChanges();
            return Ok();
        }

        public IHttpActionResult Put(SanPham sp)
        {
            SanPham a = DanhSachSP().Where(x => x.MaSP == sp.MaSP).SingleOrDefault();

            if(a==null) return NotFound();

            a.MaSP = sp.MaSP;
            a.TenSanPham = sp.TenSanPham;
            a.SoLuongBan = sp.SoLuongBan;
            a.DonGia = sp.DonGia;
            a.TienBan =  sp.TienBan;
            db.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("api/SanPham/DS")]
        public List<SanPham> DS()
        {
            return db.SanPhams.Where(x => x.SoLuongBan == 1).ToList();
        }
        [HttpGet]
        [Route("api/SanPham/DS")]
        public List<SanPham> DS(int ma)
        {
            return db.SanPhams.Where(x => x.MaSP == ma).ToList();
        }
    }
}
