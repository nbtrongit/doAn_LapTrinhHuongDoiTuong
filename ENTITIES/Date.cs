using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES
{
    public class Date
    {
        public int Ngay { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }
        public void PhanGiai(string chuoiNgay)
        {
            string[] chuoi = chuoiNgay.Split("/");
            this.Ngay = int.Parse(chuoi[0]);
            this.Thang = int.Parse(chuoi[1]);
            this.Nam = int.Parse(chuoi[2]);
        }
        public int ChuyenDoi()
        {
            return this.Ngay * 10000 + this.Thang * 100 + this.Ngay;
        }
    }
}
