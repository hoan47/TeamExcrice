using System;
using System.Collections.Generic;
using System.Linq;

namespace DoAnCuoiKy
{
    class TaiXe : ThongTinCoBan
    {
        private QuanLyDanhGia danhGia;
        public QuanLyDanhGia DanhGia { get { return danhGia; } }
        public TaiXe(string hoTen, string diaChi, string soDienThoai, DateTime ngaySinh, NganHang nganHang)
            : base(hoTen, diaChi, soDienThoai, ngaySinh, nganHang)
        {
            danhGia = new QuanLyDanhGia();
        }
        public TaiXe(NganHang nganHang) : base(nganHang) { }
        static public void XuatDanhSachTaiXe(List<TaiXe> danhSachKhachThueXe)
        {
            Console.WriteLine("Danh sach tai xe:");
            XuatDanhSachThongTin(danhSachKhachThueXe.ToList<ThongTinCoBan>());
        }
        static public TaiXe ChonTaiXe()
        {
            Console.WriteLine((DuLieu.danhSachTaiXe.Count + 1).ToString() + ". Khong can tai xe");
            int luaChon = DauVaoBanPhim.Int(1, DuLieu.danhSachTaiXe.Count + 1, "Chon 1 trong " + DuLieu.danhSachTaiXe.Count.ToString() + " tai xe: ");

            return luaChon == DuLieu.danhSachTaiXe.Count + 1 ? null : DuLieu.danhSachTaiXe[luaChon - 1];
        }
    }
}
