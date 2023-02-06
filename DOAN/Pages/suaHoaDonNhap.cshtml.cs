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
    public class suaHoaDonNhapModel : PageModel
    {
        public HoaDonNhap hoaDonNhap;
        public string ketQua;
        public bool kiemTra;
        [BindProperty(SupportsGet = true)]
        public string id { get; set; }
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
        public void OnGet()
        {
            XuLyHoaDonNhap hdn = new XuLyHoaDonNhap();
            HoaDonNhap n = hdn.timHoaDonNhap(id);
            if (n.check == 1)
            {
                hoaDonNhap = n;
            }
            else
            {
                ketQua = "Không tìm thấy hóa đơn nhập";
            }
            kiemTra = (n.check == 1);
        }
        public void OnPost()
        {
            hoaDonNhap = new HoaDonNhap();
            hoaDonNhap.maHoaDon = maHD;
            hoaDonNhap.ngayHoaDon.PhanGiai(ngayHD);
            hoaDonNhap.maHang = maMH;
            hoaDonNhap.soLuong = soLuong;
            hoaDonNhap.donGia = donGia;
            hoaDonNhap.check = 1;
            XuLyHoaDonNhap hdn = new XuLyHoaDonNhap();
            bool kq = hdn.Sua(id, hoaDonNhap);
            if (kq == true)
            {
                Response.Redirect("/HoaDonNhap");
            }
            else
            {
                ketQua = "Xóa: False";
            }
        }
    }
}
