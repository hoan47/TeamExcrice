using System;
using System.Collections.Generic;
using System.Linq;

namespace DoAnCuoiKy
{
    class KhachThueXe : ThongTinCoBan
    {
        private QuanLyDanhGia danhGia;
        private List<Xe> danhSachXeDaThue;
        public QuanLyDanhGia DanhGia { get { return danhGia; } }
        public List<Xe> DanhSachXeDaThue { get { return danhSachXeDaThue; } }

        public KhachThueXe(string hoTen, string diaChi, string soDienThoai, DateTime ngaySinh, NganHang nganHang) 
            : base(hoTen, diaChi, soDienThoai, ngaySinh, nganHang)
        {
            danhGia = new QuanLyDanhGia();
            danhSachXeDaThue = new List<Xe>();
        }
        public void ThemXeDaThue(Xe xe)
        {
            danhSachXeDaThue.Add(xe);
        }
        public void KetThucThueXe(Xe xe)
        {
            danhSachXeDaThue.Remove(xe);
        }
        public void XuatDanhSachXeDaThue()
        {
            Console.WriteLine("Danh sach xe da thue:");
            foreach(Xe xe in danhSachXeDaThue)
            {
                xe.XuatThongTinXe();
            }
        }
        static public void XuatDanhSachKhachThueXe(List<KhachThueXe> danhSachKhachThueXe)
        {
            Console.WriteLine("Danh sach khach thue xe:");
            XuatDanhSachThongTin(danhSachKhachThueXe.ToList<ThongTinCoBan>());
        }
    }
}
