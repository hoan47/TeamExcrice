using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi
{
    class Program
    {
        static void Main(string[] args)
        {
            CongTyMoiGioi congTyMoiGioi = new CongTyMoiGioi("Phuc Long", "2268977", "Dien Bien Phu");
            NguoiMoiGioi nguoiMoiGioi = new NguoiMoiGioi("Phan Phu", true, 48, "Pham Van Dong", "0863213", "0833320083", congTyMoiGioi);

            NguoiChoThue nguoiChoThue = new NguoiChoThue("Pham Kim Thuong", false, 48, "Vo Van Ngan", "086640", "0978594077");
            NguoiThue nguoiThue = new NguoiThue("Pham Kim Dung", false, 48, "Vo Van Ngan", "086640", "0978594077", "Sinh vien");
            PhongTro phongTro = new PhongTro(4, "Go", 2200000, "Kha Van Can", true, true, true, true, true, 2, "...", nguoiChoThue);
            HopDongThueNha hopDong = new HopDongThueNha(80000, phongTro, nguoiChoThue, nguoiThue, new DateTime(2024, 04, 05), "...");

            //hopDong.ThuePhong();
            //nguoiMoiGioi.ThemHopDong(hopDong);
            //nguoiMoiGioi.ChoThuePhongTro(hopDong);
            nguoiChoThue.ChoThuePhong(hopDong);
        }
    }
}
