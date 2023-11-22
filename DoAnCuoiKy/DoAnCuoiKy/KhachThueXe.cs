using System;
using System.Collections.Generic;
using System.Linq;

namespace DoAnCuoiKy
{
    class KhachThueXe : ThongTinCoBan
    {
        private QuanLyDanhGia danhGia;
        public QuanLyDanhGia DanhGia { get { return danhGia; } }
        public KhachThueXe(string hoTen, string diaChi, string soDienThoai, DateTime ngaySinh, NganHang nganHang) 
            : base(hoTen, diaChi, soDienThoai, ngaySinh, nganHang)
        {
            danhGia = new QuanLyDanhGia();
        }
        public List<Xe> KhachYeuCauTimVaChonXe(ChuXe chu, Xe.EPhanLoai loaiXe, decimal giaTu, decimal giaDen)
        {
            return chu.TimXe(loaiXe, giaTu, giaDen);
        }
        static public void XuatDanhSachKhachThueXe(List<KhachThueXe> danhSachKhachThueXe)
        {
            Console.WriteLine("Danh sach khach thue xe:");
            XuatDanhSachThongTin(danhSachKhachThueXe.ToList<ThongTinCoBan>());
        }
        static public List<KhachThueXe> DocDuLieu(List<NganHang> danhSachNganHang)
        {
            List<KhachThueXe> danhSachKhachThueXe = new List<KhachThueXe>();
            DocDuLieu(null, null, danhSachKhachThueXe, danhSachNganHang, Excel.ELoaiDuLieu.KhachThueXe);
            return danhSachKhachThueXe;
        }
    }
}
