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
    internal class Excel
    {
        const string tenThuMucDauVao = "Input";
    
        public static void KhoiTao(out Application excel, out Workbook trang, out Worksheet bangTinh, string tenDuongDan)
        {
            excel = new Application();
            trang = excel.Workbooks.Open(DuongDan(tenThuMucDauVao, tenDuongDan));
            bangTinh = trang.Sheets[1];
        }
        public static void LuuDuLieu(Worksheet bangTinh, string tenThuMuc)
        {
            bangTinh.UsedRange.Columns.AutoFit();
            bangTinh.UsedRange.Rows.AutoFit();
            bangTinh.SaveAs(DuongDan(tenThuMucDauVao, tenThuMuc));
        }
        public static string DuongDan(string thuMuc, string tenFile)
        {
            thuMuc = AppDomain.CurrentDomain.BaseDirectory + thuMuc;
            string duongDan = Path.Combine(thuMuc, tenFile);
            return duongDan;
        }
        public static void Dong(Application excel, Workbook trang)
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
    }
}
