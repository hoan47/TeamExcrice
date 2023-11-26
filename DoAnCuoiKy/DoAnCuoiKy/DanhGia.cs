using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
{
    internal class DanhGia
    {
        private ThongTinCoBan nguoiDanhGia;
        private string noiDung;
        private EDanhGia sao;

        public DanhGia(ThongTinCoBan nguoiDanhGia, string noiDung, EDanhGia sao)
        {
            this.nguoiDanhGia = nguoiDanhGia;
            this.noiDung = noiDung;
            this.sao = sao;
        }
        static public DanhGia KhoiTao(ThongTinCoBan nguoiDanhGia)
        {
            return new DanhGia(nguoiDanhGia, DauVaoBanPhim.String("Noi dung danh gia: "), DauVaoBanPhim.DanhGia_());
        }
        public void ThongTin()
        {
            ThongTinCoBan thongTinCoBan = nguoiDanhGia;
            Console.WriteLine("Ten nguoi danh gia: " + thongTinCoBan.HoTen);
            Console.WriteLine("Ngan hang nguoi danh gia: " + thongTinCoBan.NganHang.SoTaiKhoan);
            Console.WriteLine("Noi dung: " + noiDung);
            Console.WriteLine("Sao: " + (int)sao);
            Console.WriteLine();
        }
        public enum EDanhGia
        {
            Sao1 = 1,
            Sao2 = 2,
            Sao3 = 3,
            Sao4 = 4,
            Sao5 = 5
        }
    }
}
