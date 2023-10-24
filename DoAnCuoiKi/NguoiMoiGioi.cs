using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi
{
    public class NguoiMoiGioi : Nguoi
    {
        private CongTyMoiGioi congTyMoiGioi;

        public NguoiMoiGioi(string ten, bool laNam, int tuoi, string diaChi, string soCMND, string soDT, 
            CongTyMoiGioi congTyMoiGioi)
            : base(ten, laNam, tuoi, diaChi, soCMND, soDT)
        {
            this.congTyMoiGioi = congTyMoiGioi;
        }
    }
}
