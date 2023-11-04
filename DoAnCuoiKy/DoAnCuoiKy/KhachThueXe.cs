using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
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
    }
}
