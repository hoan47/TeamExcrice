using System;
using System.Collections.Generic;

namespace DoAnCuoiKy
{
    class HopDongThueXe
    {
        private TaiXe taiXe;
        private KhachThueXe khachThue;
        private Xe xe;
        private DateTime ngayThue;
        private int soNgayThue;
        static private Dictionary<KeyValuePair<KhachThueXe, Xe>, HopDongThueXe> danhSachHopDong;
        public KhachThueXe KhachThue { get { return khachThue; } }
        public TaiXe TaiXe { get { return taiXe; } }
        public Xe XeChoThue { get { return xe; } }
        public DateTime NgayThue { get { return ngayThue; } }
        public int SoNgayThue { get { return soNgayThue; } }
        public static Dictionary<KeyValuePair<KhachThueXe, Xe>, HopDongThueXe> DanhSachHopDong { get { return danhSachHopDong; } }

        static HopDongThueXe()
        {
            danhSachHopDong = new Dictionary<KeyValuePair<KhachThueXe, Xe>, HopDongThueXe>();
        }
        public HopDongThueXe(TaiXe taiXe, KhachThueXe khachThue, Xe xe, int soNgayThue, DateTime ngayThue)
        {
            this.taiXe = taiXe;
            this.khachThue = khachThue;
            this.xe = xe;
            this.soNgayThue = soNgayThue;
            this.ngayThue = ngayThue;
        }
        public HopDongThueXe(KhachThueXe khachThue, Xe xe)
        {
            taiXe = TaiXe.ChonTaiXe();
            this.khachThue = khachThue;
            this.xe = xe;
            soNgayThue = DauVaoBanPhim.Int(1, 365, "So ngay thue (1-365): ");
            ngayThue = DauVaoBanPhim.DateTime_("(Nam thang ngay) thue xe: ");
        }
        public decimal ThanhToan()
        {
            decimal giaThueChinhThuc = TienTangGia() - TienKhuyenMai() + xe.GiaThueMotNgay * soNgayThue;
            decimal thanhToan = giaThueChinhThuc + xe.TienCoc;

            Console.WriteLine($"\nSo tien thue khach phai tra: " + string.Format("{0:N0}", giaThueChinhThuc) + " VND");
            Console.WriteLine($"\nSo tien coc khach phai tra: " + string.Format("{0:N0}", xe.TienCoc) + " VND");
            if (khachThue.NganHang.ChuyenTien(xe.ChuXe.NganHang, thanhToan) == true)
            {
                xe.ChuXe.ChoThueXe(xe);
                khachThue.ThemXeDaThue(xe);
                danhSachHopDong.Add(new KeyValuePair<KhachThueXe, Xe>(khachThue, xe), this);
                xe.ChuXe.KhachHangQuen.ThueXe(khachThue);
                Console.WriteLine("Thue xe thanh cong");
                return thanhToan;
            }
            Console.WriteLine("Thue xe khong thanh cong");
            return 0;
        }
        public void CacChiPhiPhatSinh(bool kiemTraXuot, bool kiemTraBeBanh, bool kiemTraHuDen, int soNgayTre)
        {
            if (kiemTraXuot == true)
            {
                Console.WriteLine($"Chi phi xuot xe: " + string.Format("{0:N0}", xe.GiaDenXuotXe) + " VND");
            }
            if (kiemTraBeBanh == true)
            {
                Console.WriteLine($"Chi phi be banh: " + string.Format("{0:N0}", xe.GiaDenBeBanh) + " VND");
            }
            if (kiemTraHuDen == true)
            {
                Console.WriteLine($"Chi phi hu den: " + string.Format("{0:N0}", xe.GiaDenHuDen) + " VND");
            }
            if (soNgayTre > 0)
            {
                Console.WriteLine($"Tien gia han: " + string.Format("{0:N0}", soNgayTre > 0 ? xe.GiaThueMotNgay * soNgayTre : 0) + " VND");
            }
            Console.WriteLine();
        }
        public void KetThucThueXe(bool kiemTraXuot, bool kiemTraBeBanh, bool kiemTraHuDen, int soNgayTre)
        {
            decimal chiPhiDen = TongChiPhiPhatSinh(kiemTraXuot, kiemTraBeBanh, kiemTraHuDen, soNgayTre);

            if (kiemTraXuot == true)
            {
                Console.WriteLine($"Chi phi xuot xe: " + string.Format("{0:N0}", xe.GiaDenXuotXe) + " VND");
            }
            if (kiemTraBeBanh == true)
            {
                Console.WriteLine($"Chi phi be banh: " + string.Format("{0:N0}", xe.GiaDenBeBanh) + " VND");
            }
            if (kiemTraHuDen == true)
            {
                Console.WriteLine($"Chi phi hu den: " + string.Format("{0:N0}", xe.GiaDenHuDen) + " VND");
            }
            if (soNgayTre > 0)
            {
                Console.WriteLine($"Tien gia han: " + string.Format("{0:N0}", TienGiaHanTraXe(soNgayTre)) + " VND");
            }
            if ((khachThue.NganHang.ChuyenTien(xe.ChuXe.NganHang, chiPhiDen) == true || chiPhiDen == 0) && xe.ChuXe.NganHang.ChuyenTien(khachThue.NganHang, xe.TienCoc) == true)
            {
                Console.WriteLine("Thanh cong, tong chi phi phat sinh phai tra: " + string.Format("{0:N0}", chiPhiDen) + " VND");
                Console.WriteLine("Chu xe tra lai tien coc cho khach: " + string.Format("{0:N0}", xe.TienCoc) + " VND");
                xe.ChuXe.KhachTraXe(xe);
                khachThue.KetThucThueXe(xe);
                danhSachHopDong.Remove(new KeyValuePair<KhachThueXe, Xe>(khachThue, xe));
            }
            else
            {
                Console.WriteLine("That bai!");
            }    
        }
        public void XemHopDong()
        {
            Console.WriteLine("\nHop dong thue xe giua khach va chu xe la:\nChu xe:");
            xe.ChuXe.ThongTin();
            if (taiXe == null)
            {
                Console.WriteLine("Khong co tai xe.\n");
            }
            else
            { 
                Console.WriteLine("Tai xe:");
                taiXe.ThongTin();
            }
            Console.WriteLine("Khach thue xe:");
            khachThue.ThongTin();
            Console.WriteLine("Thong tin xe:");
            xe.XuatThongTinXe();
            Console.WriteLine("Tien coc: " + string.Format("{0:N0}", xe.TienCoc) + " VND");
            Console.WriteLine("So ngay thue: " + soNgayThue);
            Console.WriteLine("Ngay bat dau thue: " + ngayThue.ToString("dd/MM/yyyy"));
            Console.WriteLine("Uu dai: " + string.Format("{0:N0}", TienKhuyenMai()) + " VND");
            Console.WriteLine("Tang gia: " + string.Format("{0:N0}", TienTangGia()) + " VND");
            Console.WriteLine("Noi dung cac chi phi phat sinh bao gom: ");
            Console.WriteLine("Chi phi gia han (tre han tra xe) = So ngay tre * " + xe.GiaThueMotNgay + "(VND)");
            Console.WriteLine("Tien boi thuong hu hong gom: ");
            Console.WriteLine($"Chi phi xuot xe: " + string.Format("{0:N0}", xe.GiaDenXuotXe) + " VND");
            Console.WriteLine($"Chi phi be banh: " + string.Format("{0:N0}", xe.GiaDenBeBanh) + " VND");
            Console.WriteLine($"Chi phi hu den: " + string.Format("{0:N0}", xe.GiaDenHuDen) + " VND");
            Console.WriteLine($"Tong so tien phai thanh toan: " + string.Format("{0:N0}", TienTangGia() - TienKhuyenMai() + xe.GiaThueMotNgay * soNgayThue + xe.TienCoc) + " VND");
        }
        private decimal TienKhuyenMai()
        {
            return ngayThue.Day == khachThue.NgaySinh.Day && ngayThue.Month == khachThue.NgaySinh.Month ? xe.ChuXe.KhachHangQuen.SoLanThueXe(khachThue) >= 3 ? xe.UuDai * 1.5m : xe.UuDai : 0;
        }
        private decimal TienTangGia()
        {
            return 4 <= ngayThue.Month && ngayThue.Month <= 6 ? xe.TangGia : ngayThue.Month == 2 ? xe.TangGia * 2 : 0;
        }
        private decimal TienGiaHanTraXe(int soNgayTre)
        {
            return soNgayTre > 0 ? xe.GiaThueMotNgay * soNgayTre : 0;
        }
        private decimal TongChiPhiPhatSinh(bool kiemTraXuot, bool kiemTraBeBanh, bool kiemTraHuDen, int soNgayTre)
        {
            decimal chiPhiDen = 0;

            if (kiemTraXuot == true)
            {
                chiPhiDen += xe.GiaDenXuotXe;
            }
            if (kiemTraBeBanh == true)
            {
                chiPhiDen += xe.GiaDenBeBanh;
            }
            if (kiemTraHuDen == true)
            {
                chiPhiDen += xe.GiaDenHuDen;
            }
            return chiPhiDen + TienGiaHanTraXe(soNgayTre);
        }
    }
}
