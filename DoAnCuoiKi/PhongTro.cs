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
            DanhSachDanhGia = new List<DanhGia>();
        }
        public List<DanhGia> DanhSachDanhGia { get; private set; }
        public NguoiChoThue NguoiChoThue
        {
            get { return nguoiChoThue; }
            private set { }
        }
        public void ThemDanhGia(DanhGia danhGia)
        {
            DanhSachDanhGia.Add(danhGia);
        }
        public class DanhGia
        {
            public ESao sao { get; private set; }
            public string noiDung;

            public DanhGia(ESao sao, string noiDung)
            {
                this.sao = sao;
                this.noiDung = noiDung;
            }
            public enum ESao
            {
                sao1,
                sao2,
                sao3,
                sao4,
                sao5,
            }
        }
    }
}
