using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
{
    class KhachThueXe : ThongTinCoBan
    {
        public QuanLyDanhGia danhGia;
        public KhachThueXe(string hoTen, string diaChi, string soDienThoai, DateTime ngaySinh, NganHang nganHang) 
            : base(hoTen, diaChi, soDienThoai, ngaySinh, nganHang)
        {
            danhGia = new QuanLyDanhGia();
        }
        public List<Xe> KhachYeuCauTimVaChonXe(ChuChoThue chu, Xe.EPhanLoai loaiXe, decimal giaTu, decimal giaDen)
        {
            return chu.TimXe(loaiXe, giaTu, giaDen);
        }
    }
}
