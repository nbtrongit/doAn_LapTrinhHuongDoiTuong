using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITIES;
using DAL;

namespace SERVICES
{
    public class XuLyHoaDonNhap
    {
        public List<HoaDonNhap> timKiem(string tuKhoa)
        {
            if (tuKhoa == null)
            {
                tuKhoa = string.Empty;
            }
            LuuTruHoaDonNhap luuhdn = new LuuTruHoaDonNhap();
            List<HoaDonNhap> dsHoaDonNhap = luuhdn.Doc();
            List<HoaDonNhap> ketQua = new List<HoaDonNhap>();
            foreach (HoaDonNhap hdn in dsHoaDonNhap)
            {
                if (hdn.maHoaDon.Contains(tuKhoa) || hdn.maHang.Contains(tuKhoa))
                {
                    ketQua.Add(hdn);
                }
            }
            return ketQua;
        }
        public bool themHoaDonNhap(HoaDonNhap hoaDonNhap)
        {
            DateTime ngayHienTai = DateTime.Now.Date;
            LuuTruHoaDonNhap luuhdn = new LuuTruHoaDonNhap();
            List<HoaDonNhap> dsHoaDonNhap = luuhdn.Doc();
            foreach (HoaDonNhap hd in dsHoaDonNhap)
            {
                if (hd.maHang == hoaDonNhap.maHang)
                {
                    return false;
                }
                if (hd.maHoaDon == hoaDonNhap.maHoaDon)
                {
                    if ((hoaDonNhap.ngayHoaDon.Ngay != hd.ngayHoaDon.Ngay) || (hoaDonNhap.ngayHoaDon.Thang != hd.ngayHoaDon.Thang) || (hoaDonNhap.ngayHoaDon.Nam != hd.ngayHoaDon.Nam))
                    {
                        return false;
                    }
                }
            }
            if ((ngayHienTai.Year * 10000 + ngayHienTai.Month * 100 + ngayHienTai.Day) < hoaDonNhap.ngayHoaDon.ChuyenDoi())
            {
                return false;
            }
            if (hoaDonNhap.soLuong == 0 || hoaDonNhap.donGia == 0)
            {
                return false;
            }
            luuhdn.luuHoaDonNhap(hoaDonNhap);
            return true;
        }
        public int tongNhapTheoMatHang(string maMH)
        {
            int tong = 0;
            LuuTruHoaDonNhap luuhdn = new LuuTruHoaDonNhap();
            List<HoaDonNhap> dsHoaDonNhap = luuhdn.Doc();
            foreach (HoaDonNhap hd in dsHoaDonNhap)
            {
                if (hd.maHang == maMH)
                {
                    tong += hd.soLuong;
                }
            }
            return tong;
        }
        public HoaDonNhap timHoaDonNhap(string id)
        {
            HoaDonNhap n = new HoaDonNhap();
            if (string.IsNullOrEmpty(id))
            {
                return n;
            }
            LuuTruHoaDonNhap luuhdn = new LuuTruHoaDonNhap();
            List<HoaDonNhap> dsHoaDonNhap = luuhdn.Doc();
            foreach (HoaDonNhap hd in dsHoaDonNhap)
            {
                if (hd.maHang == id)
                {
                    return hd;
                }
            }
            return n;
        }
        public bool Xoa(string id)
        {
            LuuTruHoaDonNhap luuhdn = new LuuTruHoaDonNhap();
            LuuTruHoaDonBan luuhdb = new LuuTruHoaDonBan();
            LuuTruMatHang luumh = new LuuTruMatHang();
            List<HoaDonNhap> dsHoaDonNhap = luuhdn.Doc();
            List<HoaDonBan> dsHoaDonBan = luuhdb.Doc();
            List<MatHang> dsMatHang = luumh.Doc();
            foreach (HoaDonBan hd in dsHoaDonBan)
            {
                if (hd.maHang == id)
                {
                    return false;
                }
            }
            for (int i = 0; i < dsHoaDonNhap.Count; i++)
            {
                if (dsHoaDonNhap[i].maHang == id)
                {
                    dsHoaDonNhap.Remove(dsHoaDonNhap[i]);
                }
            }
            luuhdn.Luu(dsHoaDonNhap);
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
        public bool Sua(string id, HoaDonNhap hoaDonNhapMoi)
        {
            LuuTruHoaDonNhap luuhdn = new LuuTruHoaDonNhap();
            LuuTruMatHang luumh = new LuuTruMatHang();
            LuuTruHoaDonBan luuhdb = new LuuTruHoaDonBan();
            List<HoaDonNhap> dsHoaDonNhap = luuhdn.Doc();
            List<MatHang> dsMatHang = luumh.Doc();
            List<HoaDonBan> dsHoaDonBan = luuhdb.Doc();
            DateTime ngayHienTai = DateTime.Now.Date;
            for (int i = 0; i < dsHoaDonNhap.Count; i++)
            {
                if (dsHoaDonNhap[i].maHang != id)
                {
                    if (dsHoaDonNhap[i].maHang == hoaDonNhapMoi.maHang)
                    {
                        return false;
                    }
                    else if (dsHoaDonNhap[i].maHoaDon == hoaDonNhapMoi.maHoaDon)
                    {
                        if (hoaDonNhapMoi.ngayHoaDon.Ngay != dsHoaDonNhap[i].ngayHoaDon.Ngay || hoaDonNhapMoi.ngayHoaDon.Thang != dsHoaDonNhap[i].ngayHoaDon.Thang || hoaDonNhapMoi.ngayHoaDon.Nam != dsHoaDonNhap[i].ngayHoaDon.Nam)
                        {
                            return false;
                        }
                    }
                }
            }
            for (int i = 0; i < dsMatHang.Count; i++)
            {
                if (dsMatHang[i].maHang == id)
                {
                    if (hoaDonNhapMoi.ngayHoaDon.ChuyenDoi() >= dsMatHang[i].hanDung.ChuyenDoi() || hoaDonNhapMoi.ngayHoaDon.ChuyenDoi() <= dsMatHang[i].ngaySanXuat.ChuyenDoi())
                    {
                        return false;
                    }
                }
            }
            if (hoaDonNhapMoi.ngayHoaDon.ChuyenDoi() > (ngayHienTai.Year * 10000 + ngayHienTai.Month * 100 + ngayHienTai.Day))
            {
                return false;
            }
            for (int i = 0; i < dsHoaDonBan.Count; i++)
            {
                if (dsHoaDonBan[i].maHang == id)
                {
                    if (hoaDonNhapMoi.ngayHoaDon.ChuyenDoi() > dsHoaDonBan[i].ngayHoaDon.ChuyenDoi())
                    {
                        return false;
                    }
                    else if (hoaDonNhapMoi.donGia >= dsHoaDonBan[i].donGia)
                    {
                        return false;
                    }
                }
            }
            XuLyHoaDonBan hdb = new XuLyHoaDonBan();
            if (hoaDonNhapMoi.donGia == 0 || hoaDonNhapMoi.soLuong < hdb.tongBanTheoMatHang(id))
            {
                return false;
            }

            for (int i = 0; i < dsHoaDonNhap.Count; i++)
            {
                if (dsHoaDonNhap[i].maHang == id)
                {
                    dsHoaDonNhap[i] = hoaDonNhapMoi;
                    break;
                }
            }
            luuhdn.Luu(dsHoaDonNhap);
            for (int i = 0; i < dsMatHang.Count; i++)
            {
                if (dsMatHang[i].maHang == id)
                {
                    MatHang m = dsMatHang[i];
                    m.maHang = hoaDonNhapMoi.maHang;
                    m.donGia = hoaDonNhapMoi.donGia;
                    dsMatHang[i] = m;
                    break;
                }
            }
            luumh.Luu(dsMatHang);
            for (int i = 0; i < dsHoaDonBan.Count; i++)
            {
                if (dsHoaDonBan[i].maHang == id)
                {
                    HoaDonBan hd = dsHoaDonBan[i];
                    hd.maHang = hoaDonNhapMoi.maHang;
                    dsHoaDonBan[i] = hd;
                    break;
                }
            }
            luuhdb.Luu(dsHoaDonBan);
            return true;
        }
    }
}
