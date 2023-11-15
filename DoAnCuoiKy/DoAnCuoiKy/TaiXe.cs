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
        public QuanLyDanhGia danhGia;
        public TaiXe(string hoTen, string diaChi, string soDienThoai, DateTime ngaySinh, NganHang nganHang) 
            : base(hoTen, diaChi, soDienThoai, ngaySinh, nganHang)
        { }
        public void TrangThai(bool daThue)
        {
            this.daThue = daThue;
        }
    }
}
