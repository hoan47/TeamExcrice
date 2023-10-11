using System;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            BenhVien a = new BenhVien(new DateTime(2020, 05, 23), 5, 10000000);
            NhanVien[] danhSachNhanVien = {
                new QuanLy("Bui Quang Hoan", "01", new DateTime(2004, 02, 04), "Dak Lak", 5, new DateTime(2020, 05, 04), 25, 25, 200),
                new QuanLy("Bui Quang Hoan", "02", new DateTime(2004, 02, 04), "Dak Lak", 6, new DateTime(2020, 05, 04), 26, 25, 60),

                new BacSi("Bui Quang Hoan", "03", new DateTime(2004, 02, 04), "Dak Lak", 4, new DateTime(2020, 05, 04), 25, 25, 8),
                new BacSi("Bui Quang Hoan", "04", new DateTime(2004, 02, 04), "Dak Lak", 4, new DateTime(2020, 05, 04), 25, 25, 8),
                new BacSi("Bui Quang Hoan", "05", new DateTime(2004, 02, 04), "Dak Lak", 4, new DateTime(2020, 05, 04), 25, 25, 4),
                new BacSi("Bui Quang Hoan", "06", new DateTime(2004, 02, 04), "Dak Lak", 3, new DateTime(2020, 05, 04), 25, 25, 4),
                new BacSi("Bui Quang Hoan", "07", new DateTime(2004, 02, 04), "Dak Lak", 4, new DateTime(2020, 05, 04), 25, 25, 4),

                new YTa("Bui Quang Hoan", "08", new DateTime(2004, 02, 04), "Dak Lak", 3, new DateTime(2020, 05, 04), 25, 25, 10),
                new YTa("Bui Quang Hoan", "09", new DateTime(2004, 02, 04), "Dak Lak", 2, new DateTime(2020, 05, 04), 25, 25, 9),
                new YTa("Bui Quang Hoan", "11", new DateTime(2004, 02, 04), "Dak Lak", 3, new DateTime(2020, 05, 04), 25, 25, 8),
                new YTa("Bui Quang Hoan", "12", new DateTime(2004, 02, 04), "Dak Lak", 2, new DateTime(2020, 05, 04), 25, 25, 10),
                new YTa("Bui Quang Hoan", "13", new DateTime(2004, 02, 04), "Dak Lak", 3, new DateTime(2020, 05, 04), 25, 25, 11),
                new YTa("Bui Quang Hoan", "14", new DateTime(2004, 02, 04), "Dak Lak", 2, new DateTime(2020, 05, 04), 25, 25, 7),

                new VanPhong("Bui Quang Hoan", "15", new DateTime(2004, 02, 04), "Dak Lak", 2, new DateTime(2020, 05, 04), 25, 25),
                new VanPhong("Bui Quang Hoan", "16", new DateTime(2004, 02, 04), "Dak Lak", 3, new DateTime(2020, 05, 04), 25, 25),
                new VanPhong("Bui Quang Hoan", "17", new DateTime(2004, 02, 04), "Dak Lak", 2, new DateTime(2020, 05, 04), 25, 25),
                new VanPhong("Bui Quang Hoan", "18", new DateTime(2004, 02, 04), "Dak Lak", 2, new DateTime(2020, 05, 04), 25, 25),
                new VanPhong("Bui Quang Hoan", "19", new DateTime(2004, 02, 04), "Dak Lak", 2, new DateTime(2020, 05, 04), 25, 25),
                new VanPhong("Bui Quang Hoan", "20", new DateTime(2004, 02, 04), "Dak Lak", 3, new DateTime(2020, 05, 04), 25, 25),

                new DieuDuong("Bui Quang Hoan", "21", new DateTime(2004, 02, 04), "Dak Lak", 1, new DateTime(2020, 05, 04), 25, 25, 10, 5),
                new DieuDuong("Bui Quang Hoan", "22", new DateTime(2004, 02, 04), "Dak Lak", 1, new DateTime(2020, 05, 04), 25, 25, 10, 4),
                new DieuDuong("Bui Quang Hoan", "23", new DateTime(2004, 02, 04), "Dak Lak", 1, new DateTime(2020, 05, 04), 25, 25, 8, 4),
                new DieuDuong("Bui Quang Hoan", "24", new DateTime(2004, 02, 04), "Dak Lak", 2, new DateTime(2020, 05, 04), 25, 25, 9, 3),
                new DieuDuong("Bui Quang Hoan", "26", new DateTime(2004, 02, 04), "Dak Lak", 1, new DateTime(2020, 05, 04), 25, 25, 10, 2),
            };

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
