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
            CongTy a = new CongTy(new DateTime(2020, 05, 23), 3, 10000000);

            KhoiTaoDanhSachNhanVien(a);
            a.InDanhSachNhanVien();
            a.LuongMotThangCongTyPhaiTra();
            a.NhanVienGioiNhat();
            Console.ReadKey();
        }

        private static void KhoiTaoDanhSachNhanVien(CongTy a)
        {
            NhanVien[] danhSachNhanVien = {
                new QuanLy("Bui Quang Hoan", "01", new DateTime(2004, 02, 04), "Dak Lak", 5, new DateTime(2020, 05, 04), 25, 25),
                new QuanLy("Bui Quang Hoan", "02", new DateTime(2004, 02, 04), "Dak Lak", 6, new DateTime(2020, 05, 04), 26, 25),

                new LapTrinhVien("Bui Quang Hoan", "03", new DateTime(2004, 02, 04), "Dak Lak", 4, new DateTime(2020, 05, 04), 25, 25, 8),
                new LapTrinhVien("Bui Quang Hoan", "04", new DateTime(2004, 02, 04), "Dak Lak", 4, new DateTime(2020, 05, 04), 25, 25, 8),
                new LapTrinhVien("Bui Quang Hoan", "05", new DateTime(2004, 02, 04), "Dak Lak", 4, new DateTime(2020, 05, 04), 25, 25, 4),
                new LapTrinhVien("Bui Quang Hoan", "06", new DateTime(2004, 02, 04), "Dak Lak", 3, new DateTime(2020, 05, 04), 25, 25, 4),
                new LapTrinhVien("Bui Quang Hoan", "07", new DateTime(2004, 02, 04), "Dak Lak", 4, new DateTime(2020, 05, 04), 25, 25, 4),

                new ThietKe("Bui Quang Hoan", "08", new DateTime(2004, 02, 04), "Dak Lak", 3, new DateTime(2020, 05, 04), 25, 25, 2000000),
                new ThietKe("Bui Quang Hoan", "09", new DateTime(2004, 02, 04), "Dak Lak", 2, new DateTime(2020, 05, 04), 25, 25, 1500000),
                new ThietKe("Bui Quang Hoan", "11", new DateTime(2004, 02, 04), "Dak Lak", 3, new DateTime(2020, 05, 04), 25, 25, 200000),
                new ThietKe("Bui Quang Hoan", "12", new DateTime(2004, 02, 04), "Dak Lak", 2, new DateTime(2020, 05, 04), 25, 25, 200000),
                new ThietKe("Bui Quang Hoan", "13", new DateTime(2004, 02, 04), "Dak Lak", 3, new DateTime(2020, 05, 04), 25, 25, 200000),
                new ThietKe("Bui Quang Hoan", "14", new DateTime(2004, 02, 04), "Dak Lak", 2, new DateTime(2020, 05, 04), 25, 25, 200000),

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
            Random ngauNhien = new Random();
            int batDau;
            int ketThuc;

            for (int i = 0; i < 2; i++)
            {
                batDau = ngauNhien.Next(0, danhSachNhanVien.Length / 2);
                ketThuc = ngauNhien.Next(danhSachNhanVien.Length / 2, danhSachNhanVien.Length);
                for (int j = batDau; j < ketThuc; j++)
                {
                    QuanLy quanLy = (QuanLy)danhSachNhanVien[i];
                    quanLy.ThemNhanVienDeQuanLy(danhSachNhanVien[j]);
                }
            }

            foreach (NhanVien nhanVien in danhSachNhanVien)
            {
                a.ThemNhanVien(nhanVien);
            }
        }
    }
}
