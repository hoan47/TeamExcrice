using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

namespace DoAnCuoiKy
{
    static class FileXe
    {
        const string duongDanDauVao = "Input.xlsx";
        const string duongDanDauRa = "Output.xlsx";
        static public void Doc(List<NganHang> danhSachNganHang, List<ChuChoThue> danhSachChuXe, List<TaiXe> danhSachTaiXe, List<KhachThueXe> danhSachKhachThueXe, List<Xe> danhSachXe)
        {
            Application excel = null;
            Workbook trang = null;
            try
            {
                string thuMuc = AppDomain.CurrentDomain.BaseDirectory;
                string duongDan = Path.Combine(thuMuc, duongDanDauVao);

                excel = new Application();
                trang = excel.Workbooks.Open(duongDan);
                Worksheet bangTinh = trang.Sheets[1];
                string duLieu = string.Empty;
                DateTime ngayThangNam;
                Xe.EMucDich mucDich;
                NganHang nganHang;

                for (int i = 1; i < bangTinh.UsedRange.Rows.Count + 1; i++)
                {
                    i = i + 2;
                    switch (bangTinh.Cells[i - 2, 1].Text)
                    {
                        case "Ngân hàng":
                            duLieu = "Ngân hàng";
                            break;
                        case "Chủ cho thuê":
                            duLieu = "Chủ cho thuê";
                            break;
                        case "Tài xế":
                            duLieu = "Tài xế";
                            break;
                        case "Khách thuê xe":
                            duLieu = "Khách thuê xe";
                            break;
                        case "Xe máy":
                            duLieu = "Xe máy";
                            break;
                        case "Xe bốn chỗ":
                            duLieu = "Xe bốn chỗ";
                            break;
                        case "Xe bảy chỗ":
                            duLieu = "Xe bảy chỗ";
                            break;
                        case "":
                            i = i - 2;
                            duLieu = string.Empty;
                            continue;
                        default:
                            i = i - 2;
                            break;
                    }
                    switch (duLieu.Trim())
                    {
                        case "Ngân hàng":
                            danhSachNganHang.Add(new NganHang((string)bangTinh.Cells[i, 1].Text, Convert.ToDecimal(bangTinh.Cells[i, 2].Value)));
                            break;
                        case "Chủ cho thuê":
                        case "Tài xế":
                        case "Khách thuê xe":
                            nganHang = danhSachNganHang.Find(x => x.SoTaiKhoan == bangTinh.Cells[i, 5].Text);
                            DateTime.TryParse(bangTinh.Cells[i, 4].Text, out ngayThangNam);
                            switch (duLieu)
                            {
                                case "Chủ cho thuê":
                                    danhSachChuXe.Add(new ChuChoThue(bangTinh.Cells[i, 1].Text, bangTinh.Cells[i, 2].Text, bangTinh.Cells[i, 3].Text, ngayThangNam, nganHang));
                                    break;
                                case "Tài xế":
                                    danhSachTaiXe.Add(new TaiXe(bangTinh.Cells[i, 1].Text, bangTinh.Cells[i, 2].Text, bangTinh.Cells[i, 3].Text, ngayThangNam, nganHang));
                                    break;
                                case "Khách thuê xe":
                                    danhSachKhachThueXe.Add(new KhachThueXe(bangTinh.Cells[i, 1].Text, bangTinh.Cells[i, 2].Text, bangTinh.Cells[i, 3].Text, ngayThangNam, nganHang));
                                    break;
                            }
                            break;
                        case "Xe máy":
                        case "Xe bốn chỗ":
                        case "Xe bảy chỗ":
                            ChuChoThue chuChoThue = danhSachChuXe.Find(x => x.NganHang.SoTaiKhoan == bangTinh.Cells[i, 1].Text);
                            DateTime.TryParse(bangTinh.Cells[i, 3].Text, out ngayThangNam);
                            switch (bangTinh.Cells[i, 6].Text)
                            {
                                case "Du lịch":
                                    mucDich = Xe.EMucDich.DuLich;
                                    break;
                                case "Đám cưới":
                                    mucDich = Xe.EMucDich.DamCuoi;
                                    break;
                                case "Tập lái":
                                    mucDich = Xe.EMucDich.TapLai;
                                    break;
                                default:
                                    mucDich = Xe.EMucDich.Khac;
                                    break;
                            }
                            switch (duLieu)
                            {
                                case "Xe máy":
                                    danhSachXe.Add(new XeMay(chuChoThue, bangTinh.Cells[i, 2].Text, ngayThangNam, Convert.ToDouble(bangTinh.Cells[i, 4].Value),
                                        bangTinh.Cells[i, 5].Text == "Có" ? true : false, mucDich, Convert.ToDecimal(bangTinh.Cells[i, 7].Value),
                                        Convert.ToDecimal(bangTinh.Cells[i, 8].Value), Convert.ToDecimal(bangTinh.Cells[i, 9].Value),
                                        Convert.ToDecimal(bangTinh.Cells[i, 10].Value), Convert.ToDecimal(bangTinh.Cells[i, 11].Value),
                                        Convert.ToDecimal(bangTinh.Cells[i, 12].Value), Convert.ToDecimal(bangTinh.Cells[i, 13].Value)));
                                    break;
                                case "Xe bốn chỗ":
                                    danhSachXe.Add(new XeBonCho(chuChoThue, bangTinh.Cells[i, 2].Text, ngayThangNam, Convert.ToDouble(bangTinh.Cells[i, 4].Value),
                                        bangTinh.Cells[i, 5].Text == "Có" ? true : false, mucDich, Convert.ToDecimal(bangTinh.Cells[i, 7].Value),
                                        Convert.ToDecimal(bangTinh.Cells[i, 8].Value), Convert.ToDecimal(bangTinh.Cells[i, 9].Value),
                                        Convert.ToDecimal(bangTinh.Cells[i, 10].Value), Convert.ToDecimal(bangTinh.Cells[i, 11].Value),
                                        Convert.ToDecimal(bangTinh.Cells[i, 12].Value), Convert.ToDecimal(bangTinh.Cells[i, 13].Value)));
                                    break;
                                case "Xe bảy chỗ":
                                    danhSachXe.Add(new XeBayCho(chuChoThue, bangTinh.Cells[i, 2].Text, ngayThangNam, Convert.ToDouble(bangTinh.Cells[i, 4].Value),
                                        bangTinh.Cells[i, 5].Text == "Có" ? true : false, mucDich, Convert.ToDecimal(bangTinh.Cells[i, 7].Value),
                                        Convert.ToDecimal(bangTinh.Cells[i, 8].Value), Convert.ToDecimal(bangTinh.Cells[i, 9].Value),
                                        Convert.ToDecimal(bangTinh.Cells[i, 10].Value), Convert.ToDecimal(bangTinh.Cells[i, 11].Value),
                                        Convert.ToDecimal(bangTinh.Cells[i, 12].Value), Convert.ToDecimal(bangTinh.Cells[i, 13].Value)));
                                    break;
                            }
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Error input: " + e);
                throw;
            }
            finally
            {
                trang?.Close();
                excel?.Quit();
            }
        }
        static public void Viet(List<ChuChoThue> danhSachChuXe)
        {
            Application excel = null;
            Workbook trang = null;

            try
            {
                string thuMuc = AppDomain.CurrentDomain.BaseDirectory;
                string duongDan = Path.Combine(thuMuc, duongDanDauRa);

                excel = new Application();
                trang = excel.Workbooks.Add();
                Worksheet bangTinh = (Worksheet)trang.Sheets[1];
                int hang = 1;
                string[] duLieuChuChoThue = { "Họ tên", "Địa chỉ", "Số điện thoại", "Ngày sinh", "Ngân hàng" };

                bangTinh.Cells[hang, 1].Value = "Danh sách chủ cho thuê.";
                bangTinh.Cells[hang++, 1].Interior.Color = XlRgbColor.rgbDarkGrey;
                foreach (ChuChoThue chuXe in danhSachChuXe)
                {
                    for (int i = 1; i <= duLieuChuChoThue.Length; i++)
                    {
                        bangTinh.Cells[hang, i].Value = duLieuChuChoThue[i - 1];
                        bangTinh.Cells[hang, i].Interior.Color = XlRgbColor.rgbPaleTurquoise;
                    }
                    hang++;
                    bangTinh.Cells[hang, 1].Value = chuXe.HoTen;
                    bangTinh.Cells[hang, 1].Interior.Color = XlRgbColor.rgbDarkOrange;
                    bangTinh.Cells[hang, 2].Value = chuXe.DiaChi;
                    bangTinh.Cells[hang, 3].Value = chuXe.SoDienThoai;
                    bangTinh.Cells[hang, 4].Value = chuXe.NgaySinh.ToString("dd/MM/yyyy");
                    bangTinh.Cells[hang++, 5].Value = chuXe.NganHang.SoTaiKhoan;
                    hang = VietXe(bangTinh, hang, chuXe, Xe.EPhanLoai.XeMay, "xe máy");
                    hang = VietXe(bangTinh, hang, chuXe, Xe.EPhanLoai.XeBonCho, "xe bốn chỗ");
                    hang = VietXe(bangTinh, hang, chuXe, Xe.EPhanLoai.XeBayCho, "xe bảy chỗ") + 1;
                }
                bangTinh.UsedRange.Columns.AutoFit();
                bangTinh.SaveAs(duongDan);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Error output: " + e);
                throw;
            }
            finally
            {
                trang?.Close();
                excel?.Quit();
            }
        }
        private static int VietXe(Worksheet bangTinh, int hang, ChuChoThue chuXe, Xe.EPhanLoai phanLoai, string loaiXe)
        {
            string[] duLieuXe = { "Hãng xe", "Năm mua", "Số kilomet Đã đi", "Bảo hiểm", "Mục đích", "Giá thuê một ngày", "Tiền cọc", "Giá đền xức xe", "Giá đền bể bánh", "Giá đền hư đèn", "Ưu đãi", "Tăng giá" };

            if (chuXe.DanhSachXe[(int)phanLoai].Count == 0)
            {
                return hang++;
            }
            for (int i = 2; i <= duLieuXe.Length + 1; i++)
            {
                bangTinh.Cells[hang, i].Value = duLieuXe[i - 2];
                bangTinh.Cells[hang, i].Interior.Color = XlRgbColor.rgbYellowGreen;
            }
            bangTinh.Cells[hang, 1] = "Danh sách " + chuXe.DanhSachXe[(int)phanLoai].Count.ToString() + ' ' + loaiXe + " của " + chuXe.HoTen;
            bangTinh.Cells[hang++, 1].Interior.Color = XlRgbColor.rgbPaleGoldenrod;
            foreach (Xe xe in chuXe.DanhSachXe[(int)phanLoai])
            {
                bangTinh.Cells[hang, 2].Value = xe.HangXe;
                bangTinh.Cells[hang, 3].Value = xe.NamMua.ToString("dd/MM/yyyy");
                bangTinh.Cells[hang, 4].Value = xe.KilometDaDi;
                bangTinh.Cells[hang, 5].Value = xe.BaoHiem ? "Có" : "Không";
                switch (xe.MucDich)
                {
                    case Xe.EMucDich.DamCuoi:
                        bangTinh.Cells[hang, 6].Value = "Đám cưới";
                        break;
                    case Xe.EMucDich.DuLich:
                        bangTinh.Cells[hang, 6].Value = "Du lịch";
                        break;
                    case Xe.EMucDich.TapLai:
                        bangTinh.Cells[hang, 6].Value = "Tập lái";
                        break;
                    default:
                        bangTinh.Cells[hang, 6].Value = "Khác";
                        break;
                }
                bangTinh.Cells[hang, 7].Value = xe.GiaThueMotNgay;
                bangTinh.Cells[hang, 8].Value = xe.TienCoc;
                bangTinh.Cells[hang, 9].Value = xe.GiaDenXuotXe;
                bangTinh.Cells[hang, 10].Value = xe.GiaDenBeBanh;
                bangTinh.Cells[hang, 11].Value = xe.GiaDenHuDen;
                bangTinh.Cells[hang, 12].Value = xe.UuDai;
                bangTinh.Cells[hang++, 13].Value = xe.TangGia;
            }
            return hang;
        }
    }
}
