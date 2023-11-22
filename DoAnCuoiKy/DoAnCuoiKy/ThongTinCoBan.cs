using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;

namespace DoAnCuoiKy
{
    internal class ThongTinCoBan
    {
        private string hoTen;
        private string diaChi;
        private string soDienThoai;
        private DateTime ngaySinh;
        private NganHang nganHang;
        public string HoTen { get { return hoTen; } }
        public string DiaChi { get { return diaChi; } }
        public string SoDienThoai { get { return soDienThoai; } }
        public DateTime NgaySinh { get { return ngaySinh; } }
        public NganHang NganHang { get { return nganHang; } }
        public ThongTinCoBan(string hoTen, string diaChi, string soDienThoai, DateTime ngaySinh, NganHang nganHang)
        {
            this.hoTen = hoTen;
            this.diaChi = diaChi;
            this.soDienThoai = soDienThoai;
            this.ngaySinh = ngaySinh;
            this.nganHang = nganHang;
        }
        static public void XuatDanhSachThongTin(List<ThongTinCoBan> danhSach)
        {
            for (int i = 0; i < danhSach.Count; i++)
            {
                Console.WriteLine("So thu tu: " + (i + 1).ToString());
                danhSach[i].ThongTin();
                Console.WriteLine();
            }
        }
        public virtual void ThongTin()
        {
            Console.WriteLine("Ho ten: " + hoTen);
            Console.WriteLine("Dia chi: " + diaChi);
            Console.WriteLine("So dien thoai: " + soDienThoai);
            Console.WriteLine("Ngay sinh: " + ngaySinh.ToString("dd/MM/yyyy"));
            Console.WriteLine("So tai khoan ngan hang: " + nganHang.SoTaiKhoan);
        }
        static public void DocDuLieu(List<ChuXe> danhSachChuXe, List<TaiXe> danhSachTaiXe, List<KhachThueXe> danhSachKhachThueXe, string duongDanDuLieu)
        {
            Application excel = null;
            Workbook trang = null;
            Worksheet bangTinh = null;

            try
            {
                Excel.KhoiTao(out excel, out trang, out bangTinh, duongDanDuLieu);
                DateTime ngayThangNam;
                List<NganHang> danhSachNganHang = NganHang.DocDuLieu();

                for (int i = 3; bangTinh.Cells[i, 1].Value != null; i++)
                {
                    DateTime.TryParse(bangTinh.Cells[i, 4].Text, out ngayThangNam);
                    if (danhSachChuXe != null)
                    {
                        danhSachChuXe.Add(new ChuXe(bangTinh.Cells[i, 1].Text, bangTinh.Cells[i, 2].Text, bangTinh.Cells[i, 3].Text, ngayThangNam, danhSachNganHang.Find(nganHang => nganHang.SoTaiKhoan == bangTinh.Cells[i, 5].Text)));
                    }
                    else if (danhSachTaiXe != null)
                    {
                        danhSachTaiXe.Add(new TaiXe(bangTinh.Cells[i, 1].Text, bangTinh.Cells[i, 2].Text, bangTinh.Cells[i, 3].Text, ngayThangNam, danhSachNganHang.Find(nganHang => nganHang.SoTaiKhoan == bangTinh.Cells[i, 5].Text)));
                    }
                    else
                    {
                        danhSachKhachThueXe.Add(new KhachThueXe(bangTinh.Cells[i, 1].Text, bangTinh.Cells[i, 2].Text, bangTinh.Cells[i, 3].Text, ngayThangNam, danhSachNganHang.Find(nganHang => nganHang.SoTaiKhoan == bangTinh.Cells[i, 5].Text)));
                    }
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Du lieu chu xe loi: " + e.Message);
            }
            finally
            {
                Excel.Dong(excel, trang);
            }
        }
    }
}
