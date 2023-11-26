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

        static Excel()
        {
            excel = new Application();
            trang = excel.Workbooks.Open(DuongDan(duongDan));
            bangTinh = new Worksheet[trang.Sheets.Count];
            for(int i = 1; i <= trang.Sheets.Count; i++)
            {
                bangTinh[i - 1] = trang.Sheets[i]; 
            }
        }
        public static void KhoiTaoExcel() { }
        static public void LuuToanBoDuLieu()
        {
            for (int i = 0; i < trang.Sheets.Count; i++)
            {
                XoaHang(bangTinh[i]);
            }
            VietDuLieu.VietDuLieuNganHang();
            VietDuLieu.VietDuLieuChuXe();
            VietDuLieu.VietDuLieuTaiXe();
            VietDuLieu.VietDuLieuKhachThueXe();
            VietDuLieu.VietDuLieuXeMay();
            VietDuLieu.VietDuLieuXeBonCho();
            VietDuLieu.VietDuLieuXeBayCho();
            VietDuLieu.VietDuLieuHopDongThueXe();
            for (int i = 0; i < trang.Sheets.Count; i++)
            {
                LuuDuLieu(bangTinh[i]);
            }
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
        private static void LuuDuLieu(Worksheet bangTinh)
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
        private static void XoaHang(Worksheet bangTinh)
        {
            int lastRow = bangTinh.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Row;

            for (int i = lastRow; i >= 3; i--)
            {
                Range hangXoa = (Range)bangTinh.Rows[i, Type.Missing];
                hangXoa.Delete(Type.Missing);
                Marshal.ReleaseComObject(hangXoa);
            }
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
            DanhGiaNguoi = 8,
            DanhGiaXe = 9
        }
    }
}
