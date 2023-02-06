using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ENTITIES;

namespace SERVICES
{
    public class XuLyLoaiHang
    {
        public bool themLoaiHang(string loaiHang)
        {
            if (loaiHang == null)
            {
                return false;
            }
            LuuTruLoaiHang luulh = new LuuTruLoaiHang();
            List<string> dsLoaiHang = luulh.Doc();
            foreach (string lh in dsLoaiHang)
            {
                if (lh == loaiHang)
                {
                    return false;
                }
            }
            luulh.luuLoaiHang(loaiHang);
            return true;
        }
        public List<string> timKiem(string tuKhoa)
        {
            if (tuKhoa == null)
            {
                tuKhoa = string.Empty;
            }
            LuuTruLoaiHang luulh = new LuuTruLoaiHang();
            List<string> dsLoaiHang = luulh.Doc();
            List<string> ketQua = new List<string>();
            foreach (string lh in dsLoaiHang)
            {
                if (lh.Contains(tuKhoa))
                {
                    ketQua.Add(lh);
                }
            }
            return ketQua;
        }
        public bool suaLoaiHang(string tuKhoaCu, string tuKhoaMoi)
        {
            LuuTruLoaiHang luulh = new LuuTruLoaiHang();
            List<string> dsLoaiHang = luulh.Doc();
            foreach (string lh in dsLoaiHang)
            {
                if (lh == tuKhoaMoi && lh != tuKhoaCu)
                {
                    return false;
                }
            }
            for (int i = 0; i < dsLoaiHang.Count; i++)
            {
                if (dsLoaiHang[i] == tuKhoaCu)
                {
                    dsLoaiHang[i] = tuKhoaMoi;
                }
            }
            luulh.Luu(dsLoaiHang);
            LuuTruMatHang luumh = new LuuTruMatHang();
            List<MatHang> dsMatHang = luumh.Doc();
            for (int i = 0; i < dsMatHang.Count; i++)
            {
                if (dsMatHang[i].loaiHang == tuKhoaCu)
                {
                    MatHang mh = dsMatHang[i];
                    mh.loaiHang = tuKhoaMoi;
                    dsMatHang[i] = mh;
                }
            }
            luumh.Luu(dsMatHang);
            return true;
        }
        public bool xoaLoaiHang(string tuKhoa)
        {
            if (tuKhoa == null)
            {
                return false;
            }
            LuuTruMatHang luumh = new LuuTruMatHang();
            List<MatHang> dsMatHang = luumh.Doc();
            LuuTruHoaDonBan luuhdb = new LuuTruHoaDonBan();
            List<HoaDonBan> dsHoaDonBan = luuhdb.Doc();
            for (int i = 0; i < dsHoaDonBan.Count; i++)
            {
                for (int j = 0; j < dsMatHang.Count; j++)
                {
                    if ((dsHoaDonBan[i].maHang == dsMatHang[j].maHang) && (dsMatHang[j].loaiHang == tuKhoa))
                    {
                        return false;
                    }
                }
            }
            for (int i = 0; i < dsMatHang.Count; i++)
            {
                if (dsMatHang[i].loaiHang == tuKhoa)
                {
                    dsMatHang.Remove(dsMatHang[i]);
                }
            }
            luumh.Luu(dsMatHang);
            LuuTruLoaiHang luulh = new LuuTruLoaiHang();
            List<string> dsLoaiHang = luulh.Doc();
            foreach (string lh in dsLoaiHang)
            {
                if (lh == tuKhoa)
                {
                    dsLoaiHang.Remove(tuKhoa);
                    luulh.Luu(dsLoaiHang);
                    return true;
                }
            }
            return false;
        }
        public List<string> thongKe(List<MatHang> dsMatHang)
        {
            List<string> dsLoaiHang = new List<string>();
            for (int i = 0; i < dsMatHang.Count; i++)
            {
                bool a = true;
                foreach (string lh in dsLoaiHang)
                {
                    if (dsMatHang[i].loaiHang == lh)
                    {
                        a = false;
                    }
                }
                if (a)
                {
                    dsLoaiHang.Add(dsMatHang[i].loaiHang);
                }
            }
            return dsLoaiHang;
        }
    }
}
