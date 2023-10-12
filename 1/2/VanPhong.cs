﻿using System;

namespace _2
{
    class VanPhong : NhanVien
    {
        public VanPhong(string hoTen, string ma, DateTime ngayThangNamSinh, string diaChi, float heSoLuong, DateTime ngayBatDauLamViec, int soLanDiemDanhDi, int soLanDiemDanhVe) : 
            base(hoTen, ma, ngayThangNamSinh, diaChi, heSoLuong, ngayBatDauLamViec, soLanDiemDanhDi, soLanDiemDanhVe)
        { } 

        public override void InThongTin()
        {
            Console.WriteLine("Cap bac: Van phong");
            InThongTinNhanVien();
        }
    }
}
