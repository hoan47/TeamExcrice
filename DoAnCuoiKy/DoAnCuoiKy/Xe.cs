using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
{
    class Xe
    {
        public PhanLoai loaiXe;
        protected string hangXe;
        protected DateTime namMua;
        protected double soKilomet;
        protected bool baoHiem;
        protected MucDich mucDich;
        public decimal giaThueMotNgay;
        public decimal tienCoc;
        public decimal giaDenXuotXe;
        public decimal giaDenBeBanh;
        public decimal giaDenHuDen;
        public decimal uuDai;
        public decimal tangGia;

        public Xe(string hangXe, DateTime namMua, double soKilomet, bool baoHiem, MucDich mucDich, decimal giaThueMotNgay, decimal tienCoc, decimal giaDenXuotXe, decimal giaDenBeBanh, decimal giaDenHuDen, decimal uuDai, decimal tangGia)
        {
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
        }
        public void XuatThongTinXe()
        {
            Console.WriteLine("Loai xe: " + loaiXe);
            Console.WriteLine("Hang xe: " + hangXe);
            Console.WriteLine("Nam mua: " + namMua.ToString("dd/MM/yyyy"));
            Console.WriteLine("So kilomet: " + soKilomet);
            Console.WriteLine("Muc dich: " + mucDich);
            Console.WriteLine("Gia: " + giaThueMotNgay);
        }
        public enum PhanLoai
        {
            may,
            bonCho,
            bayCho
        }
        public enum MucDich
        {
            cuoi,
            duLich,
            tapLai
        }
    }
}
