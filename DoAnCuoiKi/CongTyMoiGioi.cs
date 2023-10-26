using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi
{
    public class CongTyMoiGioi
    {
        private string tenCongTy;
        private string maSoThue;
        private string diaChi;
        private List<NhanVienMoiGioi> danhSachNhanVien;

        public CongTyMoiGioi(string tenCongTy, string maSoThue, string diaChi)
        {
            this.tenCongTy = tenCongTy;
            this.maSoThue = maSoThue;
            this.diaChi = diaChi;
            danhSachNhanVien = new List<NhanVienMoiGioi>();
        }
        public void ThemNhanVien(NguoiMoiGioi nguoiMoiGioi)
        {
            if (danhSachNhanVien.Find(nv => nv.NguoiMoiGioi == nguoiMoiGioi) == null)
            {
                danhSachNhanVien.Add(new NhanVienMoiGioi(nguoiMoiGioi));
                nguoiMoiGioi.EThanhTich += ThemThanhTich;
            }
        }
        public void ThemHopDongChoNhanVien(NguoiMoiGioi nguoiMoiGioi, HopDongThueNha hopDong)
        {
            if (nguoiMoiGioi.CongTyMoiGioi == this)
            {
                nguoiMoiGioi.ThemHopDong(hopDong);
            }
            else
            {
                Console.WriteLine("Nguoi moi gioi khong lam trong cong ty.");
            }
        }
        private void ThemThanhTich(NguoiMoiGioi nguoiMoiGioi, HopDongThueNha hopDong)
        {
            NhanVienMoiGioi nhanVien = danhSachNhanVien.Find(nv => nv.NguoiMoiGioi == nguoiMoiGioi);
            if (nhanVien == null)
            {
                Console.WriteLine("Moi gioi khong lam viec trong cong ty nay.");
            }
            else
            {
                nguoiMoiGioi.EThanhTich -= ThemThanhTich;
                Console.WriteLine("Them thanh cong thanh tich cho nhan vien");
                nhanVien.ThemThanhTich(hopDong);
            }
        }
        private class NhanVienMoiGioi
        {
            private NguoiMoiGioi nguoiMoiGioi;
            private List<HopDongThueNha> danhSachThanhTich;

            public NhanVienMoiGioi(NguoiMoiGioi nguoiMoiGioi)
            {
                this.nguoiMoiGioi = nguoiMoiGioi;
                danhSachThanhTich = new List<HopDongThueNha>();
            }
            public NguoiMoiGioi NguoiMoiGioi
            {
                get { return nguoiMoiGioi; }
                private set { }
            }
            public void ThemThanhTich(HopDongThueNha hopDong)
            {
                danhSachThanhTich.Add(hopDong);
            }
        }
    }
}
