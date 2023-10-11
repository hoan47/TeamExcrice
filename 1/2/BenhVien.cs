using System;
using System.Collections.Generic;

namespace _2
{
    class BenhVien
    {
        private DateTime thoiDiem;
        private int soNgayChoNghiCuaThang;
        private decimal luongCoBan;
        private List<KeyValuePair<NhanVien, decimal>> danhSachNhanVien;

        public BenhVien(DateTime thoiDiem, int soNgayChoNghiCuaThang, decimal luongCoBan)
        {
            this.thoiDiem = thoiDiem;
            this.soNgayChoNghiCuaThang = soNgayChoNghiCuaThang;
            this.luongCoBan = luongCoBan;
            danhSachNhanVien = new List<KeyValuePair<NhanVien, decimal>>();
        }
        public void ThemNhanVien(NhanVien nhanVien)
        {
            danhSachNhanVien.Add(new KeyValuePair<NhanVien, decimal>
                (nhanVien, nhanVien.Luong(luongCoBan, soNgayChoNghiCuaThang, DateTime.DaysInMonth(thoiDiem.Year, thoiDiem.Month))));       
        }
        public void InDanhSachNhanVien()
        {
            Console.WriteLine($"Danh sach nhan vien benh vien tai thoi diem: {thoiDiem.ToString("dd/MM/yyyy")}\n");
            foreach(KeyValuePair<NhanVien, decimal> nhanVien in danhSachNhanVien)
            {
                nhanVien.Key.InThongTin();
            }    
        }
        public void LuongMotThangCongTyPhaiTra()
        {
            decimal luong = 0;
            foreach (KeyValuePair<NhanVien, decimal> nhanVien in danhSachNhanVien)
            {
                luong = luong + nhanVien.Value;
            }
            Console.WriteLine($"Luong thang {thoiDiem.ToString("MM")} benh vien phai tra la: " + string.Format("{0:N0}", luong) + " VND");
        }
        public void NhanVienGioiNhat()
        {
            danhSachNhanVien.Sort((a, b) => b.Value.CompareTo(a.Value));
            Console.WriteLine("\n\nDanh sach 3 nhan vien la viec gioi nhat:\n");
            for(int i = 0; i < 3 && i < danhSachNhanVien.Count; i++)
            {
                danhSachNhanVien[i].Key.InThongTin();
                Console.WriteLine("Luong: " + string.Format("{0:N0}", Math.Round(danhSachNhanVien[i].Value)));
                Console.WriteLine();
            }    
        }
    }
}
