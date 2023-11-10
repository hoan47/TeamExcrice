﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<NganHang> danhSachNganHang = new List<NganHang>();
            List<ChuChoThue> danhSachChuChoThue = new List<ChuChoThue>();
            List<TaiXe> danhSachTaiXe = new List<TaiXe>();
            List<Xe> danhSachXe = new List<Xe>();

            FileXe.Read(danhSachNganHang, danhSachChuChoThue, danhSachTaiXe, danhSachXe);
            FileXe.Write(danhSachChuChoThue);
        }
    }
}
