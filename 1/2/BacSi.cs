using System;

namespace _2
{
    class BacSi : NhanVien
    {
        private int soGioLamViec;

        public BacSi(string hoTen, string ma, DateTime ngayThangNamSinh, string diaChi, float heSoLuong, DateTime ngayBatDauLamViec, int soLanDiemDanhDi, int soLanDiemDanhVe, int soGioLamViec) : 
            base(hoTen, ma, ngayThangNamSinh, diaChi, heSoLuong, ngayBatDauLamViec, soLanDiemDanhDi, soLanDiemDanhVe)
        {
            this.soGioLamViec = soGioLamViec;
        }

        public override void InThongTin()
        {
            Console.WriteLine("Cap bac: Bac si");
            InThongTinNhanVien();
        }
    }
}
