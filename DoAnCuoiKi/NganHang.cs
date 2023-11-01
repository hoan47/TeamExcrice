using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi
{
    class NganHang
    {
        private string soTaiKhoan;
        private decimal soDu;

        public NganHang(string soTaiKhoan, decimal soDu)
        {
            this.soTaiKhoan = soTaiKhoan;
            this.soDu = soDu;
        }
        public bool ChuyenTien(NganHang nguoiNhan, decimal tien)
        {
            if (soDu >= tien)
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
