using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
{
    class ThongTinCoBan
    {
        protected string hoTen;
        protected string diaChi;
        protected string soDienThoai;
        protected DateTime ngaySinh;
        protected NganHang nganHang;
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
        protected void XuatSao(EDanhGiaSao sao)
        {
            if (sao == EDanhGiaSao.Mot)
                Console.WriteLine("1 sao");
            else if (sao == EDanhGiaSao.Hai)
                Console.WriteLine("2 sao");
            else if (sao == EDanhGiaSao.Ba)
                Console.WriteLine("3 sao");
            else if (sao == EDanhGiaSao.Bon)
                Console.WriteLine("4 sao");
            else if (sao == EDanhGiaSao.Nam)
                Console.WriteLine("5 sao");
            else
                Console.WriteLine("0 sao");
        }
        public virtual void DanhGiaNguoi(EDanhGiaSao sao, string noiDung)
        {
            XuatSao(sao);
            Console.WriteLine(noiDung); 
        }
        public enum EDanhGiaSao
        {
            Nam,
            Bon,
            Ba,
            Hai,
            Mot,
            Khong
        }
    }
}
