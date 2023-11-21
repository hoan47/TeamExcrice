using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
{
    class QuanLyDanhGia
    {
        private List<DanhGia> danhSachDanhGia;
        public List<DanhGia> DanhSachDanhGia { get { return danhSachDanhGia; } }

        public QuanLyDanhGia()
        {
            danhSachDanhGia = new List<DanhGia>();
        }
        public void ThemDanhGia(DanhGia danhGia)
        {
            danhSachDanhGia.Add(danhGia);
        }
        public void XuatToanBoDanhGia()
        {
            foreach (DanhGia danhGia in DanhSachDanhGia)
            {
                Console.WriteLine("Danh gia:");
                danhGia.ThongTin();
            }
        }
    }
}
