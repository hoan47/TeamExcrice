using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    class ThongTinNguoi
    {
        protected string hoTen;
        protected DateTime ngayThangNamSinh;
        protected string diaChi;

        public ThongTinNguoi(string hoTen, DateTime ngayThangNamSinh, string diaChi)
        {
            this.hoTen = hoTen;
            this.ngayThangNamSinh = ngayThangNamSinh;
            this.diaChi = diaChi;
        }
    }
}
