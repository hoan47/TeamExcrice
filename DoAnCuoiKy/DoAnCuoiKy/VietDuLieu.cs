using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
{
    static internal class VietDuLieu
    {
        static public void VietDuLieuNganHang()
        {
            try
            {
                for (int i = 0, hang = 3; i < DuLieu.danhSachNganHang.Count; i++, hang++)
                {
                    Excel.bangTinh[(int)Excel.ELoaiDuLieu.NganHang].Cells[hang, 1].Value = DuLieu.danhSachNganHang[i].SoTaiKhoan;
                    Excel.bangTinh[(int)Excel.ELoaiDuLieu.NganHang].Cells[hang, 2].Value = DuLieu.danhSachNganHang[i].SoDu;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Du lieu ngan hang loi: " + e.Message);
            }
        }
        static public void VietDuLieuChuXe()
        {
            VietNguoi(DuLieu.danhSachChuXe.ToList<ThongTinCoBan>(), Excel.bangTinh[(int)Excel.ELoaiDuLieu.ChuXe]);
        }
        static public void VietDuLieuTaiXe()
        {
            VietNguoi(DuLieu.danhSachTaiXe.ToList<ThongTinCoBan>(), Excel.bangTinh[(int)Excel.ELoaiDuLieu.TaiXe]);
        }
        static public void VietDuLieuKhachThueXe()
        {
            VietNguoi(DuLieu.danhSachKhachThueXe.ToList<ThongTinCoBan>(), Excel.bangTinh[(int)Excel.ELoaiDuLieu.KhachThueXe]);
        }
        public static void VietDuLieuXeMay()
        {
            VietXe(DuLieu.danhSachXeMay.ToList<Xe>(), Excel.bangTinh[(int)Excel.ELoaiDuLieu.XeMay]);
        }
        public static void VietDuLieuXeBonCho()
        {
            VietXe(DuLieu.danhSachXeBonCho.ToList<Xe>(), Excel.bangTinh[(int)Excel.ELoaiDuLieu.XeBonCho]);
        }
        public static void VietDuLieuXeBayCho()
        {
            VietXe(DuLieu.danhSachXeBayCho.ToList<Xe>(), Excel.bangTinh[(int)Excel.ELoaiDuLieu.XeBayCho]);
        }
        public static void VietDuLieuHopDongThueXe()
        {
            try
            {
                for (int i = 0, hang = 3; i < DuLieu.danhSachHopDongThueXe.Count; i++, hang++)
                {
                    Excel.bangTinh[(int)Excel.ELoaiDuLieu.HopDong].Cells[hang, 1].Value = DuLieu.danhSachHopDongThueXe[i].ChuXe.NganHang.SoTaiKhoan;
                    Excel.bangTinh[(int)Excel.ELoaiDuLieu.HopDong].Cells[hang, 2].Value = DuLieu.danhSachHopDongThueXe[i].TaiXe == null ? "Không có tài xế" : DuLieu.danhSachHopDongThueXe[i].TaiXe.NganHang.SoTaiKhoan;
                    Excel.bangTinh[(int)Excel.ELoaiDuLieu.HopDong].Cells[hang, 3].Value = DuLieu.danhSachHopDongThueXe[i].KhachThue.NganHang.SoTaiKhoan;
                    Excel.bangTinh[(int)Excel.ELoaiDuLieu.HopDong].Cells[hang, 4].Value = DuLieu.danhSachHopDongThueXe[i].XeChoThue.BienSoXe;
                    Excel.bangTinh[(int)Excel.ELoaiDuLieu.HopDong].Cells[hang, 5].Value = DuLieu.danhSachHopDongThueXe[i].SoNgayThue;
                    Excel.bangTinh[(int)Excel.ELoaiDuLieu.HopDong].Cells[hang, 6].Value = DuLieu.danhSachHopDongThueXe[i].NgayThue.ToString("yyyy-MM-dd");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Du lieu ngan hang loi: " + e.Message);
            }
        }
        private static void VietNguoi(List<ThongTinCoBan> danhSachKhachNguoi, Worksheet bangTinh)
        {
            try
            {
                for (int i = 0, hang = 3; i < danhSachKhachNguoi.Count; i++, hang++)
                {
                    bangTinh.Cells[hang, 1].Value = danhSachKhachNguoi[i].HoTen;
                    bangTinh.Cells[hang, 2].Value = danhSachKhachNguoi[i].DiaChi;
                    bangTinh.Cells[hang, 3].Value = danhSachKhachNguoi[i].SoDienThoai;
                    bangTinh.Cells[hang, 4].Value = danhSachKhachNguoi[i].NgaySinh.ToString("yyyy-MM-dd");
                    bangTinh.Cells[hang, 5].Value = danhSachKhachNguoi[i].NganHang.SoTaiKhoan;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Du lieu nguoi loi: " + e.Message);
            }
        }
        private static void VietXe(List<Xe> danhSachXe, Worksheet bangTinh)
        {
            try
            {
                for (int i = 0, hang = 3; i < danhSachXe.Count; i++, hang++)
                {
                    bangTinh.Cells[hang, 1].Value = danhSachXe[i].ChuXe.NganHang.SoTaiKhoan;
                    bangTinh.Cells[hang, 2].Value = danhSachXe[i].HangXe;
                    bangTinh.Cells[hang, 3].Value = danhSachXe[i].NamMua.ToString("yyyy-MM-dd");
                    bangTinh.Cells[hang, 4].Value = danhSachXe[i].KilometDaDi;
                    bangTinh.Cells[hang, 5].Value = danhSachXe[i].BaoHiem ? "Có" : "Không";
                    bangTinh.Cells[hang, 6].Value = Xe.MucDichCuaXe(danhSachXe[i].MucDich);
                    bangTinh.Cells[hang, 7].Value = danhSachXe[i].GiaThueMotNgay;
                    bangTinh.Cells[hang, 8].Value = danhSachXe[i].TienCoc;
                    bangTinh.Cells[hang, 9].Value = danhSachXe[i].GiaDenXuotXe;
                    bangTinh.Cells[hang, 10].Value = danhSachXe[i].GiaDenBeBanh;
                    bangTinh.Cells[hang, 11].Value = danhSachXe[i].GiaDenHuDen;
                    bangTinh.Cells[hang, 12].Value = danhSachXe[i].UuDai;
                    bangTinh.Cells[hang, 13].Value = danhSachXe[i].TangGia;
                    bangTinh.Cells[hang, 14].Value = danhSachXe[i].BienSoXe;
                    bangTinh.Cells[hang, 15].Value = danhSachXe[i].ChuXe.DanhSachXeDaThue[(int)Xe.PhanLoai(danhSachXe[i])].Contains(danhSachXe[i]) == true ? "Đúng" : "Sai";
                }
            }
            catch (Exception e)
            {
                throw new Exception("Loi du lieu xe: " + e.Message);
            }
        }
    }
}
