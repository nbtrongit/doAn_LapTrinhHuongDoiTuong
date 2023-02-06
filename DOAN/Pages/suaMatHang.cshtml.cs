using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ENTITIES;
using SERVICES;

namespace DOAN.Pages
{
    public class suaMatHangModel : PageModel
    {
        public MatHang matHang;
        public List<string> dsLoaiHang;
        public string ketQua;
        public bool kiemTra;
        [BindProperty(SupportsGet = true)]
        public string id { get; set; }
        [BindProperty]
        public string maHang { get; set; }
        [BindProperty]
        public string tenMH { get; set; }
        [BindProperty]
        public string hanDung { get; set; }
        [BindProperty]
        public string congtySX { get; set; }
        [BindProperty]
        public string ngaySX { get; set; }
        [BindProperty]
        public int donGia { get; set; }
        [BindProperty]
        public string loaiHang { get; set; }
        public void OnGet()
        {
            XuLyLoaiHang lh = new XuLyLoaiHang();
            dsLoaiHang = lh.timKiem(string.Empty);
            XuLyMatHang mh = new XuLyMatHang();
            MatHang m = mh.timMatHang(id);
            if (m.check == 1)
            {
                matHang = m;
            }
            else
            {
                ketQua = "Không tìm thấy mặt hàng";
            }
            kiemTra = (m.check == 1);
        }
        public void OnPost()
        {
            XuLyLoaiHang lh = new XuLyLoaiHang();
            dsLoaiHang = lh.timKiem(string.Empty);
            matHang = new MatHang();
            matHang.maHang = maHang;
            matHang.tenHang = tenMH;
            matHang.hanDung.PhanGiai(hanDung);
            matHang.congTySanXuat = congtySX;
            matHang.ngaySanXuat.PhanGiai(ngaySX);
            matHang.donGia = donGia;
            matHang.loaiHang = loaiHang;
            matHang.check = 1;
            XuLyMatHang mh = new XuLyMatHang();
            bool kq = mh.Sua(id, matHang);
            if (kq == true)
            {
                Response.Redirect("/MatHang");
            }
            else
            {
                ketQua = "Xóa: False";
            }
        }
    }
}
