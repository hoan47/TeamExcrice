using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
{
    public class DanhGia
    {
        private object nguoiDanhGia;
        private string noiDung;
        private EDanhGia sao;

        public DanhGia(object nguoiDanhGia, string noiDung, EDanhGia sao)
        {
            this.nguoiDanhGia = nguoiDanhGia;
            this.noiDung = noiDung;
            this.sao = sao;
        }
        static public new DanhGia KhoiTaoDanhGia(object nguoiDanhGia)
        {
            return new DanhGia(nguoiDanhGia, DauVaoBanPhim.String("Noi dung danh gia: "), DauVaoBanPhim.DanhGia_());
        }
        public void ThongTin()
        {
            ThongTinCoBan thongTinCoBan = (ThongTinCoBan)nguoiDanhGia;
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
