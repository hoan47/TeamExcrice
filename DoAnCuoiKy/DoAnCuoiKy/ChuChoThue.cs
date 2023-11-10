﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
{
    class ChuChoThue : ThongTinCoBan
    {
        private List<Xe>[] danhSachXe;
        public List<Xe>[] DanhSachXe { get { return danhSachXe; } }
        public ChuChoThue(string hoTen, string diaChi, string soDienThoai, DateTime ngaySinh, NganHang nganHang) 
            : base(hoTen, diaChi, soDienThoai, ngaySinh, nganHang)
        {
            KhoiTaoDanhSachXe();
        }
        
        private void KhoiTaoDanhSachXe()
        {
            danhSachXe = new List<Xe>[3];
            for (int i = 0; i < 3; i++)
            {
                danhSachXe[i] = new List<Xe>();
            }
        }
        public void ThemXe(Xe xe)
        {
            if (xe is XeMay)
            {
                if (danhSachXe[(int)Xe.EPhanLoai.XeMay].Contains(xe) == false)
                {
                    danhSachXe[(int)Xe.EPhanLoai.XeMay].Add(xe);
                }
            }
            else if (xe is XeBonCho)
            {
                if (danhSachXe[(int)Xe.EPhanLoai.XeBonCho].Contains(xe) == false)
                {
                    danhSachXe[(int)Xe.EPhanLoai.XeBonCho].Add(xe);
                }
            }
            else
            {
                if (danhSachXe[(int)Xe.EPhanLoai.XeBayCho].Contains(xe) == false)
                {
                    danhSachXe[(int)Xe.EPhanLoai.XeBayCho].Add(xe);
                }
            }
        }
        public List<Xe> TimXe(Xe.EPhanLoai loaiXe, decimal giaTu, decimal giaDen)
        {
            List<Xe> danhSachXeTimDuoc = new List<Xe>();

            Console.WriteLine("Ket qua tim kiem: ");
            foreach (Xe xe in danhSachXe[(int)loaiXe])
            {
                if (giaTu <= xe.GiaThueMotNgay && xe.GiaThueMotNgay <= giaDen)
                {
                    Console.WriteLine("\nXe thu: " + (danhSachXeTimDuoc.Count + 1).ToString());
                    xe.XuatThongTinXe();
                    danhSachXeTimDuoc.Add(xe);
                }
            }
            Console.WriteLine("\nSo xe tim duoc nam trong muc gia [" + giaTu.ToString() + ";  " 
                + giaDen.ToString()  + "] la: " + danhSachXeTimDuoc.Count);
            return danhSachXeTimDuoc;
        }
    }
}