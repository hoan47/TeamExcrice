using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi
{
    public class NguoiThue : Nguoi
    {
        private string ngheNghiep;

        public NguoiThue(string ten, bool laNam, int tuoi, string diaChi, string soCMND, string soDT, NganHang nganHang,
            string ngheNghiep)
            : base(ten, laNam, tuoi, diaChi, soCMND, soDT, nganHang)
        {
            this.ngheNghiep = ngheNghiep;
        }
        public void ThuePhong(HopDongThueNha hopDong)
        {
            hopDong.NguoiChoThue.ChoThuePhong(hopDong);
        }
        public void DanhGia(PhongTro phongTro, PhongTro.DanhGia danhGia)
        {
            phongTro.ThemDanhGia(danhGia);
        }
        public void RutHopDong(HopDongThueNha hopDong, DateTime thoiGianRut)
        {
            if(hopDong.NguoiThue == this)
            {
                hopDong.KhachRutHopDong(thoiGianRut);
            }
            else
            {
                CWChuaThuePhong();
            }
        }
        public void DenBu(HopDongThueNha hopDong, string tenNoiThat)
        {
            if(hopDong.NguoiThue == this)
            {
                hopDong.NguoiThueLamHuHong(tenNoiThat);
            }
            else
            {
                CWChuaThuePhong();
            }
        }
        private void CWChuaThuePhong()
        {
            Console.WriteLine("Chua thue phong tro nay.");
        }
    }
}
