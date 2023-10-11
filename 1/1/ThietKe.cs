using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class ThietKe : NhanVien
    {
        private decimal tienThuong;

        public ThietKe(string hoTen, string ma, DateTime ngayThangNamSinh, string diaChi, float heSoLuong, DateTime ngayBatDauLamViec, int soLanDiemDanhDi, int soLanDiemDanhVe, decimal tienThuong) : 
            base(hoTen, ma, ngayThangNamSinh, diaChi, heSoLuong, ngayBatDauLamViec, soLanDiemDanhDi, soLanDiemDanhVe)
        {
            this.tienThuong = tienThuong;
        }
        public override void InThongTin()
        {
            Console.WriteLine("Cap bac: Thiet ke");
            InThongTinNhanVien();
        }
        public override decimal Luong(decimal luongCoBan, int soNgayChoPhepNghi, int soNgayCuaThang)
        {
            decimal luong = luongCoBan * (decimal)heSoLuong + tienThuong;
            return luong - TruLuong(luong, soNgayChoPhepNghi, soNgayCuaThang);
        }
    }
}
