using System;
using System.Collections.Generic;

namespace _2
{
    class QuanLy : NhanVien
    {
        private List<BenhNhan> danhSachBenhNhanChuaTri;
        private List<NhanVien> danhSachNhanVienCanQuanLy;

        public QuanLy
            (string hoTen, string ma, DateTime ngayThangNamSinh, string diaChi, float heSoLuong, DateTime ngayBatDauLamViec, int soLanDiemDanhDi, int soLanDiemDanhVe) : 
            base(hoTen, ma, ngayThangNamSinh, diaChi, heSoLuong, ngayBatDauLamViec, soLanDiemDanhDi, soLanDiemDanhVe)
        {
            danhSachBenhNhanChuaTri = new List<BenhNhan>();
            danhSachNhanVienCanQuanLy = new List<NhanVien>();
        }

        public override void InThongTin()
        {
            Console.WriteLine("Cap bac: Quan ly");
            InThongTinNhanVien();
            Console.WriteLine("So benh nhan dang chua tri: " + danhSachBenhNhanChuaTri.Count);
            Console.WriteLine("So nhan vien can quan ly: " + danhSachNhanVienCanQuanLy.Count);
            Console.WriteLine();
        }

        public void ThemNhanVienDeQuanLy(NhanVien nhanVien)
        {
            if (nhanVien is BacSi || nhanVien is YTa || nhanVien is DieuDuong || nhanVien is VanPhong)
            {
                danhSachNhanVienCanQuanLy.Add(nhanVien);
            }
        }

        public void ThemBenhNhanDeChuaTri(BenhNhan benhNhan)
        {
            danhSachBenhNhanChuaTri.Add(benhNhan);
        }

        public override decimal TienThuong()
        {
            return danhSachBenhNhanChuaTri.Count * 10000;
        }
    }
}