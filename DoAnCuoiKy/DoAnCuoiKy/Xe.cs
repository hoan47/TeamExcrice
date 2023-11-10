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
        private string hangXe;
        private DateTime namMua;
        private double kilometDaDi;
        private bool baoHiem;
        private EMucDich mucDich;
        private decimal giaThueMotNgay;
        private decimal tienCoc;
        private decimal giaDenXuotXe;
        private decimal giaDenBeBanh;
        private decimal giaDenHuDen;
        private decimal uuDai;
        private decimal tangGia;
        public ChuChoThue ChuXe { get { return chuXe; } }
        public string HangXe { get { return hangXe; } }
        public DateTime NamMua { get { return namMua; } }
        public double KilometDaDi { get { return kilometDaDi; } }
        public bool BaoHiem { get { return baoHiem; } }
        public EMucDich MucDich { get { return mucDich; } }
        public decimal GiaThueMotNgay { get { return giaThueMotNgay; } }
        public decimal TienCoc { get { return tienCoc; } }
        public decimal GiaDenXuotXe { get { return giaDenXuotXe; } }
        public decimal GiaDenBeBanh { get { return giaDenBeBanh; } }
        public decimal GiaDenHuDen { get { return giaDenHuDen; } }
        public decimal UuDai { get { return uuDai; } private set { uuDai = value; } }
        public decimal TangGia { get { return tangGia; } private set { TangGia = value; } }

        public Xe(ChuChoThue chuXe, string hangXe, DateTime namMua, double kilometDaDi, bool baoHiem, EMucDich mucDich, decimal giaThueMotNgay, decimal tienCoc, decimal giaDenXuotXe, decimal giaDenBeBanh, decimal giaDenHuDen, decimal uuDai, decimal tangGia)
        {
            this.chuXe = chuXe;
            this.hangXe = hangXe;
            this.namMua = namMua;
            this.kilometDaDi = kilometDaDi;
            this.baoHiem = baoHiem;
            this.mucDich = mucDich;
            this.giaThueMotNgay = giaThueMotNgay;
            this.tienCoc = tienCoc;
            this.giaDenXuotXe = giaDenXuotXe;
            this.giaDenBeBanh = giaDenBeBanh;
            this.giaDenHuDen = giaDenHuDen;
            this.uuDai = uuDai;
            this.tangGia = tangGia;
            this.chuXe?.ThemXe(this);
        }
        public virtual void XuatThongTinXe()
        {
            Console.WriteLine("Hang xe: " + HangXe);
            Console.WriteLine("Nam mua: " + NamMua.ToString("dd/MM/yyyy"));
            Console.WriteLine("So kilomet: " + KilometDaDi);
            Console.WriteLine("Muc dich: " + MucDich);
            Console.WriteLine("Gia: " + GiaThueMotNgay);
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
