using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
{
    class KhachThueXe : ThongTinCoBan
    {
        public KhachThueXe(string hoTen, string diaChi, string soDienThoai, DateTime ngaySinh, NganHang nganHang) 
            : base(hoTen, diaChi, soDienThoai, ngaySinh, nganHang)
        { }
        public List<Xe> KhachYeuCauTimVaChonXe(ChuChoThue chu, Xe.EPhanLoai loaiXe, decimal giaTu, decimal giaDen)
        {
            return chu.TimXe(loaiXe, giaTu, giaDen);
        }
        public void DanhGiaXe(EDanhGiaSao sao,string noiDung)
        {
            XuatSao(sao);
            Console.WriteLine("Danh gia cua khach hang ve xe: "+noiDung);
        }
        public override void DanhGiaNguoi(EDanhGiaSao sao, string noiDung)
        {
            Console.WriteLine("Danh gia cua khach hang danh cho chu: ");
            base.DanhGiaNguoi(sao, noiDung);
        }
    }
}
