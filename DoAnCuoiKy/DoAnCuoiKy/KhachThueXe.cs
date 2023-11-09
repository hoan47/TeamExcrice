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
    }
}
