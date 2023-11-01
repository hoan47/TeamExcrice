using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi
{
    class HopDongThueXe
    {
        private KhachThueXe khachThue;
        private ChuChoThue chuThue;
        private Xe.PhanLoai phanLoai;
        private DateTime ngayThue;
        private int soNgay;
        private decimal giaThueChinhThuc;
        private decimal tienCoc;
        private decimal tienGiaHan;
        private decimal uuDai;
        private decimal tangGia;
        private decimal tienXuotXe;
        private decimal tienBeBanh;
        private decimal tienHuDen;
        private string danhGia;
        private decimal chiPhiDen = 0;

        public HopDongThueXe(KhachThueXe khachThue, ChuChoThue chuThue, Xe.PhanLoai phanLoai, int soNgay, DateTime ngayThue)
        {
            this.khachThue = khachThue;
            this.chuThue = chuThue;
            this.phanLoai = phanLoai;
            this.soNgay = soNgay;
            this.ngayThue = ngayThue;
        }
        protected void TimXeMay(decimal gia, ChuChoThue chuThue)
        {
            XeMay xeMay;
            xeMay = khachThue.YeuCauTimXeMay(gia, chuThue);
            if (xeMay == null)
                Console.WriteLine("Khong co xe theo yeu cau");
            else
            {
                giaThueChinhThuc = xeMay.giaThueMotNgay * soNgay;
                tienCoc = xeMay.tienCoc;
                tienGiaHan = xeMay.giaThueMotNgay;
                uuDai = xeMay.uuDai;
                tangGia = xeMay.tangGia;
                tienXuotXe = xeMay.giaDenXuotXe;
                tienBeBanh = xeMay.giaDenBeBanh;
                tienHuDen = xeMay.giaDenHuDen;
            }
        }
        protected void TimXeBonCho(decimal gia, ChuChoThue chuThue)
        {
            XeBonCho xeBonCho;
            xeBonCho = khachThue.YeuCauTimXeBonCho(gia, chuThue);
            if (xeBonCho == null)
                Console.WriteLine("Khong co xe theo yeu cau");
            else
            {
                giaThueChinhThuc = xeBonCho.giaThueMotNgay * soNgay;
                tienCoc = xeBonCho.tienCoc;
                tienGiaHan = xeBonCho.giaThueMotNgay;
                uuDai = xeBonCho.uuDai;
                tangGia = xeBonCho.tangGia;
                tienXuotXe = xeBonCho.giaDenXuotXe;
                tienBeBanh = xeBonCho.giaDenBeBanh;
                tienHuDen = xeBonCho.giaDenHuDen;
            }
        }
        protected void TimXeBayCho(decimal gia, ChuChoThue chuThue)
        {
            XeBayCho xeBayCho;
            xeBayCho = khachThue.YeuCauTimXeBayCho(gia, chuThue);
            if (xeBayCho == null)
                Console.WriteLine("Khong co xe theo yeu cau");
            else
            {
                giaThueChinhThuc = xeBayCho.giaThueMotNgay * soNgay;
                tienCoc = xeBayCho.tienCoc;
                tienGiaHan = xeBayCho.giaThueMotNgay;
                uuDai = xeBayCho.uuDai;
                tangGia = xeBayCho.tangGia;
                tienXuotXe = xeBayCho.giaDenXuotXe;
                tienBeBanh = xeBayCho.giaDenBeBanh;
                tienHuDen = xeBayCho.giaDenHuDen;
            }
        }
        public enum UuDaiChoKhach
        {
            co,
            khong
        }
        public enum TangGiaTheoDip
        {
            co,
            khong
        }
        protected UuDaiChoKhach UuDai()
        {
            if (ngayThue.Day == khachThue.ngaySinh.Day && ngayThue.Month == khachThue.ngaySinh.Month || khachThue.soLanThueXe >= 3)
                return UuDaiChoKhach.co;
            else
                return UuDaiChoKhach.khong;
        }
        protected TangGiaTheoDip TangGia()
        {
            if (ngayThue.Month >= 4 && ngayThue.Month <= 6 || ngayThue.Month == 2)
                return TangGiaTheoDip.co;
            else
                return TangGiaTheoDip.khong;
        }
        protected void LoaiXeThue(decimal gia, ChuChoThue chuThue)
        {
            if (phanLoai == Xe.PhanLoai.may)
            {
                TimXeMay(gia, chuThue);
            }
            else if (phanLoai == Xe.PhanLoai.bonCho)
            {
                TimXeBonCho(gia, chuThue);
            }
            else if (phanLoai == Xe.PhanLoai.bayCho)
            {
                TimXeBayCho(gia, chuThue);
            }
        }
        protected void KhuyenMaiVaTangGia(decimal gia, ChuChoThue chuThue)
        {
            LoaiXeThue(gia, chuThue);
            if (UuDai() == UuDaiChoKhach.co)
                giaThueChinhThuc -= uuDai;
            if (TangGia() == TangGiaTheoDip.co)
                giaThueChinhThuc += tangGia;
        }
        protected bool ThanhToanTienCoc()
        {
            if (khachThue.NganHang.ChuyenTien(chuThue.NganHang, tienCoc) == true)
                return true;
            else
                return false;
        }
        public bool ThanhToan(decimal gia, ChuChoThue chuThue)
        {
            KhuyenMaiVaTangGia(gia, chuThue);
            if (ThanhToanTienCoc() == true)
            {
                if (khachThue.NganHang.ChuyenTien(chuThue.NganHang, (giaThueChinhThuc - tienCoc)) == true)
                    return true;
                else
                    return false;
            }
            else
            {
                if (khachThue.NganHang.ChuyenTien(chuThue.NganHang, giaThueChinhThuc) == true)
                    return true;
                else
                    return false;
            }
        }
        public void ThueXeThanhCong(decimal gia, ChuChoThue chuThue)
        {
            Console.WriteLine("So tien thue khach phai tra: " + giaThueChinhThuc + " dong");
            if (ThanhToan(gia, chuThue) == true)
                Console.WriteLine("Thue xe thanh cong");
            else
                Console.WriteLine("Thue xe khong thanh cong");
        }
        protected bool TraXeTre(int soNgayTre)
        {
            if (soNgayTre > 0)
            {
                tienGiaHan = tienGiaHan * soNgayTre;
                return true;
            }
            else
                return false;
        }
        protected bool KiemTraVaThanhToanSauKhiTra(bool kiemTraXuot, bool kiemTraBeBanh, bool kiemTraHuDen, int soNgayTre)
        {
            if (kiemTraXuot == true)
                chiPhiDen += tienXuotXe;
            if (kiemTraBeBanh == true)
                chiPhiDen += tienBeBanh;
            if (kiemTraHuDen == true)
                chiPhiDen += tienHuDen;
            if (TraXeTre(soNgayTre) == true)
                chiPhiDen += tienGiaHan;
            if (khachThue.NganHang.ChuyenTien(chuThue.NganHang, chiPhiDen) == true)
                return true;
            else
                return false;
        }
        public void TraXe(bool kiemTraXuot, bool kiemTraBeBanh, bool kiemTraHuDen, int soNgayTre)
        {
            bool kiemTra = KiemTraVaThanhToanSauKhiTra(kiemTraXuot, kiemTraBeBanh, kiemTraHuDen, soNgayTre);
            Console.WriteLine("Chi phi phat sinh phai tra: " + chiPhiDen + " dong");
            if (kiemTra == true)
            {
                Console.WriteLine("Tra xe thanh cong");
            }
            else
            {
                Console.WriteLine("Khong thanh cong");
                Console.WriteLine("Chi phi phat sinh chua duoc thanh toan");
            }
        }
    }
}
