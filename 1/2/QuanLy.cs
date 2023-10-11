using System;
using System.Collections.Generic;

namespace _2
{
    class QuanLy : NhanVien
    {
        private int soBenhNhan;
        public QuanLy(string hoTen, string ma, DateTime ngayThangNamSinh, string diaChi, float heSoLuong, DateTime ngayBatDauLamViec, int soLanDiemDanhDi, int soLanDiemDanhVe, int soBenhNhan) : 
            base(hoTen, ma, ngayThangNamSinh, diaChi, heSoLuong, ngayBatDauLamViec, soLanDiemDanhDi, soLanDiemDanhVe)
        {
            this.soBenhNhan = soBenhNhan;
        }

        public override void InThongTin()
        {
            Console.WriteLine("Cap bac: Quan ly");
            InThongTinNhanVien();
        }
        public override decimal Luong(decimal luongCoBan, int soNgayChoPhepNghi, int soNgayCuaThang)
        {
            decimal luong = luongCoBan * (decimal)heSoLuong;
            return luong - TruLuong(luong, soNgayChoPhepNghi, soNgayCuaThang) + soBenhNhan * 10000;
        }
    }
}