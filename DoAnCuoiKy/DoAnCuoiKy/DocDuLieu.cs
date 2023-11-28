using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
{
    internal static class DocDuLieu
    {
        static public void DocDuLieuNganHang()
        {
            try
            {
                for (int i = 3; Excel.bangTinh[(int)Excel.ELoaiDuLieu.NganHang].Cells[i, 1].Value != null; i++)
                {
                    DuLieu.danhSachNganHang.Add(new NganHang((string)Excel.bangTinh[(int)Excel.ELoaiDuLieu.NganHang].Cells[i, 1].Text, Convert.ToDecimal(Excel.bangTinh[(int)Excel.ELoaiDuLieu.NganHang].Cells[i, 2].Value)));
                }
            }
            catch (Exception e)
            {
                throw new Exception("Du lieu ngan hang loi: " + e.Message);
            }
        }
        static public void DocDuLieuChuXe()
        {
            DocNguoi(DuLieu.danhSachChuXe, null, null, DuLieu.danhSachNganHang, Excel.bangTinh[(int)Excel.ELoaiDuLieu.ChuXe]);
        }
        static public void DocDuLieuTaiXe()
        {
            DocNguoi(null, DuLieu.danhSachTaiXe, null, DuLieu.danhSachNganHang, Excel.bangTinh[(int)Excel.ELoaiDuLieu.TaiXe]);
        }
        static public void DocDuLieuKhachThueXe()
        {
            DocNguoi(null, null, DuLieu.danhSachKhachThueXe, DuLieu.danhSachNganHang, Excel.bangTinh[(int)Excel.ELoaiDuLieu.KhachThueXe]);
        }
        public static void DocDuLieuXeMay()
        {
            DocXe(DuLieu.danhSachXeMay, null, null, DuLieu.danhSachChuXe, Excel.bangTinh[(int)Excel.ELoaiDuLieu.XeMay]);
        }
        public static void DocDuLieuXeBonCho()
        {
            DocXe(null, DuLieu.danhSachXeBonCho, null, DuLieu.danhSachChuXe, Excel.bangTinh[(int)Excel.ELoaiDuLieu.XeBonCho]);
        }
        public static void DocDuLieuXeBayCho()
        {
            DocXe(null, null, DuLieu.danhSachXeBayCho, DuLieu.danhSachChuXe, Excel.bangTinh[(int)Excel.ELoaiDuLieu.XeBayCho]);
        }
        public static void DocDuLieuHopDong()
        {
            try
            {
                DateTime ngayThangNam;

                for (int i = 3; Excel.bangTinh[(int)Excel.ELoaiDuLieu.HopDong].Cells[i, 1].Value != null; i++)
                {
                    DateTime.TryParse(Excel.bangTinh[(int)Excel.ELoaiDuLieu.HopDong].Cells[i, 6].Text, out ngayThangNam);
                    ChuXe chuXe = DuLieu.danhSachChuXe.Find(chu => chu.NganHang.SoTaiKhoan == Excel.bangTinh[(int)Excel.ELoaiDuLieu.HopDong].Cells[i, 1].Text);
                    TaiXe taiXe = Excel.bangTinh[(int)Excel.ELoaiDuLieu.HopDong].Cells[i, 2].Text == "Không có tài xế" ? null : DuLieu.danhSachTaiXe.Find(tai => tai.NganHang.SoTaiKhoan == Excel.bangTinh[(int)Excel.ELoaiDuLieu.HopDong].Cells[i, 2].Text);
                    KhachThueXe khachThueXe = DuLieu.danhSachKhachThueXe.Find(khach => khach.NganHang.SoTaiKhoan == Excel.bangTinh[(int)Excel.ELoaiDuLieu.HopDong].Cells[i, 3].Text);
                    Xe xeChoThue = null;

                    foreach (List<Xe> danhSach in chuXe.DanhSachXeChuaThue)
                    {
                        xeChoThue = danhSach.Find(xe => xe.BienSoXe == Excel.bangTinh[(int)Excel.ELoaiDuLieu.HopDong].Cells[i, 4].Text);
                        if (xeChoThue != null)
                        {
                            break;
                        }
                    }
                    decimal soDu = khachThueXe.NganHang.SoDu;
                    NganHang nganHang = new NganHang("ACB", decimal.MaxValue);

                    nganHang.ChuyenTien(khachThueXe.NganHang, decimal.MaxValue - soDu);
                    HopDongThueXe hopDong = new HopDongThueXe(chuXe, taiXe, khachThueXe, xeChoThue, Convert.ToInt32(Excel.bangTinh[(int)Excel.ELoaiDuLieu.HopDong].Cells[i, 5].Value), ngayThangNam);
                    khachThueXe.NganHang.ChuyenTien(nganHang, decimal.MaxValue - soDu - hopDong.ThanhToan());
                    DuLieu.danhSachHopDongThueXe.Add(hopDong);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Loi du lieu hop dong: " + e.Message);
            }
        }
        private static void DocNguoi(List<ChuXe> danhSachChuXe, List<TaiXe> danhSachTaiXe, List<KhachThueXe> danhSachKhachThueXe, List<NganHang> danhSachNganHang, Worksheet bangTinh)
        {
            try
            {
                DateTime ngayThangNam;

                for (int i = 3; bangTinh.Cells[i, 1].Value != null; i++)
                {
                    DateTime.TryParse(bangTinh.Cells[i, 4].Text, out ngayThangNam);
                    if (danhSachChuXe != null)
                    {
                        danhSachChuXe.Add(new ChuXe(bangTinh.Cells[i, 1].Text, bangTinh.Cells[i, 2].Text, bangTinh.Cells[i, 3].Text, ngayThangNam, danhSachNganHang.Find(nganHang => nganHang.SoTaiKhoan == bangTinh.Cells[i, 5].Text)));
                    }
                    else if (danhSachTaiXe != null)
                    {
                        danhSachTaiXe.Add(new TaiXe(bangTinh.Cells[i, 1].Text, bangTinh.Cells[i, 2].Text, bangTinh.Cells[i, 3].Text, ngayThangNam, danhSachNganHang.Find(nganHang => nganHang.SoTaiKhoan == bangTinh.Cells[i, 5].Text)));
                    }
                    else
                    {
                        danhSachKhachThueXe.Add(new KhachThueXe(bangTinh.Cells[i, 1].Text, bangTinh.Cells[i, 2].Text, bangTinh.Cells[i, 3].Text, ngayThangNam, danhSachNganHang.Find(nganHang => nganHang.SoTaiKhoan == bangTinh.Cells[i, 5].Text)));
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Du lieu nguoi loi: " + e.Message);
            }
        }
        private static void DocXe(List<XeMay> danhSachXeMay, List<XeBonCho> danhSachXeBonCho, List<XeBayCho> danhSachXeBayCho, List<ChuXe> danhSachChuXe, Worksheet bangTinh)
        {
            try
            {
                DateTime ngayThangNam;

                for (int i = 3; bangTinh.Cells[i, 1].Value != null; i++)
                {
                    DateTime.TryParse(bangTinh.Cells[i, 3].Text, out ngayThangNam);
                    if (danhSachXeMay != null)
                    {
                        danhSachXeMay.Add(new XeMay(danhSachChuXe.Find(x => x.NganHang.SoTaiKhoan == bangTinh.Cells[i, 1].Text), bangTinh.Cells[i, 2].Text, ngayThangNam, Convert.ToDouble(bangTinh.Cells[i, 4].Value),
                            bangTinh.Cells[i, 5].Text == "Có" ? true : false, Xe.MucDichCuaXe(bangTinh.Cells[i, 6].Text), Convert.ToDecimal(bangTinh.Cells[i, 7].Value), Convert.ToDecimal(bangTinh.Cells[i, 8].Value), Convert.ToDecimal(bangTinh.Cells[i, 9].Value),
                            Convert.ToDecimal(bangTinh.Cells[i, 10].Value), Convert.ToDecimal(bangTinh.Cells[i, 11].Value), Convert.ToDecimal(bangTinh.Cells[i, 12].Value), Convert.ToDecimal(bangTinh.Cells[i, 13].Value), bangTinh.Cells[i, 14].Text, false));
                    }
                    else if (danhSachXeBonCho != null)
                    {
                        danhSachXeBonCho.Add(new XeBonCho(danhSachChuXe.Find(x => x.NganHang.SoTaiKhoan == bangTinh.Cells[i, 1].Text), bangTinh.Cells[i, 2].Text, ngayThangNam, Convert.ToDouble(bangTinh.Cells[i, 4].Value),
                              bangTinh.Cells[i, 5].Text == "Có" ? true : false, Xe.MucDichCuaXe(bangTinh.Cells[i, 6].Text), Convert.ToDecimal(bangTinh.Cells[i, 7].Value), Convert.ToDecimal(bangTinh.Cells[i, 8].Value), Convert.ToDecimal(bangTinh.Cells[i, 9].Value),
                            Convert.ToDecimal(bangTinh.Cells[i, 10].Value), Convert.ToDecimal(bangTinh.Cells[i, 11].Value), Convert.ToDecimal(bangTinh.Cells[i, 12].Value), Convert.ToDecimal(bangTinh.Cells[i, 13].Value), bangTinh.Cells[i, 14].Text, false));
                    }
                    else
                    {
                        danhSachXeBayCho.Add(new XeBayCho(danhSachChuXe.Find(x => x.NganHang.SoTaiKhoan == bangTinh.Cells[i, 1].Text), bangTinh.Cells[i, 2].Text, ngayThangNam, Convert.ToDouble(bangTinh.Cells[i, 4].Value),
                            bangTinh.Cells[i, 5].Text == "Có" ? true : false, Xe.MucDichCuaXe(bangTinh.Cells[i, 6].Text), Convert.ToDecimal(bangTinh.Cells[i, 7].Value), Convert.ToDecimal(bangTinh.Cells[i, 8].Value), Convert.ToDecimal(bangTinh.Cells[i, 9].Value),
                            Convert.ToDecimal(bangTinh.Cells[i, 10].Value), Convert.ToDecimal(bangTinh.Cells[i, 11].Value), Convert.ToDecimal(bangTinh.Cells[i, 12].Value), Convert.ToDecimal(bangTinh.Cells[i, 13].Value), bangTinh.Cells[i, 14].Text, false));
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Loi du lieu xe: " + e.Message);
            }
        }
    }
}
