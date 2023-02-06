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
    public class HoaDonNhapModel : PageModel
    {
        public List<HoaDonNhap> dsHoaDonNhap;
        [BindProperty]
        public string tuKhoa { get; set; }
        public void OnGet()
        {
            XuLyHoaDonNhap hdn = new XuLyHoaDonNhap();
            dsHoaDonNhap = hdn.timKiem(tuKhoa);
        }
        public void OnPost()
        {
            XuLyHoaDonNhap hdn = new XuLyHoaDonNhap();
            dsHoaDonNhap = hdn.timKiem(tuKhoa);
        }
    }
}
