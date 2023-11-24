using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace DoAnCuoiKy
{
    static internal class Excel
    {
        private const string duongDan = "DuLieu.xlsx";
        public static Application excel;
        public static Workbook trang;

        static Excel()
        {
            excel = new Application();
            trang = excel.Workbooks.Open(DuongDan(duongDan));
            AppDomain.CurrentDomain.ProcessExit += (_, _e) => { Dong(); };
        }
        public static Worksheet BangTinh(ELoaiDuLieu loaiDuLieu)
        {
            return trang.Sheets[(int)loaiDuLieu];
        }
        public static void LuuDuLieu(Worksheet bangTinh)
        {
            bangTinh.UsedRange.Columns.AutoFit();
            bangTinh.UsedRange.Rows.AutoFit();
            bangTinh.SaveAs(DuongDan(duongDan));
        }
        private static string DuongDan(string tenFile)
        {
            string thuMuc = AppDomain.CurrentDomain.BaseDirectory;
            return Path.Combine(thuMuc, tenFile);
        }
        private static void Dong()
        {
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
        public static void XoaHang(Worksheet bangTinh, int hang)
        {
            Range hangXoa = (Range)bangTinh.Rows[hang, Type.Missing];
            hangXoa.Delete(XlDeleteShiftDirection.xlShiftUp);
            Marshal.ReleaseComObject(hangXoa);
        }
        public enum ELoaiDuLieu
        {
            NganHang = 1,
            ChuXe = 2,
            TaiXe = 3,
            KhachThueXe = 4,
            XeMay = 5,
            XeBonCho = 6,
            XeBayCho = 7
        }
    }
}
