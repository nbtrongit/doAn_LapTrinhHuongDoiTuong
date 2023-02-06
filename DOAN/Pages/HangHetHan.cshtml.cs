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
    public class HangHetHanModel : PageModel
    {
        public List<MatHang> dsMatHang;
        public void OnGet()
        {
            XuLyMatHang mh = new XuLyMatHang();
            dsMatHang = mh.hangTon();
            dsMatHang = mh.hangHetHan(dsMatHang);
        }
    }
}
