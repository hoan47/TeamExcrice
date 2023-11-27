using System;
using System.Collections.Generic;

namespace DoAnCuoiKy
{
    internal class Xe
    {
        private ChuXe chuXe;
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
        private QuanLyDanhGia danhGia;
        private string bienSoXe;
        public ChuXe ChuXe { get { return chuXe; } }
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
        public decimal UuDai { get { return uuDai; } }
        public decimal TangGia { get { return tangGia; } }
        public QuanLyDanhGia DanhGia { get { return danhGia; } }
        public string BienSoXe { get { return bienSoXe; } }
        static private List<string> danhSachBienSoXe;
        static Xe()
        {
            danhSachBienSoXe = new List<string>();
        }
        public Xe(ChuXe chuXe, string hangXe, DateTime namMua, double kilometDaDi, bool baoHiem, EMucDich mucDich, decimal giaThueMotNgay, decimal tienCoc, decimal giaDenXuotXe, decimal giaDenBeBanh, decimal giaDenHuDen, decimal uuDai, decimal tangGia, string bienSoXe, bool daThue)
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
            KiemTraBienSoXe(bienSoXe);
            this.bienSoXe = bienSoXe;
            danhGia = new QuanLyDanhGia();
            ThemXe(daThue);
        }

        public void XuatThongTinXe()
        {
            Console.WriteLine("Hang xe: " + HangXe);
            Console.WriteLine("Nam mua: " + NamMua.ToString("dd/MM/yyyy"));
            Console.WriteLine("So kilomet: " + KilometDaDi);
            Console.WriteLine("Muc dich: " + MucDich);
            Console.WriteLine("Gia: " + GiaThueMotNgay);
            Console.WriteLine("Bien so xe: " + bienSoXe);
            Console.WriteLine();
        }
        static public EMucDich MucDichCuaXe(string duLieu)
        {
            switch (duLieu)
            {
                case "Du lịch":
                    return EMucDich.DuLich;
                case "Đám cưới":
                    return EMucDich.DamCuoi;
                case "Tập lái":
                    return EMucDich.TapLai;
                default:
                    return EMucDich.Khac;
            }
        }
        static public string MucDichCuaXe(EMucDich mucDich)
        {
            switch (mucDich)
            {
                case EMucDich.DuLich:
                    return "Du lịch";
                case EMucDich.DamCuoi:
                    return "Đám cưới";
                case EMucDich.TapLai:
                    return "Tập lái";
                default:
                    return "Khác";
            }
        }
        static public EPhanLoai PhanLoai(Xe xe)
        {
            if (xe == null)
            {
                throw new Exception("Khong co du lieu.");
            }
            if (xe is XeMay)
            {
                return EPhanLoai.XeMay;
            }
            else if (xe is XeBonCho)
            {
                return EPhanLoai.XeBonCho;
            }
            else
            {
                return EPhanLoai.XeBayCho;
            }
        }
        static public void XuatDanhSachXe(List<Xe> danhSachXe)
        {
            int soThuTu = 1;

            foreach (Xe xe in danhSachXe)
            {
                Console.WriteLine("So thu tu: " + soThuTu++.ToString());
                xe.XuatThongTinXe();
            }
        }
        private void KiemTraBienSoXe(string bienSoXe)
        {
            if (danhSachBienSoXe.Contains(bienSoXe) == true)
            {
                throw new Exception("Bien so xe da ton tai");
            }
            else
            {
                danhSachBienSoXe.Add(bienSoXe);
            }
        }
        private void ThemXe(bool daThue)
        {
            if (daThue == false)
            {
                chuXe.ThemXeChuaThue(this);
            }
            else
            {
                chuXe.ThemXeDaThue(this);
            }
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
