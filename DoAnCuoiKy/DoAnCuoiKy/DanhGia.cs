using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
{
    public class DanhGia
    {
        private string noiDung;
        private EDanhGia sao;
        public DanhGia(string noiDung, EDanhGia sao)
        {
            this.noiDung = noiDung;
            this.sao = sao;
        }
        public void ThongTin()
        {
            Console.WriteLine("Noi dung: " + noiDung);
            Console.WriteLine("Sao: " + (int)sao);
        }
        public enum EDanhGia
        {
            sao1 = 1,
            sao2 = 2,
            sao3 = 3,
            sao4 = 4,
            sao5 = 5
        }
    }
}
