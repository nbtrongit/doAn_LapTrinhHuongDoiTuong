using System;

namespace ENTITIES
{
    public class MatHang
    {
        public string maHang { get; set; }
        public string tenHang { get; set; }
        public Date hanDung { get; set; }
        public string congTySanXuat { get; set; }
        public Date ngaySanXuat { get; set; }
        public int donGia { get; set; }
        public string loaiHang { get; set; }
        public int ton { get; set; }
        public int check { get; set; }
        public MatHang()
        {
            this.ngaySanXuat = new Date();
            this.hanDung = new Date();
        }
    }
}
