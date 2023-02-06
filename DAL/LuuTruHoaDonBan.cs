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
    public class LuuTruHoaDonBan
    {
        public bool Luu(List<HoaDonBan> dsHoaDonBan)
        {
            StreamWriter file = new StreamWriter("./hoadonban.json");
            string json = JsonConvert.SerializeObject(dsHoaDonBan);
            file.Write(json);
            file.Close();
            return true;
        }
        public List<HoaDonBan> Doc()
        {
            List<HoaDonBan> dsHoaDonBan;
            StreamReader file = new StreamReader("./hoadonban.json");
            string json = file.ReadToEnd();
            file.Close();
            dsHoaDonBan = JsonConvert.DeserializeObject<List<HoaDonBan>>(json);
            return dsHoaDonBan;
        }
        public void luuHoaDonBan(HoaDonBan hoaDonBan)
        {
            List<HoaDonBan> dsHoaDonBan = Doc();
            dsHoaDonBan.Add(hoaDonBan);
            Luu(dsHoaDonBan);
        }
    }
}
