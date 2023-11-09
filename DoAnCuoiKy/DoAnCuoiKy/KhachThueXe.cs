using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
{
    class KhachThueXe : Nguoi
    {
        private string ngheNghiep;
        public DateTime NgaySinh { get { return ngaySinh; } }
        public KhachThueXe(string hoTen, string diaChi, string soDienThoai, DateTime ngaySinh, NganHang nganHang, string ngheNghiep) : base(hoTen, diaChi, soDienThoai, ngaySinh, nganHang)
        {
            this.ngheNghiep = ngheNghiep;
        }
        protected Xe KhachChonXe(List<Xe> danhSach)
        {
            Random random = new Random();
            int viTri = random.Next(0, danhSach.Count);
            Xe xe = danhSach[viTri];
            return xe;
        }
        public Xe KhachYeuCauTimVaChonXe(ChuChoThue chu,Xe.EPhanLoai loaiXe, decimal giaTu, decimal giaDen)
        {
            List<Xe> danhSachTimKiem =chu.TimXe(loaiXe, giaTu, giaDen);
            Xe xeDuocChon=KhachChonXe(danhSachTimKiem);
            return xeDuocChon;
        }
    }
}
