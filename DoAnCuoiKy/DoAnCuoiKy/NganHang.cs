using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
{
    public class NganHang
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
    }
}
