using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class QuanLy : NhanVien
    {
        private List<NhanVien> danhSachNhanVienCanQuanLy;
        public QuanLy(string hoTen, string ma, DateTime ngayThangNamSinh, string diaChi, float heSoLuong, DateTime ngayBatDauLamViec, int soLanDiemDanhDi, int soLanDiemDanhVe) : 
            base(hoTen, ma, ngayThangNamSinh, diaChi, heSoLuong, ngayBatDauLamViec, soLanDiemDanhDi, soLanDiemDanhVe)
        {
            danhSachNhanVienCanQuanLy = new List<NhanVien>();
        }
        public void ThemNhanVienDeQuanLy(NhanVien nhanVien)
        {
            if (nhanVien is LapTrinhVien || nhanVien is ThietKe || nhanVien is KiemThu)
            {
                danhSachNhanVienCanQuanLy.Add(nhanVien);
            }
        }
        public override void InThongTin()
        {
            Console.WriteLine("Cap bac: Quan ly");
            InThongTinNhanVien();
            Console.WriteLine($"So nhan vien hien dang quan ly: {danhSachNhanVienCanQuanLy.Count}.\n");
        }
        public override decimal Luong(decimal luongCoBan, int soNgayChoPhepNghi, int soNgayCuaThang)
        {
            decimal luong = luongCoBan * (decimal)heSoLuong;
            return luong - TruLuong(luong, soNgayChoPhepNghi, soNgayCuaThang) + 
                (danhSachNhanVienCanQuanLy.Count >= 10 ? danhSachNhanVienCanQuanLy.Count * 100000 : 0);
        }
    }
}