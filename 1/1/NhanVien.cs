using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    abstract class NhanVien
    {
        private string hoTen;
        private string ma;
        private DateTime ngayThangNamSinh;
        private string diaChi;
        private float heSoLuong;
        private DateTime ngayBatDauLamViec;
        private int soLanDiemDanhDi;
        private int soLanDiemDanhVe;

        public NhanVien(string hoTen, string ma, DateTime ngayThangNamSinh, string diaChi, float heSoLuong, DateTime ngayBatDauLamViec, int soLanDiemDanhDi, int soLanDiemDanhVe) : base()
        {
            this.hoTen = hoTen;
            this.ma = ma;
            this.ngayThangNamSinh = ngayThangNamSinh;
            this.diaChi = diaChi;
            this.heSoLuong = heSoLuong;
            this.ngayBatDauLamViec = ngayBatDauLamViec;
            this.soLanDiemDanhDi = soLanDiemDanhDi;
            this.soLanDiemDanhVe = soLanDiemDanhVe;
        }

        public void InThongTinNhanVien()
        {
            Console.WriteLine("Ho va ten nhan vien: " + hoTen);
            Console.WriteLine("Ma nhan vien: " + ma);
            Console.WriteLine("Ngay thang nam sinh: " + ngayThangNamSinh.ToString("dd/MM/yyyy"));
            Console.WriteLine("Dia chi: " + diaChi);
            Console.WriteLine("He so luong: " + heSoLuong);
            Console.WriteLine("Ngay bat dau lam viec: " +ngayBatDauLamViec.ToString("dd/MM/yyyy"));
            Console.WriteLine();
        }

        public int SoNgayDiLam()
        {
            return Math.Min(soLanDiemDanhDi, soLanDiemDanhVe);
        }

        public decimal TruLuong(decimal luong, int soNgayChoPhepNghi, int soNgayCuaThang)
        {
            int soNgayKhongDiLam =  Math.Abs(SoNgayDiLam() - soNgayCuaThang) - soNgayChoPhepNghi;
            soNgayKhongDiLam = soNgayKhongDiLam < 0 ? 0 : soNgayKhongDiLam;
            return luong / (soNgayCuaThang - soNgayChoPhepNghi) * soNgayKhongDiLam;
        }

        public decimal Luong(decimal luongCoBan)
        {
            return luongCoBan * (decimal)heSoLuong;
        }

        public virtual decimal TienThuong()
        {
            return 0;
        }

        public abstract void InThongTin();
    }
}
