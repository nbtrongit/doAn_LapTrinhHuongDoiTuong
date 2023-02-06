using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES
{
    public class HoaDonBan
    {
        public string maHoaDon { get; set; }
        public Date ngayHoaDon { get; set; }
        public string maHang { get; set; }
        public int soLuong { get; set; }
        public int donGia { get; set; }
        public int check { get; set; }
        public HoaDonBan()
        {
            this.ngayHoaDon = new Date();
        }
    }
}
