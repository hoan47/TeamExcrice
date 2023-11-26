using System;

namespace DoAnCuoiKy
{
    internal class DanhGia
    {
        private ThongTinCoBan nguoiDanhGia;
        private string noiDung;
        private EDanhGia sao;
        public ThongTinCoBan NguoiDanhGia { get { return nguoiDanhGia; } }
        public string NoiDung { get { return noiDung; } }
        public EDanhGia Sao { get { return sao; } }
        public DanhGia(ThongTinCoBan nguoiDanhGia, string noiDung, EDanhGia sao)
        {
            this.nguoiDanhGia = nguoiDanhGia;
            this.noiDung = noiDung;
            this.sao = sao;
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
        static public DanhGia KhoiTao(ThongTinCoBan nguoiDanhGia)
        {
            return new DanhGia(nguoiDanhGia, DauVaoBanPhim.String("Noi dung danh gia: "), DauVaoBanPhim.DanhGia_());
        }
        static public EDanhGia SaoDanhGia(int sao)
        {
            switch(sao)
            {
                case 1:
                    return EDanhGia.Sao1;
                case 2:
                    return EDanhGia.Sao2;
                case 3:
                    return EDanhGia.Sao3;
                case 4:
                    return EDanhGia.Sao4;
                default:
                    return EDanhGia.Sao5;
            }
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
