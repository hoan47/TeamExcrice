using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
{
    internal static class DuLieu
    {
        public static List<NganHang> danhSachNganHang;
        public static List<ChuXe> danhSachChuXe;
        public static List<TaiXe> danhSachTaiXe;
        public static List<KhachThueXe> danhSachKhachThueXe;

        static DuLieu()
        {
            danhSachNganHang = NganHang.DocDuLieu();
            danhSachChuXe = ChuXe.DocDuLieu(danhSachNganHang);
            danhSachTaiXe = TaiXe.DocDuLieu(danhSachNganHang);
            danhSachKhachThueXe = KhachThueXe.DocDuLieu(danhSachNganHang);
            XeMay.DocDuLieu(danhSachChuXe);
            XeBonCho.DocDuLieu(danhSachChuXe);
            XeBayCho.DocDuLieu(danhSachChuXe);
        }
        static public void KhoiTaoDuLieu() { }
    }
}
