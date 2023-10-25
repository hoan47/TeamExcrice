using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi
{
    public class PhongTro
    {
        private float dienTich;
        private string noiThat;
        private decimal gia;
        private string diaChi;
        private bool danhChoNam;
        private bool danhChoNu;
        private bool duocNuoiThuCung;
        private bool loiDiRieng;
        private bool gioGiacTuDo;
        private int sucChua;
        private string yeuCauRieng;
        private NguoiChoThue nguoiChoThue;

        public PhongTro(float dienTich, string noiThat, decimal gia, string diaChi, bool danhChoNam, bool danhChoNu, bool duocNuoiThuCung, bool loiDiRieng,
                        bool gioGiacTuDo, int sucChua, string yeuCauRieng, NguoiChoThue nguoiChoThue)
        {
            this.dienTich = dienTich;
            this.noiThat = noiThat;
            this.gia = gia;
            this.diaChi = diaChi;
            this.danhChoNam = danhChoNam;
            this.danhChoNu = danhChoNu;
            this.duocNuoiThuCung = duocNuoiThuCung;
            this.loiDiRieng = loiDiRieng;
            this.gioGiacTuDo = gioGiacTuDo;
            this.sucChua = sucChua;
            this.yeuCauRieng = yeuCauRieng;
            this.nguoiChoThue = nguoiChoThue;
        }
        public NguoiChoThue NguoiChoThue
        {
            get { return nguoiChoThue; }
            private set { }
        }
        public void ThongTin()
        {
            Console.WriteLine("Dien tich: " + dienTich);
            Console.WriteLine("Noi that: " + noiThat);
            Console.WriteLine("Gia: " + gia);
            Console.WriteLine("Dia chi: " + diaChi);
            Console.WriteLine("Danh cho nam: " + danhChoNam);
            Console.WriteLine("Danh cho nu: " + danhChoNu);
            Console.WriteLine("Duoc nuoi thu cung: " + duocNuoiThuCung);
            Console.WriteLine("Loi di rieng: " + loiDiRieng);
            Console.WriteLine("Gio giac tu do: " + gioGiacTuDo);
            Console.WriteLine("Suc chua: " + sucChua);
            Console.WriteLine("Yeu cau rieng: " + yeuCauRieng);
        } 
    }
}
