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
        static public void XuatDanhSachTaiXe(List<TaiXe> danhSachKhachThueXe)
        {
            Console.WriteLine("Danh sach tai xe:");
            XuatDanhSachThongTin(danhSachKhachThueXe.ToList<ThongTinCoBan>());
        }
        public override void ThongTin()
        {
            base.ThongTin();
        }
        static public TaiXe ChonTaiXe(List<TaiXe>danhSachTaiXe)
        {
            Console.WriteLine((danhSachTaiXe.Count + 1).ToString() + ". Khong can tai xe");
            int luaChon = DauVaoBanPhim.Int(1, danhSachTaiXe.Count + 1, "Chon 1 trong " + danhSachTaiXe.Count.ToString() + " tai xe: ");

            return luaChon == danhSachTaiXe.Count + 1 ? null : danhSachTaiXe[luaChon - 1];
        }
    }
}
