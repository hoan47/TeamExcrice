using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace DoAnCuoiKy
{
    static internal class Excel
    {
        private const string duongDan = "DuLieu.xlsx";
        public static Application excel;
        public static Workbook trang;
        public static Worksheet[] bangTinh;

        public static void MoUngDung() 
        {
            excel = new Application();
            trang = excel.Workbooks.Open(DuongDan(duongDan));
            bangTinh = new Worksheet[trang.Sheets.Count];
            for (int i = 1; i <= trang.Sheets.Count; i++)
            {
                bangTinh[i - 1] = trang.Sheets[i];
            }
        }
        public static void DongUngDung()
        {
            Console.WriteLine("Dong excel.");
            if (trang != null)
            {
                trang.Close(false);
                Marshal.FinalReleaseComObject(trang);
            }
            if (excel != null)
            {
                excel.Workbooks.Close();
                excel.Quit();
                Marshal.FinalReleaseComObject(excel);
            }
        }
        public static void LuuDuLieu()
        {
            try
            {
                for (int i = 0; i < trang.Sheets.Count; i++)
                {
                    bangTinh[i].UsedRange.Columns.AutoFit();
                    bangTinh[i].UsedRange.Rows.AutoFit();
                    bangTinh[i].SaveAs(DuongDan(duongDan));
                }
            }
            catch(Exception e)
            {
                throw new Exception("Loi luu du lieu: " + e.Message);
            }
        }
        public static void XoaDuLieu()
        {
            try
            {
                for (int i = 0; i < trang.Sheets.Count; i++)
                {
                    int lastRow = bangTinh[i].Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Row;

                    for (int j = lastRow; j >= 3; j--)
                    {
                        Range hangXoa = (Range)bangTinh[i].Rows[j, Type.Missing];
                        hangXoa.Delete(Type.Missing);
                        Marshal.ReleaseComObject(hangXoa);
                    }
                }
            }
            catch(Exception e)
            {
                throw new Exception("Loi xoa du lieu: " + e.Message);
            }
        }
        private static string DuongDan(string tenFile)
        {
            string thuMuc = AppDomain.CurrentDomain.BaseDirectory;
            return Path.Combine(thuMuc, tenFile);
        }
        public enum ELoaiDuLieu
        {
            NganHang = 0,
            ChuXe = 1,
            TaiXe = 2,
            KhachThueXe = 3,
            XeMay = 4,
            XeBonCho = 5,
            XeBayCho = 6,
            HopDong = 7,
        }
    }
}
