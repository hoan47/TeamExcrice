using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
{
    class ChuChoThue:Nguoi
    {
        private List<XeMay> danhSachXeMay;
        private List<XeBonCho> danhSachXeBonCho;
        private List<XeBayCho> danhSachXeBayCho;
        public ChuChoThue(string hoTen, string diaChi, string soDienThoai, DateTime ngaySinh, NganHang nganHang) : base(hoTen, diaChi, soDienThoai, ngaySinh, nganHang) 
        {
            danhSachXeMay = new List<XeMay>();
            danhSachXeBonCho=new List<XeBonCho>();
            danhSachXeBayCho=new List<XeBayCho>();
        }
        public void ThemXeMay(XeMay xe)
        {
            danhSachXeMay.Add(xe);
        }
        public void ThemXeBonCho(XeBonCho xe)
        {
            danhSachXeBonCho.Add(xe);
        }
        public void ThemXeBayCho(XeBayCho xe)
        {
            danhSachXeBayCho.Add(xe);
        }
        public XeMay ChuTimXeMay(decimal gia)
        {
            bool d = false;
            XeMay xeMay;
            XeMay[] danhSachXeTimThay = new XeMay[danhSachXeMay.Count];
            int i = 0;
            foreach (XeMay xe in danhSachXeMay)
            {
                if (xe.giaThueMotNgay == gia)
                {
                    danhSachXeTimThay[i] = xe;
                    i++;
                    d = true;
                }
            }
            if (d == true)
            {
                Random random = new Random();
                int viTri = random.Next(0, i);
                xeMay = danhSachXeTimThay[viTri];
                return xeMay;
            }
            else 
                return null;
        }
        public XeBonCho ChuTimXeBonCho(decimal gia)
        {
            bool d = false;
            XeBonCho xeBonCho;
            XeBonCho[] danhSachXeTimThay = new XeBonCho[danhSachXeBonCho.Count];
            int i = 0;
            foreach (XeBonCho xe in danhSachXeBonCho)
            {
                if (xe.giaThueMotNgay == gia)
                {
                    danhSachXeTimThay[i] = xe;
                    i++;
                    d = true;
                }
            }
            if (d == true)
            {
                Random random = new Random();
                int viTri = random.Next(0, i);
                xeBonCho = danhSachXeTimThay[viTri];
                return xeBonCho;
            }
            else
                return null;
        }
        public XeBayCho ChuTimXeBayCho(decimal gia)
        {
            bool d = false;
            XeBayCho xeBayCho;
            XeBayCho[] danhSachXeTimThay = new XeBayCho[danhSachXeBayCho.Count];
            int i = 0;
            foreach (XeBayCho xe in danhSachXeBayCho)
            {
                if (xe.giaThueMotNgay == gia)
                {
                    danhSachXeTimThay[i] = xe;
                    i++;
                    d = true;
                }
            }
            if (d == true)
            {
                Random random = new Random();
                int viTri = random.Next(0, i);
                xeBayCho = danhSachXeTimThay[viTri];
                return xeBayCho;
            }
            else
                return null;
        }
        public override void DanhGiaNguoi(string danhGia)
        {
            Console.WriteLine("Chu cho thue danh gia khach hang: " + danhGia);
        }
    }
}
