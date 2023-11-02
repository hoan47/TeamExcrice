using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
{
    class HopDongThueXe
    {
        private KhachThueXe khachThue;
        private ChuChoThue chuThue;
        private Xe xeChoThue;
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

        public HopDongThueXe(KhachThueXe khachThue, ChuChoThue chuThue, Xe xeChoThue, int soNgay, DateTime ngayThue)
        {
            this.khachThue = khachThue;
            this.chuThue = chuThue;
            this.xeChoThue = xeChoThue;
            this.soNgay = soNgay;
            this.ngayThue = ngayThue;
        }
        public enum EUuDaiChoKhach
        {
            Co,
            Khong
        }
        public enum ETangGiaTheoDip
        {
            Co,
            Khong
        }
        protected EUuDaiChoKhach UuDai()
        {
            if (ngayThue.Day == khachThue.ngaySinh.Day && ngayThue.Month == khachThue.ngaySinh.Month || khachThue.soLanThueXe >= 3)
                return EUuDaiChoKhach.Co;
            else
                return EUuDaiChoKhach.Khong;
        }
        protected ETangGiaTheoDip TangGia()
        {
            if (ngayThue.Month >= 4 && ngayThue.Month <= 6 || ngayThue.Month == 2)
                return ETangGiaTheoDip.Co;
            else
                return ETangGiaTheoDip.Khong;
        }
        protected void KhuyenMaiVaTangGia(decimal gia, ChuChoThue chuThue)
        {
            if (UuDai() == EUuDaiChoKhach.Co)
                giaThueChinhThuc -= uuDai;
            if (TangGia() == ETangGiaTheoDip.Co)
                giaThueChinhThuc += tangGia;
        }
        protected bool ThanhToanTienCoc()
        {
            if (khachThue.NganHang.ChuyenTien(chuThue.NganHang,tienCoc) == true)
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
            if (ThanhToan(gia,chuThue) == true)
                Console.WriteLine("Thue xe thanh Cong");
            else
                Console.WriteLine("Thue xe khong thanh Cong");
        }
        protected bool TraXeTre(int soNgayTre)
        {
            if (soNgayTre>0)
            {
                tienGiaHan = tienGiaHan * soNgayTre;
                return true;
            }
            else
                return false;
        }
        protected bool KiemTraVaThanhToanSauKhiTra(bool kiemTraXuot, bool kiemTraBeBanh, bool kiemTraHuDen,int soNgayTre)
        {
            if (kiemTraXuot == true)
                chiPhiDen += tienXuotXe;
            if (kiemTraBeBanh == true)
                chiPhiDen += tienBeBanh;
            if(kiemTraHuDen == true)
                chiPhiDen += tienHuDen;
            if (TraXeTre(soNgayTre) == true)
                chiPhiDen += tienGiaHan;
            if(khachThue.NganHang.ChuyenTien(chuThue.NganHang, chiPhiDen) == true)
                return true;
            else
                return false;
        }
        public void TraXe(bool kiemTraXuot, bool kiemTraBeBanh, bool kiemTraHuDen, int soNgayTre)
        {
            bool kiemTra = KiemTraVaThanhToanSauKhiTra(kiemTraXuot, kiemTraBeBanh, kiemTraHuDen, soNgayTre);
            Console.WriteLine("Chi phi phat sinh phai tra: " + chiPhiDen+ " dong");
            if (kiemTra== true)
            {
                Console.WriteLine("Tra xe thanh Cong");
            }
            else
            {
                Console.WriteLine("Khong thanh Cong");
                Console.WriteLine("Chi phi phat sinh chua duoc thanh toan");
            }
        }
    }
}
