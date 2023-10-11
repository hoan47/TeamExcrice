using System;
using System.Collections.Generic;

namespace _2
{
    class QuanLy : NhanVien
    {
        private List<BenhNhan> danhSachBenhNhanChuaTri;
        private List<NhanVien> danhSachNhanVienCanQuanLy;

        public QuanLy
            (string hoTen, string ma, DateTime ngayThangNamSinh, string diaChi, float heSoLuong, DateTime ngayBatDauLamViec, int soLanDiemDanhDi, int soLanDiemDanhVe) : 
            base(hoTen, ma, ngayThangNamSinh, diaChi, heSoLuong, ngayBatDauLamViec, soLanDiemDanhDi, soLanDiemDanhVe)
        {
            danhSachBenhNhanChuaTri = new List<BenhNhan>();
            danhSachNhanVienCanQuanLy = new List<NhanVien>();
        }

        public override void InThongTin()
        {
            Console.WriteLine("Cap bac: Quan ly");
            InThongTinNhanVien();
            Console.WriteLine("So benh nhan dang chua tri: " + danhSachBenhNhanChuaTri.Count);
            Console.WriteLine("So nhan vien can quan ly: " + danhSachNhanVienCanQuanLy.Count);
            Console.WriteLine();
        }

        public void ThemNhanVienQuanLy(NhanVien nhanVien)
        {
            if (nhanVien is BacSi || nhanVien is YTa || nhanVien is DieuDuong || nhanVien is VanPhong)
            {
                danhSachNhanVienCanQuanLy.Add(nhanVien);
            }
        }

        public void ThemBenhNhanChuaTri(BenhNhan benhNhan)
        {
            danhSachBenhNhanChuaTri.Add(benhNhan);
        }

        public override decimal Luong(decimal luongCoBan, int soNgayChoPhepNghi, int soNgayCuaThang)
        {
            decimal luong = luongCoBan * (decimal)heSoLuong;
            return luong - TruLuong(luong, soNgayChoPhepNghi, soNgayCuaThang) + danhSachBenhNhanChuaTri.Count * 10000;
        }
    }
}