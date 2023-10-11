using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            CongTy a = new CongTy(new DateTime(2020, 05, 23), 5, 10000000);
            NhanVien[] danhSachNhanVien = {
                new QuanLy("Bui Quang Hoan", "01", new DateTime(2004, 02, 04), "Dak Lak", 5, new DateTime(2020, 05, 04), 25, 25),
                new QuanLy("Bui Quang Hoan", "02", new DateTime(2004, 02, 04), "Dak Lak", 6, new DateTime(2020, 05, 04), 26, 25),

                new LapTrinhVien("Bui Quang Hoan", "03", new DateTime(2004, 02, 04), "Dak Lak", 4, new DateTime(2020, 05, 04), 25, 25, 8),
                new LapTrinhVien("Bui Quang Hoan", "04", new DateTime(2004, 02, 04), "Dak Lak", 4, new DateTime(2020, 05, 04), 25, 25, 8),
                new LapTrinhVien("Bui Quang Hoan", "05", new DateTime(2004, 02, 04), "Dak Lak", 4, new DateTime(2020, 05, 04), 25, 25, 4),
                new LapTrinhVien("Bui Quang Hoan", "06", new DateTime(2004, 02, 04), "Dak Lak", 3, new DateTime(2020, 05, 04), 25, 25, 4),
                new LapTrinhVien("Bui Quang Hoan", "07", new DateTime(2004, 02, 04), "Dak Lak", 4, new DateTime(2020, 05, 04), 25, 25, 4),

                new ThietKe("Bui Quang Hoan", "08", new DateTime(2004, 02, 04), "Dak Lak", 3, new DateTime(2020, 05, 04), 25, 25, 2000000),
                new ThietKe("Bui Quang Hoan", "09", new DateTime(2004, 02, 04), "Dak Lak", 2, new DateTime(2020, 05, 04), 25, 25, 2000000),
                new ThietKe("Bui Quang Hoan", "11", new DateTime(2004, 02, 04), "Dak Lak", 3, new DateTime(2020, 05, 04), 25, 25, 2000000),
                new ThietKe("Bui Quang Hoan", "12", new DateTime(2004, 02, 04), "Dak Lak", 2, new DateTime(2020, 05, 04), 25, 25, 2000000),
                new ThietKe("Bui Quang Hoan", "13", new DateTime(2004, 02, 04), "Dak Lak", 3, new DateTime(2020, 05, 04), 25, 25, 2000000),
                new ThietKe("Bui Quang Hoan", "14", new DateTime(2004, 02, 04), "Dak Lak", 2, new DateTime(2020, 05, 04), 25, 25, 2000000),

                new KiemThu("Bui Quang Hoan", "15", new DateTime(2004, 02, 04), "Dak Lak", 2, new DateTime(2020, 05, 04), 25, 25, 5),
                new KiemThu("Bui Quang Hoan", "2", new DateTime(2004, 02, 04), "Dak Lak", 3, new DateTime(2020, 05, 04), 25, 25, 8),
                new KiemThu("Bui Quang Hoan", "17", new DateTime(2004, 02, 04), "Dak Lak", 2, new DateTime(2020, 05, 04), 25, 25, 4),
                new KiemThu("Bui Quang Hoan", "18", new DateTime(2004, 02, 04), "Dak Lak", 2, new DateTime(2020, 05, 04), 25, 25, 9),
                new KiemThu("Bui Quang Hoan", "19", new DateTime(2004, 02, 04), "Dak Lak", 2, new DateTime(2020, 05, 04), 25, 25, 2),
                new KiemThu("Bui Quang Hoan", "20", new DateTime(2004, 02, 04), "Dak Lak", 3, new DateTime(2020, 05, 04), 25, 25, 4),

                new NhanSu("Bui Quang Hoan", "21", new DateTime(2004, 02, 04), "Dak Lak", 1, new DateTime(2020, 05, 04), 25, 25),
                new NhanSu("Bui Quang Hoan", "22", new DateTime(2004, 02, 04), "Dak Lak", 1, new DateTime(2020, 05, 04), 25, 25),
                new NhanSu("Bui Quang Hoan", "23", new DateTime(2004, 02, 04), "Dak Lak", 1, new DateTime(2020, 05, 04), 25, 25),
                new NhanSu("Bui Quang Hoan", "24", new DateTime(2004, 02, 04), "Dak Lak", 2, new DateTime(2020, 05, 04), 25, 25),
                new NhanSu("Bui Quang Hoan", "25", new DateTime(2004, 02, 04), "Dak Lak", 1, new DateTime(2020, 05, 04), 25, 25),
            };

            QuanLy[] quanLy = {
                (QuanLy)danhSachNhanVien[0], 
                (QuanLy)danhSachNhanVien[1]
                };

            for (int i = 5; i < danhSachNhanVien.Length; i++)
            {
                quanLy[0].ThemNhanVienDeQuanLy(danhSachNhanVien[i]);
            }

            for (int i = 5; i < danhSachNhanVien.Length - 5; i++)
            {
                quanLy[1].ThemNhanVienDeQuanLy(danhSachNhanVien[i]);
            }

            foreach (NhanVien nhanVien in danhSachNhanVien)
            {
                a.ThemNhanVien(nhanVien);
            }

            a.InDanhSachNhanVien();

            a.LuongMotThangCongTyPhaiTra();

            a.NhanVienGioiNhat();
        }
    }
}
