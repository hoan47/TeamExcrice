using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi
{
    public class NguoiChoThue : Nguoi
    {
        public event Action<HopDongThueNha, string> EBaoCaoKhachHang;

        public NguoiChoThue(string ten, bool laNam, int tuoi, string diaChi, string soCMND, string soDT, NganHang nganHang)
            : base(ten, laNam, tuoi, diaChi, soCMND, soDT, nganHang)
        { }
        public void ChoThuePhong(HopDongThueNha hopDong)
        {
            Console.WriteLine(hopDong.ThuePhong());
        }
        public void ToCao(HopDongThueNha hopDong, string noiDung)
        {
            Console.WriteLine("Chu phong to cao: " + noiDung);
            EBaoCaoKhachHang?.Invoke(hopDong, noiDung);
        }
        public void LayLaiPhong(HopDongThueNha hopDong, DateTime thoiGianLayPhong)
        {
            hopDong.ChuNhaLayPhong(thoiGianLayPhong);
        }
    }
}
