using System;
using System.Collections.Generic;

namespace DoAnCuoiKy
{
    class HopDongThueXe
    {
        private ChuXe chuXe;
        private TaiXe taiXe;
        private KhachThueXe khachThue;
        private Xe xeChoThue;
        private DateTime ngayThue;
        private int soNgayThue;
        static private Dictionary<Tuple<ChuXe, KhachThueXe, Xe>, HopDongThueXe> danhSachHopDong;
        public KhachThueXe KhachThue { get { return khachThue; } }
        public ChuXe ChuXe { get { return chuXe; } }
        public TaiXe TaiXe { get { return taiXe; } }
        public Xe XeChoThue { get { return xeChoThue; } }
        public DateTime NgayThue { get { return ngayThue; } }
        public int SoNgayThue { get { return soNgayThue; } }
        public static Dictionary<Tuple<ChuXe, KhachThueXe, Xe>, HopDongThueXe> DanhSachHopDong { get { return danhSachHopDong; } }

        public HopDongThueXe(ChuXe chuXe, TaiXe taiXe, KhachThueXe khachThue, Xe xeChoThue, int soNgayThue, DateTime ngayThue)
        {
            this.chuXe = chuXe;
            this.taiXe = taiXe;
            this.khachThue = khachThue;
            this.xeChoThue = xeChoThue;
            this.soNgayThue = soNgayThue;
            this.ngayThue = ngayThue;
            danhSachHopDong = new Dictionary<Tuple<ChuXe, KhachThueXe, Xe>, HopDongThueXe>();
        }
        public void ThanhToan()
        {
            decimal giaThueChinhThuc = TienKhuyenMai() + TienTangGia() + xeChoThue.GiaThueMotNgay * soNgayThue;

            Console.WriteLine($"\nSo tien thue khach phai tra: " + string.Format("{0:N0}", giaThueChinhThuc) + " VND");
            if (khachThue.NganHang.ChuyenTien(ChuXe.NganHang, giaThueChinhThuc + xeChoThue.TienCoc) == true)
            {
                ChuXe.ChoThueXe(xeChoThue);
                khachThue.ThemXeDaThue(xeChoThue);
                danhSachHopDong.Add(new Tuple<ChuXe, KhachThueXe, Xe>(ChuXe, khachThue, xeChoThue), this);
                ChuXe.KhachHangQuen.ThueXe(khachThue);
                Console.WriteLine("Thue xe thanh cong");
            }
            else
            {
                Console.WriteLine("Thue xe khong thanh cong");
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
            Console.WriteLine();
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
            if (khachThue.NganHang.ChuyenTien(ChuXe.NganHang, chiPhiDen) == true || chiPhiDen == 0)
            {
                ChuXe.KhachTraXe(xeChoThue);
                Console.WriteLine("Thanh cong, tong chi phi phat sinh phai tra: " + string.Format("{0:N0}", chiPhiDen) + " VND");
                khachThue.KetThucThueXe(xeChoThue);
                danhSachHopDong.Remove(new Tuple<ChuXe, KhachThueXe, Xe>(ChuXe, khachThue, xeChoThue));
            }
            else
            {
                Console.WriteLine("That bai!");
            }    
        }
        public void XemHopDong()
        {
            Console.WriteLine("\nHop dong thue xe giua khach va chu xe la:\nChu xe:");
            ChuXe.ThongTin();
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
            xeChoThue.XuatThongTinXe();
            Console.WriteLine("So ngay thue: " + soNgayThue);
            Console.WriteLine("Ngay bat dau thue: " + ngayThue.ToString("dd/MM/yyyy"));
            Console.WriteLine("Uu dai: " + string.Format("{0:N0}", TienKhuyenMai()) + " VND");
            Console.WriteLine("Tang gia: " + string.Format("{0:N0}", TienTangGia()) + " VND");
            Console.WriteLine("Noi dung cac chi phi phat sinh bao gom: ");
            Console.WriteLine("Chi phi gia han (tre han tra xe) = So ngay tre * " + xeChoThue.GiaThueMotNgay + "(VND)");
            Console.WriteLine("Tien boi thuong hu hong gom: ");
            Console.WriteLine($"Chi phi xuot xe: " + string.Format("{0:N0}", xeChoThue.GiaDenXuotXe) + " VND");
            Console.WriteLine($"Chi phi be banh: " + string.Format("{0:N0}", xeChoThue.GiaDenBeBanh) + " VND");
            Console.WriteLine($"Chi phi hu den: " + string.Format("{0:N0}", xeChoThue.GiaDenHuDen) + " VND");
            Console.WriteLine($"Tong so tien phai thanh toan: " + string.Format("{0:N0}", TienKhuyenMai() + TienTangGia() + xeChoThue.GiaThueMotNgay * soNgayThue + xeChoThue.TienCoc) + " VND");
        }
        public static HopDongThueXe KhoiTao(Xe xe, List<TaiXe> danhSachTaiXe, KhachThueXe khachThueXe)
        {
            return new HopDongThueXe(xe.ChuXe, TaiXe.ChonTaiXe(danhSachTaiXe), khachThueXe, xe, DauVaoBanPhim.Int(1, 365, "So ngay thue (toi da 365 ngay): "), DauVaoBanPhim.DateTime_("(Nam/thang/ngay) bat dau thue xe: "));
        }
        private decimal TienKhuyenMai()
        {
            return ngayThue.Day == khachThue.NgaySinh.Day && ngayThue.Month == khachThue.NgaySinh.Month ? ChuXe.KhachHangQuen.SoLanThueXe(khachThue) >= 3 ? xeChoThue.UuDai * 1.5m : xeChoThue.UuDai : 0;
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
    }
}
