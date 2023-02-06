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
    public class xoaMatHangModel : PageModel
    {
        public MatHang matHang;
        public string ketQua;
        public bool kiemTra;
        [BindProperty(SupportsGet = true)]
        public string id { get; set; }
        public void OnGet()
        {
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
            XuLyMatHang mh = new XuLyMatHang();
            bool kq = mh.Xoa(id);
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
