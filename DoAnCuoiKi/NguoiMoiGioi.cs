using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi
{
    public class NguoiMoiGioi : Nguoi
    {
        private CongTyMoiGioi congTyMoiGioi;
        private List<PhongTro> danhSachPhongTro;

        public NguoiMoiGioi(string ten, bool laNam, int tuoi, string diaChi, string soCMND, string soDT, 
            CongTyMoiGioi congTyMoiGioi)
            : base(ten, laNam, tuoi, diaChi, soCMND, soDT)
        {
            this.congTyMoiGioi = congTyMoiGioi;
            danhSachPhongTro = new List<PhongTro>();
        }
        public void ThemPhongTro(HopDongThueNha hopDong)
        {
            danhSachPhongTro.Add(hopDong.PhongTro);
            hopDong.EphongDaDuocThue += PhongDaDuocThue;
        }
        public void ChoThuePhongTro(HopDongThueNha hopDong)
        {
            hopDong.ThuePhong();
        }
        public void PhongDaDuocThue(HopDongThueNha hopDong)
        {
            hopDong.EphongDaDuocThue -= PhongDaDuocThue;
            danhSachPhongTro.Remove(hopDong.PhongTro);
        }
    }
}
