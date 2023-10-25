using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi
{
    public class NguoiChoThue : Nguoi
    {
        public NguoiChoThue(string ten, bool laNam, int tuoi, string diaChi, string soCMND, string soDT)
            : base(ten, laNam, tuoi, diaChi, soCMND, soDT)
        { }
        public void ChoThuePhong(HopDongThueNha hopDong)
        {
            hopDong.ThuePhong();
        }
    }
}
