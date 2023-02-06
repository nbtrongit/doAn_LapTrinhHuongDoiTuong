using System;
using System.Collections.Generic;
using ENTITIES;
using DAL;

namespace SERVICES
{
    public class XuLyMatHang
    {
        public List<MatHang> timKiem(string tuKhoa)
        {
            LuuTruMatHang luumh = new LuuTruMatHang();
            if (tuKhoa == null)
            {
                tuKhoa = string.Empty;
            }
            List<MatHang> dsLoaiHang = luumh.Doc();
            List<MatHang> ketQua = new List<MatHang>();
            foreach (MatHang mh in dsLoaiHang)
            {
                if (mh.maHang.Contains(tuKhoa) || mh.tenHang.Contains(tuKhoa) || mh.loaiHang.Contains(tuKhoa) || mh.congTySanXuat.Contains(tuKhoa))
                {
                    ketQua.Add(mh);
                }
            }
            return ketQua;
        }
        public bool themMatHang(MatHang matHang)
        {
            LuuTruHoaDonNhap luuhdn = new LuuTruHoaDonNhap();
            List<HoaDonNhap> dsHoaDonNhap = luuhdn.Doc();
            foreach (HoaDonNhap hdn in dsHoaDonNhap)
            {
                if (hdn.maHang == matHang.maHang)
                {
                    if (matHang.ngaySanXuat.ChuyenDoi() >= hdn.ngayHoaDon.ChuyenDoi())
                    {
                        return false;
                    }
                    else if (matHang.hanDung.ChuyenDoi() <= hdn.ngayHoaDon.ChuyenDoi())
                    {
                        return false;
                    }
                    else if (matHang.hanDung.ChuyenDoi() <= matHang.ngaySanXuat.ChuyenDoi())
                    {
                        return false;
                    }
                }
            }
            LuuTruMatHang luumh = new LuuTruMatHang();
            luumh.luuMatHang(matHang);
            return true;
        }
        public MatHang timMatHang(string id)
        {
            MatHang m = new MatHang();
            if (string.IsNullOrEmpty(id))
            {
                return m;
            }
            LuuTruMatHang luumh = new LuuTruMatHang();
            List<MatHang> dsMatHang = luumh.Doc();
            foreach (MatHang mh in dsMatHang)
            {
                if (mh.maHang == id)
                {
                    return mh;
                }
            }
            return m;
        }
        public bool Xoa(string id)
        {
            LuuTruHoaDonBan luuhdb = new LuuTruHoaDonBan();
            List<HoaDonBan> dsHoaDonBan = luuhdb.Doc();
            LuuTruMatHang luumh = new LuuTruMatHang();
            List<MatHang> dsMatHang = luumh.Doc();
            foreach (HoaDonBan hd in dsHoaDonBan)
            {
                if (hd.maHang == id)
                {
                    return false;
                }
            }
            for (int i = 0; i < dsMatHang.Count; i++)
            {
                if (dsMatHang[i].maHang == id)
                {
                    dsMatHang.Remove(dsMatHang[i]);
                }
            }
            luumh.Luu(dsMatHang);
            return true;
        }
        public bool Sua(string id, MatHang matHangMoi)
        {
            LuuTruHoaDonBan luuhdb = new LuuTruHoaDonBan();
            LuuTruHoaDonNhap luuhdn = new LuuTruHoaDonNhap();
            LuuTruMatHang luumh = new LuuTruMatHang();
            LuuTruLoaiHang luulh = new LuuTruLoaiHang();
            List<HoaDonBan> dsHoaDonBan = luuhdb.Doc();
            List<HoaDonNhap> dsHoaDonNhap = luuhdn.Doc();
            List<MatHang> dsMatHang = luumh.Doc();
            List<string> dsLoaiHang = luulh.Doc();
            MatHang matHang = dsMatHang[0];
            foreach (MatHang m in dsMatHang)
            {
                if (m.maHang == id)
                {
                    matHang = m;
                    break;
                }
            }
            HoaDonNhap hoaDonNhap = dsHoaDonNhap[0];
            bool a = false;
            foreach (HoaDonNhap hd in dsHoaDonNhap)
            {
                if (hd.maHang != id)
                {
                    if (hd.maHang == matHangMoi.maHang)
                    {
                        hoaDonNhap = hd;
                        a = true;
                        break;
                    }
                }
            }
            if (a)
            {
                for (int i = 0; i < dsMatHang.Count; i++)
                {
                    if (dsMatHang[i].maHang != id && dsMatHang[i].maHang == matHangMoi.maHang)
                    {
                        return false;
                    }
                }
                for (int i = 0; i < dsHoaDonNhap.Count; i++)
                {
                    XuLyHoaDonBan hdb = new XuLyHoaDonBan();
                    if (dsHoaDonNhap[i].maHang == matHangMoi.maHang)
                    {
                        if (matHangMoi.hanDung.ChuyenDoi() <= dsHoaDonNhap[i].ngayHoaDon.ChuyenDoi() || matHangMoi.ngaySanXuat.ChuyenDoi() >= dsHoaDonNhap[i].ngayHoaDon.ChuyenDoi())
                        {
                            return false;
                        }
                        else if (dsHoaDonNhap[i].soLuong < hdb.tongBanTheoMatHang(id))
                        {
                            return false;
                        }
                    }
                }
                if (matHangMoi.hanDung.ChuyenDoi() <= matHangMoi.ngaySanXuat.ChuyenDoi())
                {
                    return false;
                }
                for (int i = 0; i < dsHoaDonBan.Count; i++)
                {
                    if (dsHoaDonBan[i].maHang == id && matHangMoi.hanDung.ChuyenDoi() <= dsHoaDonBan[i].ngayHoaDon.ChuyenDoi())
                    {
                        return false;
                    }
                    else if (dsHoaDonBan[i].maHang == id && matHangMoi.donGia >= dsHoaDonBan[i].donGia)
                    {
                        return false;
                    }
                }
                if (matHangMoi.donGia == 0)
                {
                    return false;
                }
                for (int i = 0; i < dsLoaiHang.Count; i++)
                {
                    if (dsLoaiHang[i] != matHang.loaiHang && dsLoaiHang[i] == matHangMoi.loaiHang)
                    {
                        return false;
                    }
                }
                for (int i = 0; i < dsMatHang.Count; i++)
                {
                    if (dsMatHang[i].maHang == id)
                    {
                        dsMatHang[i] = matHangMoi;
                    }
                    if (dsMatHang[i].loaiHang == matHang.loaiHang)
                    {
                        MatHang mh = dsMatHang[i];
                        mh.loaiHang = matHangMoi.loaiHang;
                        dsMatHang[i] = mh;
                    }
                }
                luumh.Luu(dsMatHang);
                for (int i = 0; i < dsLoaiHang.Count; i++)
                {
                    if (dsLoaiHang[i] == matHang.loaiHang)
                    {
                        dsLoaiHang[i] = matHangMoi.loaiHang;
                        break;
                    }
                }
                luulh.Luu(dsLoaiHang);
                for (int i = 0; i < dsHoaDonNhap.Count; i++)
                {
                    if (dsHoaDonNhap[i].maHang == id)
                    {
                        HoaDonNhap hdn = dsHoaDonNhap[i];
                        hdn.donGia = matHangMoi.donGia;
                        dsHoaDonNhap[i] = hdn;
                        break;
                    }
                }
                luuhdn.Luu(dsHoaDonNhap);
                for (int i = 0; i < dsHoaDonBan.Count; i++)
                {
                    if (dsHoaDonBan[i].maHang == id)
                    {
                        HoaDonBan hd = dsHoaDonBan[i];
                        hd.maHang = matHangMoi.maHang;
                        dsHoaDonBan[i] = hd;
                    }
                }
                luuhdb.Luu(dsHoaDonBan);
            }
            else
            {
                for (int i = 0; i < dsHoaDonNhap.Count; i++)
                {
                    if (dsHoaDonNhap[i].maHang != id && matHangMoi.maHang == dsHoaDonNhap[i].maHang)
                    {
                        return false;
                    }
                    else if (dsHoaDonNhap[i].maHang == id)
                    {
                        if (matHangMoi.hanDung.ChuyenDoi() <= dsHoaDonNhap[i].ngayHoaDon.ChuyenDoi() || matHangMoi.ngaySanXuat.ChuyenDoi() >= dsHoaDonNhap[i].ngayHoaDon.ChuyenDoi())
                        {
                            return false;
                        }
                    }
                }
                if (matHangMoi.hanDung.ChuyenDoi() <= matHangMoi.ngaySanXuat.ChuyenDoi())
                {
                    return false;
                }
                for (int i = 0; i < dsHoaDonBan.Count; i++)
                {
                    if (dsHoaDonBan[i].maHang == id && matHangMoi.hanDung.ChuyenDoi() <= dsHoaDonBan[i].ngayHoaDon.ChuyenDoi())
                    {
                        return false;
                    }
                    else if (dsHoaDonBan[i].maHang == id && matHangMoi.donGia >= dsHoaDonBan[i].donGia)
                    {
                        return false;
                    }
                }
                if (matHangMoi.donGia == 0)
                {
                    return false;
                }
                for (int i = 0; i < dsLoaiHang.Count; i++)
                {
                    if (dsLoaiHang[i] != matHang.loaiHang && dsLoaiHang[i] == matHangMoi.loaiHang)
                    {
                        return false;
                    }
                }
                for (int i = 0; i < dsMatHang.Count; i++)
                {
                    if (dsMatHang[i].maHang == id)
                    {
                        dsMatHang[i] = matHangMoi;
                    }
                    if (dsMatHang[i].loaiHang == matHang.loaiHang)
                    {
                        MatHang m = dsMatHang[i];
                        m.loaiHang = matHangMoi.loaiHang;
                        dsMatHang[i] = m;
                    }
                }
                luumh.Luu(dsMatHang);
                for (int i = 0; i < dsLoaiHang.Count; i++)
                {
                    if (dsLoaiHang[i] == matHang.loaiHang)
                    {
                        dsLoaiHang[i] = matHangMoi.loaiHang;
                        break;
                    }
                }
                luulh.Luu(dsLoaiHang);
                for (int i = 0; i < dsHoaDonNhap.Count; i++)
                {
                    if (dsHoaDonNhap[i].maHang == id)
                    {
                        HoaDonNhap hd = dsHoaDonNhap[i];
                        hd.maHang = matHangMoi.maHang;
                        hd.donGia = matHangMoi.donGia;
                        dsHoaDonNhap[i] = hd;
                        break;
                    }
                }
                luuhdn.Luu(dsHoaDonNhap);
                for (int i = 0; i < dsHoaDonBan.Count; i++)
                {
                    if (dsHoaDonBan[i].maHang == id)
                    {
                        HoaDonBan hd = dsHoaDonBan[i];
                        hd.maHang = matHangMoi.maHang;
                        dsHoaDonBan[i] = hd;
                    }
                }
                luuhdb.Luu(dsHoaDonBan);
            }
            return true;
        }
        public List<MatHang> hangHetHan(List<MatHang> dsMatHang)
        {
            DateTime ngayHienTai = DateTime.Now.Date;
            for (int i = 0; i < dsMatHang.Count; i++)
            {
                if (dsMatHang[i].hanDung.ChuyenDoi() >= (ngayHienTai.Year * 10000 + ngayHienTai.Month * 100 + ngayHienTai.Day))
                {
                    dsMatHang.Remove(dsMatHang[i]);
                }
            }
            return dsMatHang;
        }
        public List<MatHang> hangTon()
        {
            LuuTruMatHang luumh = new LuuTruMatHang();
            List<MatHang> dsMatHang = luumh.Doc();
            XuLyHoaDonNhap hdn = new XuLyHoaDonNhap();
            XuLyHoaDonBan hdb = new XuLyHoaDonBan();
            for (int i = 0; i < dsMatHang.Count; i++)
            {
                MatHang m = dsMatHang[i];
                m.ton = hdn.tongNhapTheoMatHang(dsMatHang[i].maHang) - hdb.tongBanTheoMatHang(dsMatHang[i].maHang);
                dsMatHang[i] = m;
            }
            return dsMatHang;
        }
    }
}
