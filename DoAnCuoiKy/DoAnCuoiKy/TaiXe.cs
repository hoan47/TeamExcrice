using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DoAnCuoiKy
{
    class TaiXe : ThongTinCoBan
    {
        private QuanLyDanhGia danhGia;
        private decimal giaThue;
        public QuanLyDanhGia DanhGia { get { return danhGia; } }
        public decimal GiaThue { get { return  giaThue; } }
        public TaiXe(string hoTen, string diaChi, string soDienThoai, DateTime ngaySinh, NganHang nganHang, decimal giaThue)
            : base(hoTen, diaChi, soDienThoai, ngaySinh, nganHang)
        {
            this.giaThue = giaThue;
            danhGia = new QuanLyDanhGia();
        }
        public TaiXe(NganHang nganHang) : base(nganHang) 
        {
            giaThue = DauVaoBanPhim.Decimal("Gia thue tai xe: ");
        }
        public override void ThongTin()
        {
            base.ThongTin();
            Console.WriteLine("Gia thue tai xe: " + giaThue);
        }
        static public void XuatDanhSachTaiXe(List<TaiXe> danhSachTaiXe)
        {
            Console.WriteLine("Danh sach tai xe:");
            XuatDanhSachThongTin(danhSachTaiXe.ToList<ThongTinCoBan>());
        }
        static public TaiXe ChonTaiXe()
        {
            Console.WriteLine((DuLieu.danhSachTaiXe.Count + 1).ToString() + ". Khong can tai xe");
            int luaChon = DauVaoBanPhim.Int(1,DuLieu.danhSachTaiXe.Count + 1, "Chon 1 trong " + DuLieu.danhSachTaiXe.Count.ToString() + " tai xe: ");

            return luaChon == DuLieu.danhSachTaiXe.Count + 1 ? null : DuLieu.danhSachTaiXe[luaChon - 1];
        }
    }
}
