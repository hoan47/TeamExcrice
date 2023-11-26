using Microsoft.Office.Interop.Excel;
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
        private ChuXe chuThue;
        private TaiXe taiXe;
        private Xe xeChoThue;
        private DateTime ngayThue;
        private int soNgay;
        static private Dictionary<Tuple<ChuXe, KhachThueXe, Xe>, HopDongThueXe> danhSachHopDong;
        public static Dictionary<Tuple<ChuXe, KhachThueXe, Xe>, HopDongThueXe> DanhSachHopDong { get { return danhSachHopDong; } }

        public HopDongThueXe(KhachThueXe khachThue, ChuXe chuThue, TaiXe taiXe, Xe xeChoThue, int soNgay, DateTime ngayThue)
        {
            this.khachThue = khachThue;
            this.chuThue = chuThue;
            this.taiXe = taiXe;
            this.xeChoThue = xeChoThue;
            this.soNgay = soNgay;
            this.ngayThue = ngayThue;
            danhSachHopDong = new Dictionary<Tuple<ChuXe, KhachThueXe, Xe>, HopDongThueXe>();
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
            decimal giaThueChinhThuc = TienKhuyenMai() + TienTangGia() + xeChoThue.GiaThueMotNgay * soNgay;

            Console.WriteLine($"\nSo tien thue khach phai tra: " + string.Format("{0:N0}", giaThueChinhThuc) + " VND");
            if (khachThue.NganHang.ChuyenTien(chuThue.NganHang, giaThueChinhThuc + xeChoThue.TienCoc) == true)
            {
                chuThue.ChoThueXe(xeChoThue);
                khachThue.ThemXeDaThue(xeChoThue);
                danhSachHopDong.Add(new Tuple<ChuXe, KhachThueXe, Xe>(chuThue, khachThue, xeChoThue), this);
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
            if (khachThue.NganHang.ChuyenTien(chuThue.NganHang, chiPhiDen) == true || chiPhiDen == 0)
            {
                chuThue.KhachTraXe(xeChoThue);
                Console.WriteLine("Thanh cong, tong chi phi phat sinh phai tra: " + string.Format("{0:N0}", chiPhiDen) + " VND");
                chuThue.KhachHangQuen.ThueXe(khachThue);
                khachThue.KetThucThueXe(xeChoThue);
                danhSachHopDong.Remove(new Tuple<ChuXe, KhachThueXe, Xe>(chuThue, khachThue, xeChoThue));
            }
            else
            {
                Console.WriteLine("That bai!");
            }    
        }
        public void XemHopDong()
        {
            Console.WriteLine("\nHop dong thue xe giua khach va chu xe la:\nChu xe:");
            chuThue.ThongTin();
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
            Console.WriteLine("So ngay thue: " + soNgay);
            Console.WriteLine("Ngay bat dau thue: " + ngayThue.ToString("dd/MM/yyyy"));
            Console.WriteLine("Uu dai: " + string.Format("{0:N0}", TienKhuyenMai()) + " VND");
            Console.WriteLine("Tang gia: " + string.Format("{0:N0}", TienTangGia()) + " VND");
            Console.WriteLine("Noi dung cac chi phi phat sinh bao gom: ");
            Console.WriteLine("Chi phi gia han (tre han tra xe) = So ngay tre * " + xeChoThue.GiaThueMotNgay + "(VND)");
            Console.WriteLine("Tien boi thuong hu hong gom: ");
            Console.WriteLine($"Chi phi xuot xe: " + string.Format("{0:N0}", xeChoThue.GiaDenXuotXe) + " VND");
            Console.WriteLine($"Chi phi be banh: " + string.Format("{0:N0}", xeChoThue.GiaDenBeBanh) + " VND");
            Console.WriteLine($"Chi phi hu den: " + string.Format("{0:N0}", xeChoThue.GiaDenHuDen) + " VND");
            Console.WriteLine($"Tong so tien phai thanh toan: " + string.Format("{0:N0}", TienKhuyenMai() + TienTangGia() + xeChoThue.GiaThueMotNgay * soNgay + xeChoThue.TienCoc) + " VND");
        }
        public static HopDongThueXe KhoiTao(Xe xe, List<TaiXe> danhSachTaiXe, KhachThueXe khachThueXe)
        {
            return new HopDongThueXe(khachThueXe, xe.ChuXe, TaiXe.ChonTaiXe(danhSachTaiXe), xe, DauVaoBanPhim.Int(1, 365, "So ngay thue (toi da 365 ngay): "), DauVaoBanPhim.DateTime_("(Nam/thang/ngay) bat dau thue xe: "));
        }
        static protected void DocDuLieu(List<ChuXe> danhSachChuXe, List<KhachThueXe> danhSachKhachThueXe, List<TaiXe> danhSachTaiXe, Excel.ELoaiDuLieu loaiDuLieu)
        {
            Worksheet bangTinh = Excel.BangTinh(loaiDuLieu);

            try
            {
                DateTime ngayThangNam;

                for (int i = 3; bangTinh.Cells[i, 1].Value != null; i++)
                {
                    DateTime.TryParse(bangTinh.Cells[i, 3].Text, out ngayThangNam);

                    ChuXe chuXe = danhSachChuXe.Find(chu => chu.NganHang.SoTaiKhoan == bangTinh.Cells[i,2].Text);
                    Xe xeChoThue;
                    foreach(List<Xe> danhSach in chuXe.DanhSachXeChuaThue)
                    {
                        xeChoThue = danhSach.Find(xe => xe.BienSoXe == bangTinh.Cells[i, 3].Text);
                        if(xeChoThue != null)
                        {
                            break;
                        }
                    }
                    new HopDongThueXe(danhSachKhachThueXe.Find(khach => khach.NganHang.SoTaiKhoan == bangTinh.Cells[i, 1].Text), chuXe, bangTinh.Cells[i, 3].Text == "Không có tài xế" ? null : danhSachTaiXe.Find(taiXe => taiXe.NganHang.SoTaiKhoan == bangTinh.Cells[i, 3].Text), xeChoThue)
                }
            }
            catch (Exception e)
            {
                throw new Exception("Loi du lieu hop dong: " + e.Message);
            }
        }
    }
}
