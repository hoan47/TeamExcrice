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
            if(danhSachDanhGia.Count == 0)
            {
                Console.WriteLine("Chua co danh gia nao het.");
                return;
            }
            foreach (DanhGia danhGia in DanhSachDanhGia)
            {
                Console.WriteLine("Danh gia:");
                danhGia.ThongTin();
            }
        }
    }
}
