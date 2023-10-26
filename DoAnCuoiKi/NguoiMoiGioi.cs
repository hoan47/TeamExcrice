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
        public event Action<NguoiMoiGioi, HopDongThueNha> EThanhTich;

        public NguoiMoiGioi(string ten, bool laNam, int tuoi, string diaChi, string soCMND, string soDT, 
            CongTyMoiGioi congTyMoiGioi)
            : base(ten, laNam, tuoi, diaChi, soCMND, soDT)
        {
            this.congTyMoiGioi = congTyMoiGioi;
            danhSachHopDong = new List<HopDongThueNha>();
        }
        public CongTyMoiGioi CongTyMoiGioi
        {
            get { return congTyMoiGioi; }
            private set { }
        }
        public void ThemHopDong(HopDongThueNha hopDong)
        {
            if (congTyMoiGioi != null)
            {
                danhSachHopDong.Add(hopDong);
                hopDong.EThuePhong += PhongDaDuocThue;
            }
            else
            {
                Console.WriteLine("Moi gioi khong co cong ty");
            }  
        }
        public void ChoThuePhongTro(HopDongThueNha hopDong)
        {
            if(congTyMoiGioi == null)
            {
                Console.WriteLine("Moi gioi khong co cong ty");
            }    
            if(danhSachHopDong.Contains(hopDong))
            {
                HopDongThueNha.EKetQuaThue ketQua = hopDong.ThuePhong();
                if (ketQua == HopDongThueNha.EKetQuaThue.ThanhCong)
                {
                    EThanhTich.Invoke(this, hopDong);
                }
                Console.WriteLine(ketQua);
            }
            else
            {
                Console.WriteLine("Hop dong khong duoc moi gioi lam viec");
            }
        }
        private void PhongDaDuocThue(HopDongThueNha hopDong)
        {
            hopDong.EThuePhong -= PhongDaDuocThue;
            danhSachHopDong.Remove(hopDong);
        }
    }
}
