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
    public class MatHangModel : PageModel
    {
        public List<MatHang> dsMatHang;
        [BindProperty]
        public string tuKhoa { get; set; }
        public void OnGet()
        {
            XuLyMatHang mh = new XuLyMatHang();
            dsMatHang = mh.timKiem(tuKhoa);
        }
        public void OnPost()
        {
            XuLyMatHang mh = new XuLyMatHang();
            dsMatHang = mh.timKiem(tuKhoa);
        }
    }
}
