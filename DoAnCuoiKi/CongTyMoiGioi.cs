using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi
{
    public class CongTyMoiGioi
    {
        private string tenCongTy;
        private string maSoThue;
        private string diaChi;
        private List<NguoiMoiGioi> danhSachNguoiMoiGioi;

        public CongTyMoiGioi(string tenCongTy, string maSoThue, string diaChi)
        {
            this.tenCongTy = tenCongTy;
            this.maSoThue = maSoThue;
            this.diaChi = diaChi;
            danhSachNguoiMoiGioi = new List<NguoiMoiGioi>();
        }
        public void ThemNguoiMoiGIoi(NguoiMoiGioi nguoiMoiGioi)
        {
            danhSachNguoiMoiGioi.Add(nguoiMoiGioi);
        }
    }
}
