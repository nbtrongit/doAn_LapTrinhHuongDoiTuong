using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITIES;
using Newtonsoft.Json;

namespace DAL
{
    public class LuuTruHoaDonNhap
    {
        public bool Luu(List<HoaDonNhap> dsHoaDonNhap)
        {
            StreamWriter file = new StreamWriter("./hoadonnhap.json");
            string json = JsonConvert.SerializeObject(dsHoaDonNhap);
            file.Write(json);
            file.Close();
            return true;
        }
        public List<HoaDonNhap> Doc()
        {
            List<HoaDonNhap> dsHoaDonNhap;
            StreamReader file = new StreamReader("./hoadonnhap.json");
            string json = file.ReadToEnd();
            file.Close();
            dsHoaDonNhap = JsonConvert.DeserializeObject<List<HoaDonNhap>>(json);
            return dsHoaDonNhap;
        }
        public void luuHoaDonNhap(HoaDonNhap hoaDonNhap)
        {
            List<HoaDonNhap> dsHoaDonNhap = Doc();
            dsHoaDonNhap.Add(hoaDonNhap);
            Luu(dsHoaDonNhap);
        }
    }
}
