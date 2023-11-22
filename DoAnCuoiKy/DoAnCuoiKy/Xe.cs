﻿using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DoAnCuoiKy
{
    internal class Xe
    {
        private ChuXe chuXe;
        private string hangXe;
        private DateTime namMua;
        private double kilometDaDi;
        private bool baoHiem;
        private EMucDich mucDich;
        private decimal giaThueMotNgay;
        private decimal tienCoc;
        private decimal giaDenXuotXe;
        private decimal giaDenBeBanh;
        private decimal giaDenHuDen;
        private decimal uuDai;
        private decimal tangGia;
        private QuanLyDanhGia danhGia;
        private bool daThue;
        public ChuXe ChuXe { get { return chuXe; } }
        public string HangXe { get { return hangXe; } }
        public DateTime NamMua { get { return namMua; } }
        public double KilometDaDi { get { return kilometDaDi; } }
        public bool BaoHiem { get { return baoHiem; } }
        public EMucDich MucDich { get { return mucDich; } }
        public decimal GiaThueMotNgay { get { return giaThueMotNgay; } }
        public decimal TienCoc { get { return tienCoc; } }
        public decimal GiaDenXuotXe { get { return giaDenXuotXe; } }
        public decimal GiaDenBeBanh { get { return giaDenBeBanh; } }
        public decimal GiaDenHuDen { get { return giaDenHuDen; } }

        internal void DocDuLieu(List<XeBonCho> danhSachXeBonCho)
        {
            throw new NotImplementedException();
        }

        public decimal UuDai { get { return uuDai; } }
        public decimal TangGia { get { return tangGia; } }
        public QuanLyDanhGia DanhGia { get { return danhGia; } }
        public bool DaThue { get { return daThue; } }

        public Xe(ChuXe chuXe, string hangXe, DateTime namMua, double kilometDaDi, bool baoHiem, EMucDich mucDich, decimal giaThueMotNgay, decimal tienCoc, decimal giaDenXuotXe, decimal giaDenBeBanh, decimal giaDenHuDen, decimal uuDai, decimal tangGia)
        {
            this.chuXe = chuXe;
            this.hangXe = hangXe;
            this.namMua = namMua;
            this.kilometDaDi = kilometDaDi;
            this.baoHiem = baoHiem;
            this.mucDich = mucDich;
            this.giaThueMotNgay = giaThueMotNgay;
            this.tienCoc = tienCoc;
            this.giaDenXuotXe = giaDenXuotXe;
            this.giaDenBeBanh = giaDenBeBanh;
            this.giaDenHuDen = giaDenHuDen;
            this.uuDai = uuDai;
            this.tangGia = tangGia;
            this.chuXe.ThemXe(this);
            danhGia = new QuanLyDanhGia();
            daThue = false;
        }
        public void DaThueXe()
        {
            daThue = true;
        }
        public void TraXe()
        {
            daThue = false;
        }
        public virtual void XuatThongTinXe()
        {
            Console.WriteLine("Hang xe: " + HangXe);
            Console.WriteLine("Nam mua: " + NamMua.ToString("dd/MM/yyyy"));
            Console.WriteLine("So kilomet: " + KilometDaDi);
            Console.WriteLine("Muc dich: " + MucDich);
            Console.WriteLine("Gia: " + GiaThueMotNgay);
            Console.WriteLine();
        }
        static protected EMucDich MucDichCuaXe(string duLieu)
        {
            switch (duLieu)
            {
                case "Du lịch":
                    return EMucDich.DuLich;
                case "Đám cưới":
                    return EMucDich.DamCuoi;
                case "Tập lái":
                    return EMucDich.TapLai;
                default:
                    return EMucDich.Khac;
            }
        }
        static public void XuatDanhSachXe(List<Xe> danhSachXe, bool daThue)
        {
            int soThuTu = 1;
            foreach (Xe xe in danhSachXe)
            {
                if (xe.daThue == daThue)
                {
                    Console.WriteLine("So thu tu: " + soThuTu++.ToString());
                    xe.XuatThongTinXe();
                }
            }
        }
        static protected void DocDuLieu(List<XeMay> danhSachXeMay, List<XeBonCho> danhSachXeBonCho, List<XeBayCho> danhSachXeBayCho, List<ChuXe> danhSachChuXe, string duongDanDuLieu)
        {
            Application excel = null;
            Workbook trang = null;
            Worksheet bangTinh;

            try
            {
                Excel.KhoiTao(out excel, out trang, out bangTinh, duongDanDuLieu);
                DateTime ngayThangNam;

                for (int i = 3; bangTinh.Cells[i, 1].Value != null; i++)
                {
                    DateTime.TryParse(bangTinh.Cells[i, 3].Text, out ngayThangNam);
                    if (danhSachXeMay != null)
                    {
                        danhSachXeMay.Add(new XeMay(danhSachChuXe.Find(x => x.NganHang.SoTaiKhoan == bangTinh.Cells[i, 1].Text), bangTinh.Cells[i, 2].Text, ngayThangNam, Convert.ToDouble(bangTinh.Cells[i, 4].Value),
                            bangTinh.Cells[i, 5].Text == "Có" ? true : false, MucDichCuaXe(bangTinh.Cells[i, 6].Text), Convert.ToDecimal(bangTinh.Cells[i, 7].Value), Convert.ToDecimal(bangTinh.Cells[i, 8].Value), Convert.ToDecimal(bangTinh.Cells[i, 9].Value),
                            Convert.ToDecimal(bangTinh.Cells[i, 10].Value), Convert.ToDecimal(bangTinh.Cells[i, 11].Value), Convert.ToDecimal(bangTinh.Cells[i, 12].Value), Convert.ToDecimal(bangTinh.Cells[i, 13].Value)));
                    }
                    else if (danhSachXeBonCho != null)
                    {
                        danhSachXeBonCho.Add(new XeBonCho(danhSachChuXe.Find(x => x.NganHang.SoTaiKhoan == bangTinh.Cells[i, 1].Text), bangTinh.Cells[i, 2].Text, ngayThangNam, Convert.ToDouble(bangTinh.Cells[i, 4].Value),
                              bangTinh.Cells[i, 5].Text == "Có" ? true : false, MucDichCuaXe(bangTinh.Cells[i, 6].Text), Convert.ToDecimal(bangTinh.Cells[i, 7].Value), Convert.ToDecimal(bangTinh.Cells[i, 8].Value), Convert.ToDecimal(bangTinh.Cells[i, 9].Value),
                            Convert.ToDecimal(bangTinh.Cells[i, 10].Value), Convert.ToDecimal(bangTinh.Cells[i, 11].Value), Convert.ToDecimal(bangTinh.Cells[i, 12].Value), Convert.ToDecimal(bangTinh.Cells[i, 13].Value)));
                    }
                    else
                    {
                        danhSachXeBayCho.Add(new XeBayCho(danhSachChuXe.Find(x => x.NganHang.SoTaiKhoan == bangTinh.Cells[i, 1].Text), bangTinh.Cells[i, 2].Text, ngayThangNam, Convert.ToDouble(bangTinh.Cells[i, 4].Value),
                            bangTinh.Cells[i, 5].Text == "Có" ? true : false, MucDichCuaXe(bangTinh.Cells[i, 6].Text), Convert.ToDecimal(bangTinh.Cells[i, 7].Value),  Convert.ToDecimal(bangTinh.Cells[i, 8].Value), Convert.ToDecimal(bangTinh.Cells[i, 9].Value),
                            Convert.ToDecimal(bangTinh.Cells[i, 10].Value), Convert.ToDecimal(bangTinh.Cells[i, 11].Value), Convert.ToDecimal(bangTinh.Cells[i, 12].Value), Convert.ToDecimal(bangTinh.Cells[i, 13].Value)));
                    }
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Loi du lieu xe: " + e.Message);
            }
            finally
            {
                Excel.Dong(excel, trang);
            }
        }
        protected void ThemXeVaoDuLieu(ChuXe chuXe, string duongDanDuLieu)
        {
            Application excel = null;
            Workbook trang = null;
            Worksheet bangTinh;

            try
            {
                Excel.KhoiTao(out excel, out trang, out bangTinh, duongDanDuLieu);
                int hang = 1;
                while (bangTinh.Cells[hang, 1].Value != null) hang++;
                bangTinh.Cells[hang, 1].Value = chuXe.NganHang.SoTaiKhoan;
                bangTinh.Cells[hang, 2].Value = hangXe;
                bangTinh.Cells[hang, 3].Value = namMua.ToString("yyyy-MM-dd");
                bangTinh.Cells[hang, 4].Value = kilometDaDi;
                bangTinh.Cells[hang, 5].Value = baoHiem ? "Có" : "Không";
                switch (mucDich)
                {
                    case EMucDich.DamCuoi:
                        bangTinh.Cells[hang, 6].Value = "Đám cưới";
                        break;
                    case EMucDich.DuLich:
                        bangTinh.Cells[hang, 6].Value = "Du lịch";
                        break;
                    case EMucDich.TapLai:
                        bangTinh.Cells[hang, 6].Value = "Tập lái";
                        break;
                    default:
                        bangTinh.Cells[hang, 6].Value = "Khác";
                        break;
                }
                bangTinh.Cells[hang, 7].Value = giaThueMotNgay;
                bangTinh.Cells[hang, 8].Value = tienCoc;
                bangTinh.Cells[hang, 9].Value = giaDenXuotXe;
                bangTinh.Cells[hang, 10].Value = giaDenBeBanh;
                bangTinh.Cells[hang, 11].Value = giaDenHuDen;
                bangTinh.Cells[hang, 12].Value = uuDai;
                bangTinh.Cells[hang, 13].Value = tangGia;
                Excel.LuuDuLieu(bangTinh, duongDanDuLieu);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Loi du lieu xe: " + e.Message);
            }
            finally
            {
                Excel.Dong(excel, trang);
            }
        }
        protected void XoaXeTrongDuLieu(ChuXe chuXe, string duongDanDuLieu)
        {
            Application excel = null;
            Workbook trang = null;
            Worksheet bangTinh;

            try
            {
                Excel.KhoiTao(out excel, out trang, out bangTinh, duongDanDuLieu);
                int hang = 2;
                DateTime ngayThangNam;
                do
                {
                    DateTime.TryParse(bangTinh.Cells[++hang, 3].Text, out ngayThangNam);
                }
                while (bangTinh.Cells[hang][1].Text != chuXe.NganHang.SoTaiKhoan &&
                        bangTinh.Cells[hang][2].Text != HangXe &&
                        ngayThangNam != NamMua &&
                        Convert.ToDouble(bangTinh.Cells[hang][4].Text != HangXe) != kilometDaDi &&
                        bangTinh.Cells[hang][5].Text != (baoHiem == true ? "Có" : "Không") &&
                        MucDichCuaXe(bangTinh.Cells[hang][6].Text) != mucDich &&
                        Convert.ToDecimal(bangTinh.Cells[hang][7].Text != HangXe) != giaThueMotNgay &&
                        Convert.ToDecimal(bangTinh.Cells[hang][8].Text != HangXe) != tienCoc &&
                        Convert.ToDecimal(bangTinh.Cells[hang][9].Text != HangXe) != giaDenXuotXe &&
                        Convert.ToDecimal(bangTinh.Cells[hang][10].Text != HangXe) != giaDenBeBanh &&
                        Convert.ToDecimal(bangTinh.Cells[hang][11].Text != HangXe) != giaDenHuDen &&
                        Convert.ToDecimal(bangTinh.Cells[hang][12].Text != HangXe) != uuDai &&
                        Convert.ToDecimal(bangTinh.Cells[hang][13].Text != HangXe) != tangGia
                        );
                Excel.XoaHang(bangTinh, hang);
                Excel.LuuDuLieu(bangTinh, duongDanDuLieu);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Loi du lieu xe: " + e.Message);
            }
            finally
            {
                Excel.Dong(excel, trang);
            }
        }
        public enum EPhanLoai
        {
            XeMay = 0,
            XeBonCho = 1,
            XeBayCho = 2
        }
        public enum EMucDich
        {
            DuLich,
            DamCuoi,
            TapLai,
            Khac
        }
    }
}
