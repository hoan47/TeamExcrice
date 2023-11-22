using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
{
    public class NganHang
    {
        private static string duongDanDuLieu = "DanhSachNganHang.xlsx";
        private string soTaiKhoan;
        private decimal soDu;
        public string SoTaiKhoan { get { return soTaiKhoan; } }
        public NganHang(string soTaiKhoan, decimal soDu)
        {
            this.soTaiKhoan = soTaiKhoan;
            this.soDu = soDu;
        }
        public bool ChuyenTien(NganHang nguoiNhan, decimal tien)
        {
            if (soDu >= tien && tien != 0)
            {
                soDu -= tien;
                nguoiNhan.NhanTien(tien);
                return true;
            }
            return false;
        }
        private void NhanTien(decimal tien)
        {
            soDu += -tien;
        }
        static public List<NganHang> DocDuLieu()
        {
            List<NganHang> danhSachNganHang = null;
            Application excel = null;
            Workbook trang = null;
            Worksheet bangTinh;

            try
            {
                Excel.KhoiTao(out excel, out trang, out bangTinh, duongDanDuLieu);
                danhSachNganHang = new List<NganHang>();
                for (int i = 3; bangTinh.Cells[i, 1].Value != null; i++)
                {
                    danhSachNganHang.Add(new NganHang((string)bangTinh.Cells[i, 1].Text, Convert.ToDecimal(bangTinh.Cells[i, 2].Value)));
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Du lieu ngan hang loi: " + e.Message);
            }
            finally
            {
                Excel.Dong(excel, trang);
            }
            return danhSachNganHang;
        }
    }
}
