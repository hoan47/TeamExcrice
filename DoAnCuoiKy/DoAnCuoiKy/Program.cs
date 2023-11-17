using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
{
    class Program
    {
        static void Main(string[] args)
        {
            List<NganHang> danhSachNganHang = new List<NganHang>();
            List<ChuChoThue> danhSachChuChoThue = new List<ChuChoThue>();
            List<TaiXe> danhSachTaiXe = new List<TaiXe>();
            List<KhachThueXe> danhSachKhachThueXe = new List<KhachThueXe>();
            List<Xe> danhSachXe = new List<Xe>();

            FileXe.Doc(danhSachNganHang, danhSachChuChoThue, danhSachTaiXe, danhSachKhachThueXe, danhSachXe);

            HopDongThueXe hopDong = new HopDongThueXe(danhSachKhachThueXe[0], danhSachChuChoThue[0], danhSachTaiXe[0], danhSachXe[8], 30, new DateTime(2023, 11, 18));
            hopDong.ThanhToan();

            FileXe.Viet(danhSachChuChoThue);
        }
    }
}
