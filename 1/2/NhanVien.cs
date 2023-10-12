using System;

namespace _2
{
    abstract class NhanVien : ThongTinNguoi
    {
        private string maSoNhanVien;
        private float heSoLuong;
        private DateTime ngayBatDauLamViec;
        private int soLanDiemDanhDi;
        private int soLanDiemDanhVe;

        public NhanVien(string hoTen, string maSoNhanVien, DateTime ngayThangNamSinh, string diaChi, float heSoLuong, DateTime ngayBatDauLamViec, int soLanDiemDanhDi, int soLanDiemDanhVe) : base(hoTen, ngayThangNamSinh, diaChi)
        {
            this.maSoNhanVien = maSoNhanVien;
            this.heSoLuong = heSoLuong;
            this.ngayBatDauLamViec = ngayBatDauLamViec;
            this.soLanDiemDanhDi = soLanDiemDanhDi;
            this.soLanDiemDanhVe = soLanDiemDanhVe;
        }

        public void InThongTinNhanVien()
        {
            Console.WriteLine("Ho va ten nhan vien: " + hoTen);
            Console.WriteLine("Ma nhan vien: " + maSoNhanVien);
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
