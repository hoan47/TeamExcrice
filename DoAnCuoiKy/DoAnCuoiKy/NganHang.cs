using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
{
    internal class NganHang
    {
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
            Worksheet bangTinh = Excel.BangTinh(Excel.ELoaiDuLieu.NganHang);

            List<NganHang> danhSachNganHang = null;
            try
            {
                danhSachNganHang = new List<NganHang>();
                for (int i = 3; bangTinh.Cells[i, 1].Value != null; i++)
                {
                    danhSachNganHang.Add(new NganHang((string)bangTinh.Cells[i, 1].Text, Convert.ToDecimal(bangTinh.Cells[i, 2].Value)));
                }
            }
            catch (Exception e)
            {
                throw new Exception("Du lieu ngan hang loi: " + e.Message);
            }
            return danhSachNganHang;
        }
    }
}
