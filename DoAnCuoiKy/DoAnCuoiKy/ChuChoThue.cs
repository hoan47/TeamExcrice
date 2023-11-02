using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
{
    class ChuChoThue : Nguoi
    {
        private List<Xe>[] danhSachXe;
        public ChuChoThue(string hoTen, string diaChi, string soDienThoai, DateTime ngaySinh, NganHang nganHang) : base(hoTen, diaChi, soDienThoai, ngaySinh, nganHang)
        {
            danhSachXe = new List<Xe>[3];
        }
        public void ThemXe(Xe xe)
        {
            if(xe is XeMay)
            {
                danhSachXe[(int)EPhanLoai.XeMay].Add(xe);
            }
            else if(xe is XeBonCho)
            {
                danhSachXe[(int)EPhanLoai.XeBonCho].Add(xe);
            }
            else
            {
                danhSachXe[(int)EPhanLoai.XeBayCho].Add(xe);
            }
        }
        public void TimXe(EPhanLoai loaiXe, decimal gia)
        {
            foreach (XeMay xe in danhSachXe[(int)loaiXe])
            {
                xe.XuatThongTinXe();
            }
        }
        public override void DanhGiaNguoi(string danhGia)
        {
            Console.WriteLine("Chu cho thue danh gia khach hang: " + danhGia);
        }
        public enum EPhanLoai
        {
            XeMay = 0,
            XeBonCho = 1,
            XeBayCho = 2
        }
    }
}
