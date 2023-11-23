using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
{
    internal class ChuXe : ThongTinCoBan
    {
        private List<Xe>[] danhSachXe;
        private QuanLyDanhGia danhGia;
        private KhachQuen khachHangQuen;
        public List<Xe>[] DanhSachXe { get { return danhSachXe; } }
        public QuanLyDanhGia DanhGia { get { return danhGia; } }
        public KhachQuen KhachHangQuen { get { return khachHangQuen; } }

        public ChuXe(string hoTen, string diaChi, string soDienThoai, DateTime ngaySinh, NganHang nganHang) 
            : base(hoTen, diaChi, soDienThoai, ngaySinh, nganHang)
        {
            KhoiTaoDanhSachXe();
            danhGia = new QuanLyDanhGia();
            khachHangQuen = new KhachQuen();
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
        static public void XuatDanhSachChuXe(List<ChuXe> danhSachChuChoThue)
        {
            Console.WriteLine("Danh sach chu cho thue xe:");
            XuatDanhSachThongTin(danhSachChuChoThue.ToList<ThongTinCoBan>());
        }
        static public void XuatToanBoDanhGiaXe(List<Xe>[] danhSachXe)
        {
            foreach(List<Xe> xe in danhSachXe)
            {
                foreach(Xe xe_ in xe)
                {
                    if (xe_.DanhGia.DanhSachDanhGia.Count != 0)
                    {
                        xe_.XuatThongTinXe();
                        xe_.DanhGia.XuatToanBoDanhGia();
                    }
                }
            }
        }
        static public List<ChuXe> DocDuLieu(List<NganHang> danhSachNganHang)
        {
            List<ChuXe> danhSachChuXe = new List<ChuXe>();
            DocDuLieu(danhSachChuXe, null, null, danhSachNganHang, Excel.ELoaiDuLieu.ChuXe);
            return danhSachChuXe;
        }
        public override void ThongTin()
        {
            base.ThongTin();
            Console.WriteLine("Hien co " + danhSachXe.Sum(ds => ds.Count) + " xe cho thue\n");
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
                    soLanDaThue[khach] ++;
                }
            }
            public int SoLanThueXe(KhachThueXe khach)
            {
                return soLanDaThue[khach];
            }
            public List<KhachThueXe> DanhSachKhachDaThueXe()
            {
                return soLanDaThue.Keys.ToList();
            }
        }
        public bool KiemTraXeSauKhiTra(string tinhTrang)
        {
            return DauVaoBanPhim.Bool(tinhTrang);
        }
    }
}
