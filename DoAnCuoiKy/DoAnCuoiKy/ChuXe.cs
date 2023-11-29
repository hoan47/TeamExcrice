using System;
using System.Collections.Generic;
using System.Linq;

namespace DoAnCuoiKy
{
    internal class ChuXe : ThongTinCoBan
    {
        private List<Xe>[] danhSachXeChuaThue;
        private List<Xe>[] danhSachXeDaThue;
        private QuanLyDanhGia danhGia;
        private KhachQuen khachHangQuen;
        public List<Xe>[] DanhSachXeChuaThue { get { return danhSachXeChuaThue; } }
        public List<Xe>[] DanhSachXeDaThue { get { return danhSachXeDaThue; } }
        public QuanLyDanhGia DanhGia { get { return danhGia; } }
        public KhachQuen KhachHangQuen { get { return khachHangQuen; } }

        public ChuXe(string hoTen, string diaChi, string soDienThoai, DateTime ngaySinh, NganHang nganHang)
            : base(hoTen, diaChi, soDienThoai, ngaySinh, nganHang)
        {
            KhoiTaoDanhSachXe(out danhSachXeChuaThue);
            KhoiTaoDanhSachXe(out danhSachXeDaThue);
            danhGia = new QuanLyDanhGia();
            khachHangQuen = new KhachQuen();
        }
        public void ThemXeChuaThue(Xe xe)
        {
            danhSachXeChuaThue[(int)Xe.PhanLoai(xe)].Add(xe);
        }
        public void ThemXeDaThue(Xe xe)
        {
            danhSachXeDaThue[(int)Xe.PhanLoai(xe)].Add(xe);
        }
        public List<Xe> TimXe(Xe.EPhanLoai loaiXe, decimal giaTu, decimal giaDen)
        {
            List<Xe> danhSachXeTimDuoc = new List<Xe>();

            Console.WriteLine("Ten chu xe: " + HoTen + " ket qua tim kiem:");
            foreach (Xe xe in danhSachXeChuaThue[(int)loaiXe])
            {
                if (giaTu <= xe.GiaThueMotNgay && xe.GiaThueMotNgay <= giaDen)
                {
                    Console.WriteLine("Xe thu: " + (danhSachXeTimDuoc.Count + 1).ToString());
                    xe.XuatThongTinXe();
                    danhSachXeTimDuoc.Add(xe);
                }
            }
            Console.WriteLine("So xe tim duoc nam trong muc gia [" + giaTu.ToString() + ";  " + giaDen.ToString() + "] la: " + danhSachXeTimDuoc.Count);
            return danhSachXeTimDuoc;
        }
        public void ChoThueXe(Xe xe)
        {
            danhSachXeChuaThue[(int)Xe.PhanLoai(xe)].Remove(xe);
            danhSachXeDaThue[(int)Xe.PhanLoai(xe)].Add(xe);
        }
        public void KhachTraXe(Xe xe)
        {
            danhSachXeDaThue[(int)Xe.PhanLoai(xe)].Remove(xe);
            danhSachXeChuaThue[(int)Xe.PhanLoai(xe)].Add(xe);
        }
        public void XuatToanBoDanhGiaXe()
        {
            XuatToanBoDanhGiaXe(danhSachXeChuaThue);
            XuatToanBoDanhGiaXe(danhSachXeDaThue);
        }
        public void XuatToanBoDanhGiaXe(List<Xe>[] danhSach)
        {
            foreach (List<Xe> xe in danhSach)
            {
                foreach (Xe xe_ in xe)
                {
                    if (xe_.DanhGia.DanhSachDanhGia.Count != 0)
                    {
                        xe_.XuatThongTinXe();
                        xe_.DanhGia.XuatToanBoDanhGia();
                    }
                }
            }
        }
        static public void XuatDanhSachChuXe(List<ChuXe> danhSachChuChoThue)
        {
            Console.WriteLine("Danh sach chu cho thue xe:");
            XuatDanhSachThongTin(danhSachChuChoThue.ToList<ThongTinCoBan>());
        }
        static public ChuXe KhoiTao()
        {
            return new ChuXe(DauVaoBanPhim.String("Ho ten: "), DauVaoBanPhim.String("Dia chi: "), DauVaoBanPhim.String("So dien thoai: "), DauVaoBanPhim.DateTime_("Nam thang ngay sinh: "), NganHang.KhoiTao());
        }
        public override void ThongTin()
        {
            base.ThongTin();
            Console.WriteLine("Hien co " + (danhSachXeChuaThue.Sum(ds => ds.Count) + danhSachXeDaThue.Sum(ds => ds.Count)).ToString() + " xe cho thue\n");
        }
        public class KhachQuen
        {
            Dictionary<KhachThueXe, int> soLanDaThue;

            public KhachQuen()
            {
                soLanDaThue = new Dictionary<KhachThueXe, int>();
            }
            public void ThueXe(KhachThueXe khach)
            {
                if (soLanDaThue.ContainsKey(khach) == false)
                {
                    soLanDaThue.Add(khach, 1);
                }
                else
                {
                    soLanDaThue[khach]++;
                }
            }
            public int SoLanThueXe(KhachThueXe khach)
            {
                return soLanDaThue.ContainsKey(khach) == true ? soLanDaThue[khach] : 0;
            }
            public List<KhachThueXe> DanhSachKhachDaThueXe()
            {
                return soLanDaThue.Keys.ToList();
            }
        }
        private void KhoiTaoDanhSachXe(out List<Xe>[] danhSach)
        {
            danhSach = new List<Xe>[3];
            for (int i = 0; i < 3; i++)
            {
                danhSach[i] = new List<Xe>();
            }
        }
    }
}
