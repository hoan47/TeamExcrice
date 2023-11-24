using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
{
    class TaiXe : ThongTinCoBan
    {
        private bool daThue;
        public bool DaThue { get { return daThue; } }
        private QuanLyDanhGia danhGia;
        public QuanLyDanhGia DanhGia { get { return danhGia; } }
        public TaiXe(string hoTen, string diaChi, string soDienThoai, DateTime ngaySinh, NganHang nganHang)
            : base(hoTen, diaChi, soDienThoai, ngaySinh, nganHang)
        {
            danhGia = new QuanLyDanhGia();
        }
        public void TrangThai(bool daThue)
        {
            this.daThue = daThue;
        }
        static public void XuatDanhSachTaiXe(List<TaiXe> danhSachKhachThueXe)
        {
            Console.WriteLine("Danh sach tai xe:");
            XuatDanhSachThongTin(danhSachKhachThueXe.ToList<ThongTinCoBan>());
        }
        static public List<TaiXe> DocDuLieu(List<NganHang> danhSachNganHang)
        {
            List<TaiXe> danhSachTaiXe = new List<TaiXe>();
            DocDuLieu(null, danhSachTaiXe, null, danhSachNganHang, Excel.ELoaiDuLieu.TaiXe);
            return danhSachTaiXe;
        }
        public override void ThongTin()
        {
            base.ThongTin();
        }
        static public TaiXe ChonTaiXe(List<TaiXe>danhSachTaiXe)
        {
            return danhSachTaiXe[DauVaoBanPhim.Int(1, danhSachTaiXe.Count, "Chon 1 trong " + danhSachTaiXe.Count.ToString() + " tai xe: ") - 1];
        }
    }
}
