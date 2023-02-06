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
    public class xoaHoaDonNhapModel : PageModel
    {
        public HoaDonNhap hoaDonNhap;
        public string ketQua;
        public bool kiemTra;
        [BindProperty(SupportsGet = true)]
        public string id { get; set; }
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
            XuLyHoaDonNhap hdn = new XuLyHoaDonNhap();
            bool kq = hdn.Xoa(id);
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
