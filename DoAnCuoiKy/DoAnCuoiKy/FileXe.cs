using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel; 
namespace DoAnCuoiKy
{
    static class FileXe
    {
        static public void Read(List<NganHang> danhSachNganHang, List<ChuChoThue> danhSachChuXe, List<Xe> danhSachXe)
        {
            try
            {
                Excel.Application excel = new Excel.Application();
                Excel.Workbook trang = excel.Workbooks.Open(@"C:\Users\b2h16\OneDrive\Máy tính\TeamExcrice\DoAnCuoiKy\Inputs.xlsx");
                Excel.Worksheet bangTinh = trang.Sheets[1];
                int hangToiDa = bangTinh.UsedRange.Rows.Count + 1;
                int cotToiDa = bangTinh.UsedRange.Columns.Count + 1;
                string duLieu = "";
                DateTime ngayThangNam;
                Xe.EMucDich mucDich;

                for (int i = 1; i < hangToiDa; i++)
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
                        case "Xe máy":
                            duLieu = "Xe máy";
                            break;
                        case "Xe bốn chỗ":
                            duLieu = "Xe bốn chỗ";
                            break;
                        case "Xe bảy chỗ":
                            duLieu = "Xe bảy chỗ";
                            break;
                        default:
                            i = i - 2;
                            break;
                    }

                    switch (duLieu)
                    {
                        case "Ngân hàng":
                            danhSachNganHang.Add(new NganHang((string)bangTinh.Cells[i, 1].Text, Convert.ToDecimal(bangTinh.Cells[i, 2].Value)));
                            break;
                        case "Chủ cho thuê":
                            NganHang nganHang = danhSachNganHang.Find(x => x.SoTaiKhoan == bangTinh.Cells[i, 5].Text);
                            DateTime.TryParse(bangTinh.Cells[i, 4].Text, out ngayThangNam);
                            danhSachChuXe.Add(new ChuChoThue(bangTinh.Cells[i, 1].Text, bangTinh.Cells[i, 2].Text, bangTinh.Cells[i, 3].Text, ngayThangNam, nganHang));
                            break;
                        case "Xe máy":
                            ChuChoThue chuChoThue = danhSachChuXe.Find(x => x.NganHang.SoTaiKhoan == bangTinh.Cells[i, 1].Text);
                            DateTime.TryParse(bangTinh.Cells[i, 3].Text, out ngayThangNam);
                            switch(bangTinh.Cells[i, 5].Text)
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
                            danhSachXe.Add(new XeMay(chuChoThue, bangTinh.Cells[i, 2].Text, ngayThangNam, Convert.ToDouble(bangTinh.Cells[i, 4].Value), 
                                bangTinh.Cells[i, 5].Text == "Có" ? true : false, mucDich, Convert.ToDecimal(bangTinh.Cells[i, 7].Value), 
                                Convert.ToDecimal(bangTinh.Cells[i, 8].Value), Convert.ToDecimal(bangTinh.Cells[i, 9].Value), 
                                Convert.ToDecimal(bangTinh.Cells[i, 10].Value), Convert.ToDecimal(bangTinh.Cells[i, 11].Value), 
                                Convert.ToDecimal(bangTinh.Cells[i, 12].Value), Convert.ToDecimal(bangTinh.Cells[i, 13].Value)));
                            break;
                    }
                }
                trang.Close();
                excel.Quit();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Error: " + e);
            }
        }
        static public void Write()
        {

        }
    }
}
