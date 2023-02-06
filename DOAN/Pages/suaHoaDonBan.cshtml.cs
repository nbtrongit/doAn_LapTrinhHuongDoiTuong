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
    public class suaHoaDonBanModel : PageModel
    {
        public HoaDonBan hoaDonBan;
        public string ketQua;
        public bool kiemTra;
        [BindProperty(SupportsGet = true)]
        public string id1 { get; set; }
        [BindProperty(SupportsGet = true)]
        public string id2 { get; set; }
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
            XuLyHoaDonBan hdb = new XuLyHoaDonBan();
            HoaDonBan b = hdb.timHoaDonBan(id1, id2);
            if (b.check == 1)
            {
                hoaDonBan = b;
            }
            else
            {
                ketQua = "Không tìm thấy hóa đơn bán";
            }
            kiemTra = (b.check == 1);
        }
        public void OnPost()
        {
            hoaDonBan = new HoaDonBan();
            hoaDonBan.maHoaDon = maHD;
            hoaDonBan.ngayHoaDon.PhanGiai(ngayHD);
            hoaDonBan.maHang = maMH;
            hoaDonBan.soLuong = soLuong;
            hoaDonBan.donGia = donGia;
            hoaDonBan.check = 1;
            XuLyHoaDonBan hdb = new XuLyHoaDonBan();
            bool kq = hdb.Sua(id1, id2, hoaDonBan);
            if (kq == true)
            {
                Response.Redirect("/HoaDonBan");
            }
            else
            {
                ketQua = "Xóa: False";
            }
        }
    }
}
