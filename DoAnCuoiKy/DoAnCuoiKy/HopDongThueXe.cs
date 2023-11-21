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

        public HopDongThueXe(KhachThueXe khachThue, ChuChoThue chuThue, TaiXe taiXe, Xe xeChoThue, int soNgay, DateTime ngayThue)
        {
            this.khachThue = khachThue;
            this.chuThue = chuThue;
            this.taiXe = taiXe;
            this.xeChoThue = xeChoThue;
            this.soNgay = soNgay;
            this.ngayThue = ngayThue;
        }
        private decimal TienKhuyenMai()
        {
            return ngayThue.Day == khachThue.NgaySinh.Day && ngayThue.Month == khachThue.NgaySinh.Month ? chuThue.KhachHangQuen.SoLanThueXe(khachThue) >= 3 ? xeChoThue.UuDai * 1.5m : xeChoThue.UuDai : 0;
        }
        private decimal TienTangGia()
        {
            return 4 <= ngayThue.Month && ngayThue.Month <= 6 ? xeChoThue.TangGia : ngayThue.Month == 2 ? xeChoThue.TangGia * 2 : 0;
        }
        private decimal TienGiaHanTraXe(int soNgayTre)
        {
            return soNgayTre > 0 ? xeChoThue.GiaThueMotNgay * soNgayTre : 0;
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
        public void ThanhToan()
        {
            if (xeChoThue.DaThue == false)
            {
                decimal giaThueChinhThuc = TienKhuyenMai() + TienTangGia() + xeChoThue.GiaThueMotNgay * soNgay;

                Console.WriteLine($"\nSo tien thue khach phai tra: " + string.Format("{0:N0}", giaThueChinhThuc) + " VND");
                if (khachThue.NganHang.ChuyenTien(chuThue.NganHang, giaThueChinhThuc + xeChoThue.TienCoc) == true)
                {
                    Console.WriteLine("Thue xe thanh cong");
                    taiXe.TrangThai(true);
                    xeChoThue.DaThueXe();
                }
                else
                {
                    Console.WriteLine("Thue xe khong thanh cong");
                }
            }
            else
            {
                Console.WriteLine("Xe da co nguoi thue");
            }
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
                Console.WriteLine($"Tien gia han: " + string.Format("{0:N0}", soNgayTre > 0 ? xeChoThue.GiaThueMotNgay * soNgayTre : 0) + " VND");
            }
        }
        public void KetThucThueXe(bool kiemTraXuot, bool kiemTraBeBanh, bool kiemTraHuDen, int soNgayTre)
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
                taiXe.TrangThai(false);
                xeChoThue.TraXe();
                Console.WriteLine("Thanh cong tong chi phi phat sinh phai tra: " + chiPhiDen);
                chuThue.KhachHangQuen.ThueXe(khachThue);
            }
            else
            {
                Console.WriteLine("That bai!");
            }    
        }
    }
}
