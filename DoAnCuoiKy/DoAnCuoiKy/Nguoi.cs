﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
{
    class Nguoi
    {
        protected string hoTen;
        protected string diaChi;
        protected string soDienThoai;
        protected DateTime ngaySinh;
        protected NganHang nganHang;
        public Nguoi(string hoTen, string diaChi, string soDienThoai, DateTime ngaySinh, NganHang nganHang)
        {
            this.hoTen = hoTen;
            this.diaChi = diaChi;
            this.soDienThoai = soDienThoai;
            this.ngaySinh = ngaySinh;
            this.nganHang = nganHang;
        }
        public NganHang NganHang
        {
            get { return nganHang; }
            private set { }
        }
        public virtual void DanhGia()
        {

        }
    }
}
