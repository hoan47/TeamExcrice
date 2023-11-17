using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
{
    class ThongTinCoBan
    {
        private string hoTen;
        private string diaChi;
        private string soDienThoai;
        private DateTime ngaySinh;
        private NganHang nganHang;
        public string HoTen { get { return hoTen; } }
        public string DiaChi { get { return diaChi; } }
        public string SoDienThoai { get { return soDienThoai; } }
        public DateTime NgaySinh { get { return ngaySinh; } }
        public NganHang NganHang { get { return nganHang; } }
        public ThongTinCoBan(string hoTen, string diaChi, string soDienThoai, DateTime ngaySinh, NganHang nganHang)
        {
            this.hoTen = hoTen;
            this.diaChi = diaChi;
            this.soDienThoai = soDienThoai;
            this.ngaySinh = ngaySinh;
            this.nganHang = nganHang;
        }
        public void ThongTin()
        {
            Console.WriteLine("Ho ten: " + hoTen);
            Console.WriteLine("Dia chi: " + diaChi);
            Console.WriteLine("So dien thoai: " + soDienThoai);
            Console.WriteLine("Ngay sinh: " + ngaySinh.ToString("dd/MM/yyyy"));
            Console.WriteLine("So tai khoan ngan hang: " + nganHang.SoTaiKhoan);
        }
    }
}
