using System;
using System.Collections.Generic;

namespace DoAnCuoiKy
{
    internal class NganHang
    {
        public static List<string> danhSachSoTaiKhoan;
        private string soTaiKhoan;
        private decimal soDu;
        public string SoTaiKhoan { get { return soTaiKhoan; } }
        public decimal SoDu { get { return soDu; } }
        static NganHang()
        {
            danhSachSoTaiKhoan = new List<string>();
        }
        public NganHang(string soTaiKhoan, decimal soDu)
        {
            KiemTraSoTaiKhoan(soTaiKhoan);
            this.soTaiKhoan = soTaiKhoan;
            this.soDu = soDu;
        }
        public bool ChuyenTien(NganHang nguoiNhan, decimal tien)
        {
            if (soDu >= tien && tien > 0)
            {
                soDu = soDu - tien;
                nguoiNhan.NhanTien(tien);
                return true;
            }
            return false;
        }
        public static NganHang KhoiTao()
        {
            return new NganHang(DauVaoBanPhim.String("So tai khoan ngan hang: "), DauVaoBanPhim.Decimal("So du: "));
        }
        private void NhanTien(decimal tien)
        {
            soDu = soDu + tien;
        }
        private void KiemTraSoTaiKhoan(string soTaiKhoan)
        {
            if (danhSachSoTaiKhoan.Contains(soTaiKhoan) == true && soTaiKhoan != "ACB")
            {
                throw new Exception("So tai khoan da ton tai");
            }
            else
            {
                danhSachSoTaiKhoan.Add(soTaiKhoan);
            }
        }
    }
}
