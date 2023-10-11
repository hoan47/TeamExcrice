using System;

namespace _2
{
    class YTa : NhanVien
    {
        private int soBenhNhanChamSo;

        public YTa(string hoTen, string ma, DateTime ngayThangNamSinh, string diaChi, float heSoLuong, DateTime ngayBatDauLamViec, int soLanDiemDanhDi, int soLanDiemDanhVe, int soBenhNhanChamSo) : 
            base(hoTen, ma, ngayThangNamSinh, diaChi, heSoLuong, ngayBatDauLamViec, soLanDiemDanhDi, soLanDiemDanhVe)
        {
            this.soBenhNhanChamSo = soBenhNhanChamSo;
        }
        public override void InThongTin()
        {
            Console.WriteLine("Cap bac: Y ta");
            InThongTinNhanVien();
        }
        public override decimal Luong(decimal luongCoBan, int soNgayChoPhepNghi, int soNgayCuaThang)
        {
            decimal luong = luongCoBan * (decimal)heSoLuong + soBenhNhanChamSo * 200000;
            return luong - TruLuong(luong, soNgayChoPhepNghi, soNgayCuaThang);
        }
    }
}
