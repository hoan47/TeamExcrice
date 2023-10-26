using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi
{
    public class HopDongThueNha
    {
        private decimal tienDatCoc;
        private PhongTro phongTro;
        private NguoiChoThue nguoiChoThue;
        private NguoiThue nguoiThue;
        private DateTime thoiHan;
        private BoiThuong boiThuong;
        public event Action<HopDongThueNha> EThuePhong;

        public HopDongThueNha(int tienDatCoc, PhongTro phongTro, NguoiChoThue nguoiChoThue, NguoiThue nguoiThue, DateTime thoiHan, BoiThuong boiThuong)
        {
            this.tienDatCoc = tienDatCoc;
            this.phongTro = phongTro;
            this.nguoiChoThue = nguoiChoThue;
            this.nguoiThue = nguoiThue;
            this.thoiHan = thoiHan;
            this.boiThuong = boiThuong;
            DaThue = false;
        }
        public bool DaThue { get; private set; }

        public NguoiChoThue NguoiChoThue
        {
            get { return nguoiChoThue; }
            private set { }
        }
        public NguoiThue NguoiThue
        {
            get { return nguoiThue; }
            set { nguoiThue = value; }
        }
        public EKetQuaThue ThuePhong()
        {
            if (DateTime.Now >= thoiHan)
            {
                return EKetQuaThue.HetHan;
            }
            else if (DaThue == true)
            {
                return EKetQuaThue.DaCoNguoiThue;
            }
            else if (nguoiThue == null || nguoiThue.NganHang.ChuyenTien(nguoiChoThue.NganHang, tienDatCoc) == false)
            {
                return EKetQuaThue.ThatBai;
            }
            else
            {
                DaThue = true;
                EThuePhong?.Invoke(this);
                return EKetQuaThue.ThanhCong;
            }
        }
        public void KhachRutHopDong(DateTime thoiGianRut)
        {
            if (DaThue == true)
            {
                if (thoiGianRut < thoiHan)
                {
                    nguoiChoThue.ToCao(this, "Khach tra phong truong thoi han hop dong");
                }
                Console.WriteLine("Rut hop dong thanh cong");
                KetThucHopDong();
            }
            else
            {
                CWPhongChuaDuocThue();
            }
        }
        public void ChuNhaLayPhong(DateTime thoiGianLayPhong)
        {
            if (DaThue == true)
            {
                if (thoiGianLayPhong < thoiHan)
                {
                    decimal tienBoiThuong = tienDatCoc + boiThuong.TienChuDenHopDong;
                    if (nguoiChoThue.NganHang.ChuyenTien(nguoiThue.NganHang, tienBoiThuong) == true)
                    {
                        Console.WriteLine("So tien chu nha da boi thuong (Noi dung: chu nha lay phong truoc thoi han): " + tienBoiThuong.ToString());
                        KetThucHopDong();
                    }
                    else
                    {
                        Console.WriteLine("Chu nha den hop dong khong thanh cong.");
                    }
                }
                else
                {
                    Console.WriteLine("Chu nha lay lai phong thanh cong");
                    KetThucHopDong();
                }
            }
            else
            {
                CWPhongChuaDuocThue();
            }
        }
        public void NguoiThueLamHuHong(string tenNoiThat)
        {
            if (DaThue == true)
            {
                BoiThuong.NoiThat noiThat = boiThuong.DanhSachDenBuNoiThat.First(x => x.TenNoiThat == tenNoiThat);

                if(noiThat == null)
                {
                    Console.WriteLine("Khong ton tai noi dung den bu nay trong hop dong");
                }
                else if(nguoiThue.NganHang.ChuyenTien(nguoiChoThue.NganHang, noiThat.GiaTien) == true)
                {
                    Console.WriteLine("Den bu thanh cong");
                }
                else
                {
                    Console.WriteLine("Den bu that bai");
                }
            }
            else
            {
                CWPhongChuaDuocThue();
            }
        }

        private void CWPhongChuaDuocThue()
        {
            Console.WriteLine("PhongChuaDuocThue");
        }
        private void KetThucHopDong()
        {
            DaThue = false;
            nguoiThue = null;
        }
        
        public class BoiThuong
        {
            public decimal TienChuDenHopDong { get; private set; }
            public NoiThat[] DanhSachDenBuNoiThat { get; private set; }

            public BoiThuong(decimal tienChuDenHopDong, NoiThat[] danhSachDenBuNoiThat)
            {
                TienChuDenHopDong = tienChuDenHopDong;
                DanhSachDenBuNoiThat = danhSachDenBuNoiThat;
            }
            public class NoiThat
            {
                public string TenNoiThat { get; private set; }
                public decimal GiaTien { get; private set; }
                public NoiThat(string tenNoiThat, decimal giaTien)
                {
                    TenNoiThat = tenNoiThat;
                    GiaTien = giaTien;
                }
            }
        }
        
        public enum EKetQuaThue
        {
            HetHan,
            DaCoNguoiThue,
            ThatBai,
            ThanhCong
        }
    }
}
