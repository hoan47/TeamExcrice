using DoAnCuoiKy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnDamCuoiKy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<NganHang> danhSachNganHang = new List<NganHang>();
            List<ChuChoThue> danhSachChuChoThue = new List<ChuChoThue>();
            List<Xe> danhSachXe = new List<Xe>();

            FileXe.Read(danhSachNganHang, danhSachChuChoThue, danhSachXe);

            FileXe.Write(danhSachChuChoThue);

        }
    }
}
