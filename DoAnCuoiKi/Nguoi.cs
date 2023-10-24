using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi
{
    public class Nguoi
    {
        protected string ten;
        protected bool laNam;
        protected int tuoi;
        protected string diaChi;
        protected string soCMND;
        protected string soDT;

        public Nguoi(string ten, bool laNam, int tuoi, string diaChi, string soCMND, string soDT)
        {
            this.ten = ten;
            this.laNam = laNam;
            this.tuoi = tuoi;
            this.diaChi = diaChi;
            this.soCMND = soCMND;
            this.soDT = soDT;
        }
    }
}
