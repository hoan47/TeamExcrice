using System;

namespace _2
{
    class DieuDuong : NhanVien
    {
        private int soBenhNhanChamSo;
        private decimal soCaDacBiet;
        public DieuDuong(string hoTen, string ma, DateTime ngayThangNamSinh, string diaChi, float heSoLuong, DateTime ngayBatDauLamViec, int soLanDiemDanhDi, int soLanDiemDanhVe, int soBenhNhanChamSo, int soCaDacBiet) : 
            base(hoTen, ma, ngayThangNamSinh, diaChi, heSoLuong, ngayBatDauLamViec, soLanDiemDanhDi, soLanDiemDanhVe)
        {
            this.soBenhNhanChamSo = soBenhNhanChamSo;
            this.soCaDacBiet = soCaDacBiet;
        }
        public override void InThongTin()
        {
            Console.WriteLine("Cap bac: Dieu duong");
            InThongTinNhanVien();
        }
        public override decimal Luong(decimal luongCoBan, int soNgayChoPhepNghi, int soNgayCuaThang)
        {
            decimal luong = luongCoBan * (decimal)heSoLuong + soBenhNhanChamSo * 100000 + 20000 * soCaDacBiet;
            return luong - TruLuong(luong, soNgayChoPhepNghi, soNgayCuaThang);
        }
    }
}
