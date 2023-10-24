using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi
{
    public class NguoiThue : Nguoi
    {
        private string ngheNghiep;

        public NguoiThue(string ten, bool laNam, int tuoi, string diaChi, string soCMND, string soDT, 
            string ngheNghiep)
            : base(ten, laNam, tuoi, diaChi, soCMND, soDT)
        {
            this.ngheNghiep = ngheNghiep;
        }
    }
}
