using System;
using System.Collections.Generic;
using System.IO;
using ENTITIES;
using Newtonsoft.Json;

namespace DAL
{
    public class LuuTruMatHang
    {
        public bool Luu(List<MatHang> dsMatHang)
        {
            StreamWriter file = new StreamWriter("./mathang.json");
            string json = JsonConvert.SerializeObject(dsMatHang);
            file.Write(json);
            file.Close();
            return true;
        }
        public List<MatHang> Doc()
        {
            var dsMatHang = new List<MatHang>();
            StreamReader file = new StreamReader("./mathang.json");
            string json = file.ReadToEnd();
            file.Close();
            dsMatHang = JsonConvert.DeserializeObject<List<MatHang>>(json);
            return dsMatHang;
        }
        public void luuMatHang(MatHang matHang)
        {
            List<MatHang> dsMatHang = Doc();
            dsMatHang.Add(matHang);
            Luu(dsMatHang);
        }
    }
}
