using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class LapTrinhVien : NhanVien
    {
        private int soGioLamViec;

        public LapTrinhVien(string hoTen, string ma, DateTime ngayThangNamSinh, string diaChi, float heSoLuong, DateTime ngayBatDauLamViec, int soLanDiemDanhDi, int soLanDiemDanhVe, int soGioLamViec) : 
            base(hoTen, ma, ngayThangNamSinh, diaChi, heSoLuong, ngayBatDauLamViec, soLanDiemDanhDi, soLanDiemDanhVe)
        {
            this.soGioLamViec = soGioLamViec;
        }
        public override void InThongTin()
        {
            Console.WriteLine("Cap bac: Lap trinh vien");
            InThongTinNhanVien();
        }
        public override decimal Luong(decimal luongCoBan, int soNgayChoPhepNghi, int soNgayCuaThang)
        {
            decimal luong = luongCoBan * (decimal)heSoLuong;// + (1.5m * luongCoBan * soGioLamViec);
            return luong - TruLuong(luong, soNgayChoPhepNghi, soNgayCuaThang);
        }
    }
}
