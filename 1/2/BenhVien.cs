using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    class BenhVien
    {
        private DateTime thoiDiem;
        private int soNgayChoNghiCuaThang;
        private decimal luongCoBan;
        private List<KeyValuePair<NhanVien, Luong>> danhSachNhanVien;

        public BenhVien(DateTime thoiDiem, int soNgayChoNghiCuaThang, decimal luongCoBan)
        {
            this.thoiDiem = thoiDiem;
            this.soNgayChoNghiCuaThang = soNgayChoNghiCuaThang;
            this.luongCoBan = luongCoBan;
            danhSachNhanVien = new List<KeyValuePair<NhanVien, Luong>>();
        }

        public void ThemNhanVien(NhanVien nhanVien)
        {
            decimal soLuong = nhanVien.Luong(luongCoBan);
            Luong luong = new Luong(soLuong, nhanVien.TruLuong(soLuong, soNgayChoNghiCuaThang, DateTime.DaysInMonth(thoiDiem.Year, thoiDiem.Month)), nhanVien.TienThuong());

            danhSachNhanVien.Add(new KeyValuePair<NhanVien, Luong>(nhanVien, luong));
        }

        public void InDanhSachNhanVien()
        {
            Console.WriteLine($"Danh sach nhan vien cong ty tai thoi diem: {thoiDiem.ToString("dd/MM/yyyy")}\n");
            foreach (KeyValuePair<NhanVien, Luong> nhanVien in danhSachNhanVien)
            {
                nhanVien.Key.InThongTin();
            }
        }

        public void LuongMotThangCongTyPhaiTra()
        {
            decimal luong = 0;
            foreach (KeyValuePair<NhanVien, Luong> nhanVien in danhSachNhanVien)
            {
                luong = luong + nhanVien.Value.tienLuong;
            }
            Console.WriteLine($"\nLuong thang {thoiDiem.ToString("MM")} cong ty phai tra la: " + string.Format("{0:N0}", luong) + " VND\n");
        }

        public void NhanVienGioiNhat()
        {
            danhSachNhanVien.Sort((a, b) => b.Value.tienThuong.CompareTo(a.Value.tienThuong));
            Console.WriteLine("\n\nDanh sach 3 nhan vien la viec gioi nhat:\n");
            for (int i = 0; i < 3 && i < danhSachNhanVien.Count; i++)
            {
                danhSachNhanVien[i].Key.InThongTin();
                Console.WriteLine("Luong: " + string.Format("{0:N0}", danhSachNhanVien[i].Value.luong) + " VND");
                Console.WriteLine("Tien thuong: " + string.Format("{0:N0}", danhSachNhanVien[i].Value.tienThuong) + " VND");
                Console.WriteLine("Tru luong: " + string.Format("{0:N0}", danhSachNhanVien[i].Value.truLuong) + " VND");
                Console.WriteLine("Tien luong nhan duoc: " + string.Format("{0:N0}", danhSachNhanVien[i].Value.tienLuong) + " VND\n");
                Console.WriteLine();
            }
        }

        private struct Luong
        {
            public decimal luong;
            public decimal tienThuong;
            public decimal truLuong;
            public decimal tienLuong;

            public Luong(decimal luong, decimal truLuong, decimal tienThuong)
            {
                this.luong = luong;
                this.truLuong = truLuong;
                this.tienThuong = tienThuong;
                tienLuong = luong + tienThuong - truLuong;
            }
        }
    }
}
