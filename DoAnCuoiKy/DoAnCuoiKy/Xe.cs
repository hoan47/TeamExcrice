using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
{
    class Xe
    {
        private ChuChoThue chuXe;
        protected string hangXe;
        protected DateTime namMua;
        protected double soKilomet;
        protected bool baoHiem;
        protected EMucDich mucDich;
        public decimal giaThueMotNgay;
        public decimal tienCoc;
        public decimal giaDenXuotXe;
        public decimal giaDenBeBanh;
        public decimal giaDenHuDen;
        public decimal uuDai;
        public decimal tangGia;

        public Xe(ChuChoThue chuXe, string hangXe, DateTime namMua, double soKilomet, bool baoHiem, EMucDich mucDich, decimal giaThueMotNgay, decimal tienCoc, decimal giaDenXuotXe, decimal giaDenBeBanh, decimal giaDenHuDen, decimal uuDai, decimal tangGia)
        {
            this.chuXe = chuXe;
            this.hangXe = hangXe;
            this.namMua = namMua;
            this.soKilomet = soKilomet;
            this.baoHiem = baoHiem;
            this.mucDich = mucDich;
            this.giaThueMotNgay = giaThueMotNgay;
            this.tienCoc = tienCoc;
            this.giaDenXuotXe = giaDenXuotXe;
            this.giaDenBeBanh = giaDenBeBanh;
            this.giaDenHuDen = giaDenHuDen;
            this.uuDai = uuDai;
            this.tangGia = tangGia;

            this.chuXe.ThemXe(this);
        }
        public ChuChoThue ChuXe{ get { return chuXe; } }
        public virtual void XuatThongTinXe()
        {
            Console.WriteLine("Hang xe: " + hangXe);
            Console.WriteLine("Nam mua: " + namMua.ToString("dd/MM/yyyy"));
            Console.WriteLine("So kilomet: " + soKilomet);
            Console.WriteLine("Muc dich: " + mucDich);
            Console.WriteLine("Gia: " + giaThueMotNgay);
            Console.WriteLine();
        }
        public enum EPhanLoai
        {
            XeMay = 0,
            XeBonCho = 1,
            XeBayCho = 2
        }
        public enum EMucDich
        {
            DuLich,
            DamCuoi,
            TapLai,
            Khac
        }
    }
}
