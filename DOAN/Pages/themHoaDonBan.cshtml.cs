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
    public class themHoaDonBanModel : PageModel
    {
        public List<MatHang> dsMatHang;
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
        public string ketQua;
        public HoaDonBan hoaDonBan;
        public void OnGet()
        {
            XuLyMatHang mh = new XuLyMatHang();
            XuLyHoaDonBan hdb = new XuLyHoaDonBan();
            XuLyHoaDonNhap hdn = new XuLyHoaDonNhap();
            dsMatHang = mh.timKiem(string.Empty);
            ketQua = string.Empty;
            for (int i = 0; i < dsMatHang.Count; i++)
            {
                if (hdb.tongBanTheoMatHang(dsMatHang[i].maHang) == hdn.tongNhapTheoMatHang(dsMatHang[i].maHang))
                {
                    dsMatHang.Remove(dsMatHang[i]);
                }
            }
        }
        public void OnPost()
        {
            XuLyMatHang mh = new XuLyMatHang();
            XuLyHoaDonBan hdb = new XuLyHoaDonBan();
            XuLyHoaDonNhap hdn = new XuLyHoaDonNhap();
            dsMatHang = mh.timKiem(string.Empty);
            for (int i = 0; i < dsMatHang.Count; i++)
            {
                if (hdb.tongBanTheoMatHang(dsMatHang[i].maHang) == hdn.tongNhapTheoMatHang(dsMatHang[i].maHang))
                {
                    dsMatHang.Remove(dsMatHang[i]);
                }
            }
            hoaDonBan = new HoaDonBan();
            hoaDonBan.maHoaDon = maHD;
            hoaDonBan.ngayHoaDon.PhanGiai(ngayHD);
            hoaDonBan.maHang = maMH;
            hoaDonBan.soLuong = soLuong;
            hoaDonBan.donGia = donGia;
            hoaDonBan.check = 1;
            bool kq = hdb.themHoaDonBan(hoaDonBan);
            if (kq)
            {
                Response.Redirect("/HoaDonBan");
            }
            else
            {
                ketQua = $"Thêm: {kq}";
            }
        }
    }
}
