using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DoAnCuoiKy.HopDongThueXe;

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
            if (ngayThue.Day == khachThue.NgaySinh.Day && ngayThue.Month == khachThue.NgaySinh.Month || khachThue.soLanThueXe >= 3)
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
        protected void KhuyenMaiVaTangGia()
        {
            giaThueChinhThuc = xeChoThue.giaThueMotNgay * soNgay;
            if (UuDai() == EUuDaiChoKhach.Co)
                giaThueChinhThuc -=xeChoThue.uuDai;
            if (TangGia() == ETangGiaTheoDip.Co)
                giaThueChinhThuc += xeChoThue.tangGia;
        }
        protected bool ThanhToanTienCoc()
        {
            if (khachThue.NganHang.ChuyenTien(chuThue.NganHang, xeChoThue.tienCoc) == true)
                return true;
            else
                return false;
        }
        public void ThanhToan()
        {
            KhuyenMaiVaTangGia();
            Console.WriteLine($"\nSo tien thue khach phai tra: " + string.Format("{0:N0}", giaThueChinhThuc) + " VND");
            if (ThanhToanTienCoc() == true)
            {
                if (khachThue.NganHang.ChuyenTien(chuThue.NganHang, (giaThueChinhThuc - xeChoThue.tienCoc)) == true)
                    Console.WriteLine("Thue xe thanh cong");
                else
                    Console.WriteLine("Thue xe khong thanh cong");
            }
            else
            {
                if (khachThue.NganHang.ChuyenTien(chuThue.NganHang, giaThueChinhThuc) == true)
                    Console.WriteLine("Thue xe thanh cong");
                else
                    Console.WriteLine("Thue xe khong thanh cong");
            }
            Console.WriteLine();
        }
        protected decimal TienGiaHanTraXe(int soNgayTre)
        {
            if (soNgayTre > 0)
            {
                 return xeChoThue.giaThueMotNgay * soNgayTre;
            }
            else
                return 0;
        }
        protected bool KiemTraVaThanhToanSauKhiTra(bool kiemTraXuot, bool kiemTraBeBanh, bool kiemTraHuDen, int soNgayTre)
        {
            if (kiemTraXuot == true)
                chiPhiDen += xeChoThue.giaDenXuotXe;
            if (kiemTraBeBanh == true)
                chiPhiDen += xeChoThue.giaDenBeBanh;
            if (kiemTraHuDen == true)
                chiPhiDen += xeChoThue.giaDenHuDen;
            chiPhiDen += TienGiaHanTraXe(soNgayTre);
            if (khachThue.NganHang.ChuyenTien(chuThue.NganHang, chiPhiDen) == true)
                return true;
            else
                return false;
        }
        protected void ChiPhiPhatSinh(bool kiemTraXuot, bool kiemTraBeBanh, bool kiemTraHuDen, int soNgayTre)
        {
            if (kiemTraXuot == true || kiemTraBeBanh == true || kiemTraHuDen == true || soNgayTre > 0)
            {
                Console.WriteLine($"\nChi phi phat sinh phai tra: " + string.Format("{0:N0}", chiPhiDen) + " VND");
                Console.WriteLine("Bao gom: ");
                if (kiemTraXuot == true)
                    Console.WriteLine($"Chi phi xuot xe: " + string.Format("{0:N0}", xeChoThue.giaDenXuotXe) + " VND");
                if (kiemTraBeBanh == true)
                    Console.WriteLine($"Chi phi be banh: " + string.Format("{0:N0}", xeChoThue.giaDenBeBanh) + " VND");
                if (kiemTraHuDen == true)
                    Console.WriteLine($"Chi phi hu den: " + string.Format("{0:N0}", xeChoThue.giaDenHuDen) + " VND");
                if (soNgayTre > 0)
                    Console.WriteLine($"Tien gia han: " + string.Format("{0:N0}", TienGiaHanTraXe(soNgayTre)) + " VND");
            }
            else
            {
                Console.WriteLine("Khong co chi phi phat sinh");
            }
        }
        public void KetQuaTraXe(bool kiemTraXuot, bool kiemTraBeBanh, bool kiemTraHuDen, int soNgayTre)
        {
            bool kiemTra = KiemTraVaThanhToanSauKhiTra(kiemTraXuot, kiemTraBeBanh, kiemTraHuDen, soNgayTre);
            ChiPhiPhatSinh(kiemTraXuot, kiemTraBeBanh, kiemTraHuDen, soNgayTre);
            if (kiemTra == true)
            {
                Console.WriteLine("Tra xe thanh cong");
            }
            else
            {
                Console.WriteLine("Khong thanh cong");
                Console.WriteLine("Chi phi phat sinh chua duoc thanh toan");
            }
            Console.WriteLine();
        }
    }
}
