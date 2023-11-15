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
        private TaiXe taiXe;
        private Xe xeChoThue;
        private DateTime ngayThue;
        private int soNgay;
        private bool trangThai;
        public HopDongThueXe(KhachThueXe khachThue, ChuChoThue chuThue, Xe xeChoThue, int soNgay, DateTime ngayThue)
        {
            this.khachThue = khachThue;
            this.chuThue = chuThue;
            this.xeChoThue = xeChoThue;
            this.soNgay = soNgay;
            this.ngayThue = ngayThue;
            this.trangThai = false;
        }
        private decimal TienKhuyenMai()
        {
            if ((ngayThue.Day == khachThue.NgaySinh.Day && ngayThue.Month == khachThue.NgaySinh.Month) || chuThue.KhachHangQuen.SoLanThueXe(khachThue) >= 3)
            {
                return -xeChoThue.UuDai;
            }
            return 0;
        }
        private decimal TienTangGia()
        {
            return ngayThue.Month >= 4 && ngayThue.Month <= 6 || ngayThue.Month == 2 ? xeChoThue.TangGia : 0;
        }
        public void ThanhToan()
        {
            if (trangThai == false)
            {
                decimal giaThueChinhThuc = TienKhuyenMai() + TienTangGia() + xeChoThue.GiaThueMotNgay * soNgay;

                Console.WriteLine($"\nSo tien thue khach phai tra: " + string.Format("{0:N0}", giaThueChinhThuc) + " VND");
                if (khachThue.NganHang.ChuyenTien(chuThue.NganHang, giaThueChinhThuc + xeChoThue.TienCoc) == true)
                {
                    Console.WriteLine("Thue xe thanh cong");
                }
                else
                {
                    Console.WriteLine("Thue xe khong thanh cong");
                }
            }
            throw new Exception("Xe da co nguoi thue");
        }
        private decimal TienGiaHanTraXe(int soNgayTre)
        {
            if (soNgayTre > 0)
            {
                return xeChoThue.GiaThueMotNgay * soNgayTre;
            }
            else
                return 0;
        }
        private decimal TongChiPhiPhatSinh(bool kiemTraXuot, bool kiemTraBeBanh, bool kiemTraHuDen, int soNgayTre)
        {
            decimal chiPhiDen = 0;

            if (kiemTraXuot == true)
            {
                chiPhiDen += xeChoThue.GiaDenXuotXe;
            }
            if (kiemTraBeBanh == true)
            {
                chiPhiDen += xeChoThue.GiaDenBeBanh;
            }
            if (kiemTraHuDen == true)
            {
                chiPhiDen += xeChoThue.GiaDenHuDen;
            }
            return chiPhiDen + TienGiaHanTraXe(soNgayTre);
        }
        public void CacChiPhiPhatSinh(bool kiemTraXuot, bool kiemTraBeBanh, bool kiemTraHuDen, int soNgayTre)
        {
            if (kiemTraXuot == true)
            {
                Console.WriteLine($"Chi phi xuot xe: " + string.Format("{0:N0}", xeChoThue.GiaDenXuotXe) + " VND");
            }
            if (kiemTraBeBanh == true)
            {
                Console.WriteLine($"Chi phi be banh: " + string.Format("{0:N0}", xeChoThue.GiaDenBeBanh) + " VND");
            }
            if (kiemTraHuDen == true)
            {
                Console.WriteLine($"Chi phi hu den: " + string.Format("{0:N0}", xeChoThue.GiaDenHuDen) + " VND");
            }
            if (soNgayTre > 0)
            {
                Console.WriteLine($"Tien gia han: " + string.Format("{0:N0}", TienGiaHanTraXe(soNgayTre)) + " VND");
            }
        }
        public void TraXe(bool kiemTraXuot, bool kiemTraBeBanh, bool kiemTraHuDen, int soNgayTre)
        {
            decimal chiPhiDen = TongChiPhiPhatSinh(kiemTraXuot, kiemTraBeBanh, kiemTraHuDen, soNgayTre);

            if (kiemTraXuot == true)
            {
                Console.WriteLine($"Chi phi xuot xe: " + string.Format("{0:N0}", xeChoThue.GiaDenXuotXe) + " VND");
            }
            if (kiemTraBeBanh == true)
            {
                Console.WriteLine($"Chi phi be banh: " + string.Format("{0:N0}", xeChoThue.GiaDenBeBanh) + " VND");
            }
            if (kiemTraHuDen == true)
            {
                Console.WriteLine($"Chi phi hu den: " + string.Format("{0:N0}", xeChoThue.GiaDenHuDen) + " VND");
            }
            if (soNgayTre > 0)
            {
                Console.WriteLine($"Tien gia han: " + string.Format("{0:N0}", TienGiaHanTraXe(soNgayTre)) + " VND");
            }
            if (khachThue.NganHang.ChuyenTien(chuThue.NganHang, chiPhiDen) == true || chiPhiDen == 0)
            {
                Console.WriteLine("Thanh cong tong chi phi phat sinh phai tra: " + chiPhiDen);
                chuThue.KhachHangQuen.ThueXe(khachThue);
            }
            else
            {
                Console.WriteLine("That bai!");
            }    
        }
        private enum EUuDaiChoKhach
        {
            Co,
            Khong
        }
        private enum ETangGiaTheoDip
        {
            Co,
            Khong
        }
    }
}
