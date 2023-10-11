using System;
using System.Collections.Generic;

namespace _2
{
    class YTa : NhanVien
    {
        private List<BenhNhan> danhSachBenhNhanChuaTri;

        public YTa(string hoTen, string ma, DateTime ngayThangNamSinh, string diaChi, float heSoLuong, DateTime ngayBatDauLamViec, int soLanDiemDanhDi, int soLanDiemDanhVe) : 
            base(hoTen, ma, ngayThangNamSinh, diaChi, heSoLuong, ngayBatDauLamViec, soLanDiemDanhDi, soLanDiemDanhVe)
        {
            danhSachBenhNhanChuaTri = new List<BenhNhan>();
        }
        public override void InThongTin()
        {
            Console.WriteLine("Cap bac: Y ta");
            InThongTinNhanVien();
            Console.WriteLine("So benh nhan dang chua tri: " + danhSachBenhNhanChuaTri.Count);
            Console.WriteLine();
        }
        public void ThemBenhNhanChuaTri(BenhNhan benhNhan)
        {
            danhSachBenhNhanChuaTri.Add(benhNhan);
        }
        public override decimal Luong(decimal luongCoBan, int soNgayChoPhepNghi, int soNgayCuaThang)
        {
            decimal luong = luongCoBan * (decimal)heSoLuong + danhSachBenhNhanChuaTri.Count * 200000;
            return luong - TruLuong(luong, soNgayChoPhepNghi, soNgayCuaThang);
        }
    }
}
