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
        static private string duongDanDuLieu = "DanhSachTaiXe.xlsx";
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
        static public List<TaiXe> DocDuLieu()
        {
            List<TaiXe> danhSachTaiXe = new List<TaiXe>();
            DocDuLieu(null, danhSachTaiXe, null, duongDanDuLieu);
            return danhSachTaiXe;
        }
    }
}
