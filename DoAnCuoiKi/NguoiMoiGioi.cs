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
        private List<HopDongThueNha> danhSachHopDong;

        public NguoiMoiGioi(string ten, bool laNam, int tuoi, string diaChi, string soCMND, string soDT, 
            CongTyMoiGioi congTyMoiGioi)
            : base(ten, laNam, tuoi, diaChi, soCMND, soDT)
        {
            this.congTyMoiGioi = congTyMoiGioi;
            danhSachHopDong = new List<HopDongThueNha>();
        }
        public void ThemHopDong(HopDongThueNha hopDong)
        {
            danhSachHopDong.Add(hopDong);
            hopDong.EDaThue += PhongDaDuocThue;
        }
        public void ChoThuePhongTro(HopDongThueNha hopDong)
        {
            if(danhSachHopDong.Contains(hopDong))
            {
                hopDong.ThuePhong();
            }
            else
            {
                Console.WriteLine("Hop dong khong duoc moi gioi lam viec");
            }
        }
        public void PhongDaDuocThue(HopDongThueNha hopDong)
        {
            hopDong.EDaThue -= PhongDaDuocThue;
            danhSachHopDong.Remove(hopDong);
        }
    }
}
