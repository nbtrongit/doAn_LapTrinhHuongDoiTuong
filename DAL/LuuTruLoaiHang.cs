using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LuuTruLoaiHang
    {
        public bool Luu(List<string> dsLoaiHang)
        {
            StreamWriter file = new StreamWriter("./loaihang.json");
            string json = JsonConvert.SerializeObject(dsLoaiHang);
            file.Write(json);
            file.Close();
            return true;
        }
        public List<string> Doc()
        {
            List<string> dsLoaiHang;
            StreamReader file = new StreamReader("./loaihang.json");
            string json = file.ReadToEnd();
            file.Close();
            dsLoaiHang = JsonConvert.DeserializeObject<List<string>>(json);
            return dsLoaiHang;
        }
        public void luuLoaiHang(string loaiHang)
        {
            List<string> dsLoaiHang = Doc();
            dsLoaiHang.Add(loaiHang);
            Luu(dsLoaiHang);
        }
    }
}
