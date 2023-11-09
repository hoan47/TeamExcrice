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

                for (int i = 1; i < hangToiDa; i++)
                {
                    switch (bangTinh.Cells[i, 1].Text)
                    {
                        case "Ngân hàng":
                            duLieu = "Ngân hàng";
                            i = i + 2;
                            break;
                        case "Chủ cho thuê":
                            duLieu = "Chủ cho thuê";
                            i = i + 2;
                            break;
                    }
                    switch (duLieu)
                    {
                        case "Ngân hàng":
                            danhSachNganHang.Add(new NganHang((string)bangTinh.Cells[i, 1].Text, Convert.ToDecimal(bangTinh.Cells[i, 2].Value)));
                            break;
                        case "Chủ cho thuê":
                            NganHang nganHang = null;
                            foreach (NganHang nganHang_ in danhSachNganHang)
                            {
                                if (bangTinh.Cells[i, 5].Text == nganHang_.SoTaiKhoan)
                                {
                                    nganHang = nganHang_;
                                    break;
                                }
                            }
                            DateTime ngaySinh;

                            DateTime.TryParse(bangTinh.Cells[i, 4].Text, out ngaySinh);
                            danhSachChuXe.Add(new ChuChoThue(bangTinh.Cells[i, 1].Text, bangTinh.Cells[i, 2].Text, bangTinh.Cells[i, 3].Text, ngaySinh, nganHang));
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
