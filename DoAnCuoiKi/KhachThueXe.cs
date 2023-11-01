using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi
{
    class KhachThueXe : Nguoi
    {
        public int soLanThueXe = 0;
        private string ngheNghiep;
        public KhachThueXe(string hoTen, string diaChi, string soDienThoai, DateTime ngaySinh, NganHang nganHang, string ngheNghiep) : base(hoTen, diaChi, soDienThoai, ngaySinh, nganHang)
        {
            soLanThueXe += 1;
            this.ngheNghiep = ngheNghiep;
        }
        public XeMay YeuCauTimXeMay(decimal gia, ChuChoThue c)
        {
            XeMay xe = c.ChuTimXeMay(gia);
            return xe;
        }
        public XeBonCho YeuCauTimXeBonCho(decimal gia, ChuChoThue c)
        {
            XeBonCho xe = c.ChuTimXeBonCho(gia);
            return xe;
        }
        public XeBayCho YeuCauTimXeBayCho(decimal gia, ChuChoThue c)
        {
            XeBayCho xe = c.ChuTimXeBayCho(gia);
            return xe;
        }
        public void DanhGiaXe(string danhGia)
        {
            Console.WriteLine("Khach danh gia xe: " + danhGia);
        }
        public override void DanhGiaNguoi(string danhGia)
        {
            Console.WriteLine("Khach danh gia chu xe: " + danhGia);
        }
    }
}
