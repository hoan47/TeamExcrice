using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<NganHang> danhSachNganHang = new List<NganHang>();
            List<ChuChoThue> danhSachChuChoThue = new List<ChuChoThue>();
            List<TaiXe> danhSachTaiXe = new List<TaiXe>();
            List<KhachThueXe> danhSachKhachThueXe = new List<KhachThueXe>();
            List<Xe> danhSachXe = new List<Xe>();

            FileXe.Doc(danhSachNganHang, danhSachChuChoThue, danhSachTaiXe, danhSachKhachThueXe, danhSachXe);
            FileXe.Viet(danhSachChuChoThue);
            KhachThueXe k = new KhachThueXe("Dang Thi Thanh Hoa", "Ninh Thuan", "0554246232", new DateTime(2004, 10, 15), new NganHang("254", 10000000));
            k.danhGia.ThemDanhGia(new DanhGia("de thuong",DanhGia.EDanhGia.sao5));
            k.danhGia.XuatToanBoDanhGia();
            QuanLyDanhGia d = new QuanLyDanhGia();
        }
    }
}
