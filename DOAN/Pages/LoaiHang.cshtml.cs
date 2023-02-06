using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SERVICES;

namespace DOAN.Pages
{
    public class LoaiHangModel : PageModel
    {
        public List<string> dsLoaiHang;
        [BindProperty]
        public string tuKhoa { get; set; }
        [BindProperty]
        public string tuKhoaMoi { get; set; }
        [BindProperty]
        public string suKien { get; set; }
        public string ketQua;
        public void OnGet()
        {
            XuLyLoaiHang lh = new XuLyLoaiHang();
            dsLoaiHang = lh.timKiem(tuKhoa);
            ketQua = string.Empty;
            suKien = string.Empty;
        }
        public void OnPost()
        {
            XuLyLoaiHang lh = new XuLyLoaiHang();
            if (suKien == "Tìm Kiếm")
            {
                dsLoaiHang = lh.timKiem(tuKhoa);
            }
            else if (suKien == "Thêm")
            {
                ketQua = $"Thêm: {lh.themLoaiHang(tuKhoa)}";
                dsLoaiHang = lh.timKiem(string.Empty);
            }
            else if (suKien == "Sửa")
            {
                dsLoaiHang = lh.timKiem(string.Empty);
                foreach (string l in dsLoaiHang)
                {
                    if (l == tuKhoa)
                    {
                        suKien = "True";
                        break;
                    }
                }
                if (suKien != "True")
                {
                    ketQua = "Sửa: False";
                }
            }
            else if (suKien == "Thay Đổi")
            {
                ketQua = $"Sửa: {lh.suaLoaiHang(tuKhoa, tuKhoaMoi)}";
                dsLoaiHang = lh.timKiem(string.Empty);
            }
            else if (suKien == "Xóa")
            {
                ketQua = $"Xóa: {lh.xoaLoaiHang(tuKhoa)}";
                dsLoaiHang = lh.timKiem(string.Empty);
            }
        }
    }
}
