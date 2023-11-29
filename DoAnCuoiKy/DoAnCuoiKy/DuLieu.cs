using System;
using System.Collections.Generic;

namespace DoAnCuoiKy
{
    internal static class DuLieu
    {
        public static List<NganHang> danhSachNganHang;
        public static List<ChuXe> danhSachChuXe;
        public static List<TaiXe> danhSachTaiXe;
        public static List<KhachThueXe> danhSachKhachThueXe;
        public static List<XeMay> danhSachXeMay;
        public static List<XeBonCho> danhSachXeBonCho;
        public static List<XeBayCho> danhSachXeBayCho;
        public static List<HopDongThueXe> danhSachHopDongThueXe;

        static public void KhoiTaoDuLieu()
        {
            danhSachNganHang = new List<NganHang>();
            danhSachChuXe = new List<ChuXe>();
            danhSachTaiXe = new List<TaiXe>();
            danhSachKhachThueXe = new List<KhachThueXe>();
            danhSachXeMay = new List<XeMay>();
            danhSachXeBonCho = new List<XeBonCho>();
            danhSachXeBayCho = new List<XeBayCho>();
            danhSachHopDongThueXe = new List<HopDongThueXe>();
            DocDuLieu.DocDuLieuNganHang();
            DocDuLieu.DocDuLieuChuXe();
            DocDuLieu.DocDuLieuTaiXe();
            DocDuLieu.DocDuLieuKhachThueXe();
            DocDuLieu.DocDuLieuXeMay();
            DocDuLieu.DocDuLieuXeBonCho();
            DocDuLieu.DocDuLieuXeBayCho();
            DocDuLieu.DocDuLieuHopDong();
            Console.Clear();
        }
        static public void LuuToanBoDuLieu()
        {
            Excel.XoaDuLieu();
            VietDuLieu.VietDuLieuNganHang();
            VietDuLieu.VietDuLieuChuXe();
            VietDuLieu.VietDuLieuTaiXe();
            VietDuLieu.VietDuLieuKhachThueXe();
            VietDuLieu.VietDuLieuXeMay();
            VietDuLieu.VietDuLieuXeBonCho();
            VietDuLieu.VietDuLieuXeBayCho();
            VietDuLieu.VietDuLieuHopDongThueXe();
            Excel.LuuDuLieu();
        }
    }
}
