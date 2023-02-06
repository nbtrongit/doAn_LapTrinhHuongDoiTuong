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
    public class themHoaDonNhapModel : PageModel
    {
        [BindProperty]
        public string maHD { get; set; }
        [BindProperty]
        public string ngayHD { get; set; }
        [BindProperty]
        public string maMH { get; set; }
        [BindProperty]
        public int soLuong { get; set; }
        [BindProperty]
        public int donGia { get; set; }
        public HoaDonNhap hoaDonNhap;
        public string ketQua;
        public void OnGet()
        {
            ketQua = string.Empty;
        }
        public void OnPost()
        {
            XuLyHoaDonNhap hdn = new XuLyHoaDonNhap();
            hoaDonNhap = new HoaDonNhap();
            hoaDonNhap.maHoaDon = maHD;
            hoaDonNhap.ngayHoaDon.PhanGiai(ngayHD);
            hoaDonNhap.maHang = maMH;
            hoaDonNhap.soLuong = soLuong;
            hoaDonNhap.donGia = donGia;
            hoaDonNhap.check = 1;
            bool kq = hdn.themHoaDonNhap(hoaDonNhap);
            if (kq)
            {
                Response.Redirect("/HoaDonNhap");
            }
            else
            {
                ketQua = $"Thêm: {kq}";
            }
        }
    }
}
