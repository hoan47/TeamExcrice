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
            NganHang nganHangA = new NganHang("22110328", 10000000);
            NganHang nganHangB = new NganHang("22110329", 10000000);
            NganHang nganHangC = new NganHang("22110330", 10000000);

            CongTyMoiGioi congTyMoiGioi = new CongTyMoiGioi("Phuc Long", "2268977", "Dien Bien Phu");
            NguoiMoiGioi nguoiMoiGioi = new NguoiMoiGioi("Phan Phu", true, 48, "Pham Van Dong", "0863213", "0833320083", nganHangA, congTyMoiGioi);
               
            NguoiChoThue nguoiChoThue = new NguoiChoThue("Pham Kim Thuong", false, 48, "Vo Van Ngan", "086640", "0978594077", nganHangB);
            NguoiThue nguoiThue = new NguoiThue("Pham Kim Dung", false, 48, "Vo Van Ngan", "086640", "0978594077", nganHangC, "Sinh vien");
            PhongTro phongTro = new PhongTro(4, "Go", 2200000, "Kha Van Can", true, true, true, true, true, 2, "...", nguoiChoThue);

            HopDongThueNha.BoiThuong.NoiThat[] dachSachDenBuNoiThat = {
                new HopDongThueNha.BoiThuong.NoiThat("Tuong nha", 1000000),
                new HopDongThueNha.BoiThuong.NoiThat("Bon cau", 100000),
                new HopDongThueNha.BoiThuong.NoiThat("Voi nuoc", 50000),
                new HopDongThueNha.BoiThuong.NoiThat("San nha", 2000000)
            };

            HopDongThueNha.BoiThuong boiThuong = new HopDongThueNha.BoiThuong(1000000, dachSachDenBuNoiThat);
            HopDongThueNha hopDong = new HopDongThueNha(1000000, phongTro, nguoiChoThue, nguoiThue, new DateTime(2024, 04, 05), boiThuong);

            congTyMoiGioi.ThemNhanVien(nguoiMoiGioi);
            nguoiMoiGioi.ThemHopDong(hopDong);
            nguoiMoiGioi.ChoThuePhongTro(hopDong);

            nguoiThue.RutHopDong(hopDong, new DateTime(2023, 08, 09));
            hopDong.ChuNhaLayPhong(new DateTime(2023, 12, 01));
            hopDong.NguoiThueLamHuHong("San nha");
            congTyMoiGioi.ChuNhaBaoCaoKhachHang(hopDong, "Vai ngu");
        }
    }
}
