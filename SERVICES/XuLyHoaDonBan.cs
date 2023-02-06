using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITIES;
using DAL;

namespace SERVICES
{
    public class XuLyHoaDonBan
    {
        public List<HoaDonBan> timKiem(string tuKhoa)
        {
            if (tuKhoa == null)
            {
                tuKhoa = string.Empty;
            }
            LuuTruHoaDonBan luuhdb = new LuuTruHoaDonBan();
            List<HoaDonBan> dsHoaDonBan = luuhdb.Doc();
            List<HoaDonBan> ketQua = new List<HoaDonBan>();
            foreach (HoaDonBan hd in dsHoaDonBan)
            {
                if (hd.maHoaDon.Contains(tuKhoa) || hd.maHang.Contains(tuKhoa))
                {
                    ketQua.Add(hd);
                }
            }
            return ketQua;
        }
        public int tongBanTheoMatHang(string maMH)
        {
            int tong = 0;
            LuuTruHoaDonBan luuhdb = new LuuTruHoaDonBan();
            List<HoaDonBan> dsHoaDonBan = luuhdb.Doc();
            foreach (HoaDonBan hd in dsHoaDonBan)
            {
                if (hd.maHang == maMH)
                {
                    tong += hd.soLuong;
                }
            }
            return tong;
        }
        public bool themHoaDonBan(HoaDonBan hoaDonBan)
        {
            LuuTruHoaDonBan luuhdb = new LuuTruHoaDonBan();
            LuuTruHoaDonNhap luuhdn = new LuuTruHoaDonNhap();
            LuuTruMatHang luumh = new LuuTruMatHang();
            List<HoaDonBan> dsHoaDonBan = luuhdb.Doc();
            List<HoaDonNhap> dsHoaDonNhap = luuhdn.Doc();
            List<MatHang> dsMatHang = luumh.Doc();
            DateTime ngayHienTai = DateTime.Now.Date;
            foreach (HoaDonBan hd in dsHoaDonBan)
            {
                if (hd.maHoaDon == hoaDonBan.maHoaDon)
                {
                    if ((hoaDonBan.ngayHoaDon.Ngay != hd.ngayHoaDon.Ngay) || (hoaDonBan.ngayHoaDon.Thang != hd.ngayHoaDon.Thang) || (hoaDonBan.ngayHoaDon.Nam != hd.ngayHoaDon.Nam))
                    {
                        return false;
                    }
                    else if (hd.maHang == hoaDonBan.maHang)
                    {
                        return false;
                    }
                }
            }
            XuLyHoaDonNhap hdn = new XuLyHoaDonNhap();
            if (hoaDonBan.soLuong + tongBanTheoMatHang(hoaDonBan.maHang) > hdn.tongNhapTheoMatHang(hoaDonBan.maHang))
            {
                return false;
            }
            else if ((ngayHienTai.Year * 10000 + ngayHienTai.Month * 100 + ngayHienTai.Day) < hoaDonBan.ngayHoaDon.ChuyenDoi())
            {
                return false;
            }
            foreach (HoaDonNhap hd in dsHoaDonNhap)
            {
                if (hd.maHang == hoaDonBan.maHang && hoaDonBan.ngayHoaDon.ChuyenDoi() < hd.ngayHoaDon.ChuyenDoi())
                {
                    return false;
                }
                else if (hd.maHang == hoaDonBan.maHang && hoaDonBan.donGia <= hd.donGia)
                {
                    return false;
                }
            }
            foreach (MatHang mh in dsMatHang)
            {
                if (mh.maHang == hoaDonBan.maHang && hoaDonBan.ngayHoaDon.ChuyenDoi() >= mh.hanDung.ChuyenDoi())
                {
                    return false;
                }
            }
            if (hoaDonBan.soLuong == 0 || hoaDonBan.donGia == 0)
            {
                return false;
            }
            luuhdb.luuHoaDonBan(hoaDonBan);
            return true;
        }
        public HoaDonBan timHoaDonBan(string id1, string id2)
        {
            HoaDonBan b = new HoaDonBan();
            if (string.IsNullOrEmpty(id1) || string.IsNullOrEmpty(id2))
            {
                return b;
            }
            LuuTruHoaDonBan luuhdb = new LuuTruHoaDonBan();
            List<HoaDonBan> dsHoaDonBan = luuhdb.Doc();
            foreach (HoaDonBan hd in dsHoaDonBan)
            {
                if (hd.maHoaDon == id1 && hd.maHang == id2)
                {
                    return hd;
                }
            }
            return b;
        }
        public bool Xoa(string id1, string id2)
        {
            LuuTruHoaDonBan luuhdb = new LuuTruHoaDonBan();
            List<HoaDonBan> dsHoaDonBan = luuhdb.Doc();
            for (int i = 0; i < dsHoaDonBan.Count; i++)
            {
                if (dsHoaDonBan[i].maHoaDon == id1 && dsHoaDonBan[i].maHang == id2)
                {
                    dsHoaDonBan.Remove(dsHoaDonBan[i]);
                }
            }
            luuhdb.Luu(dsHoaDonBan);
            return true;
        }
        public bool Sua(string id1, string id2, HoaDonBan hoaDonBanMoi)
        {
            LuuTruHoaDonBan luuhdb = new LuuTruHoaDonBan();
            LuuTruHoaDonNhap luuhdn = new LuuTruHoaDonNhap();
            LuuTruMatHang luumh = new LuuTruMatHang();
            List<HoaDonNhap> dsHoaDonNhap = luuhdn.Doc();
            List<HoaDonBan> dsHoaDonBan = luuhdb.Doc();
            List<MatHang> dsMatHang = luumh.Doc();

            if (hoaDonBanMoi.soLuong == 0)
            {
                return false;
            }
            foreach (HoaDonBan hd in dsHoaDonBan)
            {
                if (hd.maHoaDon != id1 && hd.maHang != id2)
                {
                    if (hd.maHoaDon == hoaDonBanMoi.maHoaDon && hd.maHang == hoaDonBanMoi.maHang)
                    {
                        return false;
                    }
                }
            }
            DateTime ngayHienTai = DateTime.Now.Date;
            if (hoaDonBanMoi.ngayHoaDon.ChuyenDoi() > (ngayHienTai.Year * 10000 + ngayHienTai.Month * 100 + ngayHienTai.Day))
            {
                return false;
            }
            bool a = false;
            foreach (HoaDonNhap hd in dsHoaDonNhap)
            {
                if (hd.maHang != id2 && hoaDonBanMoi.maHang == hd.maHang)
                {
                    a = true;
                }
            }
            if (a)
            {
                HoaDonNhap hdn = dsHoaDonNhap[0];
                for (int i = 0; i < dsHoaDonNhap.Count; i++)
                {
                    if (dsHoaDonNhap[i].maHang == hoaDonBanMoi.maHang)
                    {
                        hdn = dsHoaDonNhap[i];
                        if (dsHoaDonNhap[i].ngayHoaDon.ChuyenDoi() > hoaDonBanMoi.ngayHoaDon.ChuyenDoi())
                        {
                            return false;
                        }
                        else if (dsHoaDonNhap[i].donGia >= hoaDonBanMoi.donGia)
                        {
                            return false;
                        }
                    }
                }
                for (int i = 0; i < dsMatHang.Count; i++)
                {
                    if (dsMatHang[i].maHang == id2)
                    {
                        if (dsMatHang[i].hanDung.ChuyenDoi() <= hoaDonBanMoi.ngayHoaDon.ChuyenDoi())
                        {
                            return false;
                        }
                        else if (dsMatHang[i].hanDung.ChuyenDoi() <= hdn.ngayHoaDon.ChuyenDoi())
                        {
                            return false;
                        }
                        else if (dsMatHang[i].ngaySanXuat.ChuyenDoi() >= hdn.ngayHoaDon.ChuyenDoi())
                        {
                            return false;
                        }
                    }
                }
                XuLyHoaDonNhap hdn1 = new XuLyHoaDonNhap();
                for (int i = 0; i < dsHoaDonBan.Count; i++)
                {
                    if (dsHoaDonBan[i].maHoaDon == id1 && dsHoaDonBan[i].maHang == id2)
                    {
                        if ((hoaDonBanMoi.soLuong + tongBanTheoMatHang(id2) - dsHoaDonBan[i].soLuong) > hdn1.tongNhapTheoMatHang(hoaDonBanMoi.maHang))
                        {
                            return false;
                        }
                    }
                    else if (dsHoaDonBan[i].maHang == id2)
                    {
                        if (dsHoaDonBan[i].maHoaDon == id1 && dsHoaDonBan[i].maHang == id2 && dsHoaDonBan[i].donGia <= hdn.donGia)
                        {
                            return false;
                        }
                    }
                }
                for (int i = 0; i < dsMatHang.Count; i++)
                {
                    if (dsMatHang[i].maHang == id2)
                    {
                        MatHang mh = dsMatHang[i];
                        mh.maHang = hdn.maHang;
                        mh.donGia = hdn.donGia;
                        dsMatHang[i] = mh;
                    }
                }
                luumh.Luu(dsMatHang);
                for (int i = 0; i < dsHoaDonBan.Count; i++)
                {
                    if (dsHoaDonBan[i].maHoaDon == id1 && (dsHoaDonBan[i].maHang == id2 || dsHoaDonBan[i].maHang == hoaDonBanMoi.maHang))
                    {
                        dsHoaDonBan[i] = hoaDonBanMoi;
                    }
                    else if (dsHoaDonBan[i].maHang == id2)
                    {
                        HoaDonBan hdb = dsHoaDonBan[i];
                        hdb.maHang = hoaDonBanMoi.maHang;
                        dsHoaDonBan[i] = hdb;
                    }
                }
                luuhdb.Luu(dsHoaDonBan);
            }
            else
            {
                for (int i = 0; i < dsHoaDonNhap.Count; i++)
                {
                    if (dsHoaDonNhap[i].maHang == id2)
                    {
                        if (dsHoaDonNhap[i].ngayHoaDon.ChuyenDoi() > hoaDonBanMoi.ngayHoaDon.ChuyenDoi())
                        {
                            return false;
                        }
                        else if (hoaDonBanMoi.donGia <= dsHoaDonNhap[i].donGia)
                        {
                            return false;
                        }
                    }
                }
                for (int i = 0; i < dsMatHang.Count; i++)
                {
                    if (dsMatHang[i].maHang == id2 && dsMatHang[i].hanDung.ChuyenDoi() <= hoaDonBanMoi.ngayHoaDon.ChuyenDoi())
                    {
                        return false;
                    }
                }
                XuLyHoaDonNhap hdn = new XuLyHoaDonNhap();
                for (int i = 0; i < dsHoaDonBan.Count; i++)
                {
                    if (dsHoaDonBan[i].maHoaDon == id1 && dsHoaDonBan[i].maHang == id2)
                    {
                        if ((hoaDonBanMoi.soLuong + tongBanTheoMatHang(id2) - dsHoaDonBan[i].soLuong) > hdn.tongNhapTheoMatHang(id2))
                        {
                            return false;
                        }
                    }
                    else if (dsHoaDonBan[i].maHoaDon == hoaDonBanMoi.maHoaDon && dsHoaDonBan[i].maHang != id2)
                    {
                        if (dsHoaDonBan[i].ngayHoaDon.ChuyenDoi() != hoaDonBanMoi.ngayHoaDon.ChuyenDoi())
                        {
                            return false;
                        }
                    }
                }
                for (int i = 0; i < dsHoaDonNhap.Count; i++)
                {
                    if (dsHoaDonNhap[i].maHang == id2)
                    {
                        HoaDonNhap hd = dsHoaDonNhap[i];
                        hd.maHang = hoaDonBanMoi.maHang;
                        dsHoaDonNhap[i] = hd;
                        break;
                    }
                }
                luuhdn.Luu(dsHoaDonNhap);
                for (int i = 0; i < dsMatHang.Count; i++)
                {
                    if (dsMatHang[i].maHang == id2)
                    {
                        MatHang mh = dsMatHang[i];
                        mh.maHang = hoaDonBanMoi.maHang;
                        dsMatHang[i] = mh;
                        break;
                    }
                }
                luumh.Luu(dsMatHang);
                for (int i = 0; i < dsHoaDonBan.Count; i++)
                {
                    if (dsHoaDonBan[i].maHoaDon == id1 && (dsHoaDonBan[i].maHang == id2 || dsHoaDonBan[i].maHang == hoaDonBanMoi.maHang))
                    {
                        dsHoaDonBan[i] = hoaDonBanMoi;
                    }
                    else if (dsHoaDonBan[i].maHang == id2)
                    {
                        HoaDonBan hdb = dsHoaDonBan[i];
                        hdb.maHang = hoaDonBanMoi.maHang;
                        dsHoaDonBan[i] = hdb;
                    }
                }
                luuhdb.Luu(dsHoaDonBan);
            }
            return true;
        }
    }
}
