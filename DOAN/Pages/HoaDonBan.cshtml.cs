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
    public class HoaDonBanModel : PageModel
    {
        public List<HoaDonBan> dsHoaDonBan;
        [BindProperty]
        public string tuKhoa { get; set; }
        public void OnGet()
        {
            XuLyHoaDonBan hdb = new XuLyHoaDonBan();
            dsHoaDonBan = hdb.timKiem(tuKhoa);
        }
        public void OnPost()
        {
            XuLyHoaDonBan hdb = new XuLyHoaDonBan();
            dsHoaDonBan = hdb.timKiem(tuKhoa);
        }
    }
}
