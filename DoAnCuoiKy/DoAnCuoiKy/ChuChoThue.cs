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
        private LichSuThueXe lichSu;

        public ChuChoThue(string hoTen, string diaChi, string soDienThoai, DateTime ngaySinh, NganHang nganHang) : base(hoTen, diaChi, soDienThoai, ngaySinh, nganHang)
        {
            danhSachXe = new List<Xe>[3];
        }
        public void ThemXe(Xe xe)
        {
            if (xe is XeMay)
            {
                danhSachXe[(int)EPhanLoai.XeMay].Add(xe);
            }
            else if (xe is XeBonCho)
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
        private class LichSuThueXe
        {
            public List<Khach> danhSachKhacThueXe;
            public void ThemKhach(KhachThueXe khachThueXe)
            {
                Khach lichSu = new Khach(khachThueXe, 1);

                if(danhSachKhacThueXe.All(khach => { lichSu = khach; return khach.khachThueXe == khachThueXe; }) == true)
                {
                    lichSu.soLanDaThue++;
                }
                else
                {
                    danhSachKhacThueXe.Add(lichSu);
                }
            }
            public class Khach
            {
                public KhachThueXe khachThueXe;
                public int soLanDaThue;
                public Khach(KhachThueXe khachThueXe, int soLanDaThue)
                {
                    this.khachThueXe = khachThueXe;
                    this.soLanDaThue = soLanDaThue;
                }
            }
        }
        public enum EPhanLoai
        {
            XeMay = 0,
            XeBonCho = 1,
            XeBayCho = 2
        }
    }
}
