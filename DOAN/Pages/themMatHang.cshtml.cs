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
    public class themMatHangModel : PageModel
    {
        public List<HoaDonNhap> dsHoaDonNhap;
        public List<MatHang> dsMatHang;
        public List<string> dsLoaiHang;
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
        public string loaiHang { get; set; }
        public MatHang matHang;
        public string ketQua;
        public void OnGet()
        {
            XuLyHoaDonNhap hdn = new XuLyHoaDonNhap();
            XuLyMatHang mh = new XuLyMatHang();
            XuLyLoaiHang lh = new XuLyLoaiHang();
            dsHoaDonNhap = hdn.timKiem(string.Empty);
            dsMatHang = mh.timKiem(string.Empty);
            dsLoaiHang = lh.timKiem(string.Empty);
            for (int i = 0; i < dsHoaDonNhap.Count; i++)
            {
                for (int j = 0; j < dsMatHang.Count; j++)
                {
                    if (dsHoaDonNhap[i].maHang == dsMatHang[j].maHang)
                    {
                        dsHoaDonNhap.RemoveAt(i);
                    }
                }
            }
            ketQua = string.Empty;
        }
        public void OnPost()
        {
            XuLyHoaDonNhap hdn = new XuLyHoaDonNhap();
            XuLyMatHang mh = new XuLyMatHang();
            XuLyLoaiHang lh = new XuLyLoaiHang();
            dsHoaDonNhap = hdn.timKiem(string.Empty);
            dsMatHang = mh.timKiem(string.Empty);
            dsLoaiHang = lh.timKiem(string.Empty);
            for (int i = 0; i < dsHoaDonNhap.Count; i++)
            {
                for (int j = 0; j < dsMatHang.Count; j++)
                {
                    if (dsHoaDonNhap[i].maHang == dsMatHang[j].maHang)
                    {
                        dsHoaDonNhap.RemoveAt(i);
                    }
                }
            }
            matHang = new MatHang();
            matHang.maHang = maHang;
            matHang.tenHang = tenMH;
            matHang.hanDung.PhanGiai(hanDung);
            matHang.congTySanXuat = congtySX;
            matHang.ngaySanXuat.PhanGiai(ngaySX);
            matHang.check = 1;
            foreach (HoaDonNhap hd in dsHoaDonNhap)
            {
                if (hd.maHang == matHang.maHang)
                {
                    matHang.donGia = hd.donGia;
                }
            }
            matHang.loaiHang = loaiHang;
            matHang.ton = 0;
            bool kq = mh.themMatHang(matHang);
            if (kq)
            {
                Response.Redirect("/MatHang");
            }
            else
            {
                ketQua = $"Thêm: {kq}";
            }
        }
    }
}
