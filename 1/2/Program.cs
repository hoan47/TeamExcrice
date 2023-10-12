using System;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            BenhVien a = new BenhVien(new DateTime(2020, 05, 29), 5, 10000000);

            KhoiTaoDanhSachNhanVien(a);

            a.InDanhSachNhanVien();

            a.LuongMotThangCongTyPhaiTra();

            a.NhanVienGioiNhat();

            Console.ReadKey();
        }

        static void KhoiTaoDanhSachNhanVien(BenhVien a)
        {
            NhanVien[] danhSachNhanVien = {
                new QuanLy("Bui Quang Hoan", "01", new DateTime(2004, 02, 04), "Dak Lak", 5, new DateTime(2020, 05, 04), 25, 25),
                new QuanLy("Bui Quang Hoan", "02", new DateTime(2004, 02, 04), "Dak Lak", 6, new DateTime(2020, 05, 04), 26, 25),

                new BacSi("Bui Quang Hoan", "03", new DateTime(2004, 02, 04), "Dak Lak", 4, new DateTime(2020, 05, 04), 25, 25, 8),
                new BacSi("Bui Quang Hoan", "04", new DateTime(2004, 02, 04), "Dak Lak", 4, new DateTime(2020, 05, 04), 25, 25, 8),
                new BacSi("Bui Quang Hoan", "05", new DateTime(2004, 02, 04), "Dak Lak", 4, new DateTime(2020, 05, 04), 25, 25, 4),
                new BacSi("Bui Quang Hoan", "06", new DateTime(2004, 02, 04), "Dak Lak", 3, new DateTime(2020, 05, 04), 25, 25, 4),
                new BacSi("Bui Quang Hoan", "07", new DateTime(2004, 02, 04), "Dak Lak", 4, new DateTime(2020, 05, 04), 25, 25, 4),

                new YTa("Bui Quang Hoan", "08", new DateTime(2004, 02, 04), "Dak Lak", 3, new DateTime(2020, 05, 04), 25, 25),
                new YTa("Bui Quang Hoan", "09", new DateTime(2004, 02, 04), "Dak Lak", 2, new DateTime(2020, 05, 04), 25, 25),
                new YTa("Bui Quang Hoan", "11", new DateTime(2004, 02, 04), "Dak Lak", 3, new DateTime(2020, 05, 04), 25, 25),
                new YTa("Bui Quang Hoan", "12", new DateTime(2004, 02, 04), "Dak Lak", 2, new DateTime(2020, 05, 04), 25, 25),
                new YTa("Bui Quang Hoan", "13", new DateTime(2004, 02, 04), "Dak Lak", 3, new DateTime(2020, 05, 04), 25, 25),
                new YTa("Bui Quang Hoan", "14", new DateTime(2004, 02, 04), "Dak Lak", 2, new DateTime(2020, 05, 04), 25, 25),

                new VanPhong("Bui Quang Hoan", "15", new DateTime(2004, 02, 04), "Dak Lak", 2, new DateTime(2020, 05, 04), 25, 25),
                new VanPhong("Bui Quang Hoan", "16", new DateTime(2004, 02, 04), "Dak Lak", 3, new DateTime(2020, 05, 04), 25, 25),
                new VanPhong("Bui Quang Hoan", "17", new DateTime(2004, 02, 04), "Dak Lak", 2, new DateTime(2020, 05, 04), 25, 25),
                new VanPhong("Bui Quang Hoan", "18", new DateTime(2004, 02, 04), "Dak Lak", 2, new DateTime(2020, 05, 04), 25, 25),
                new VanPhong("Bui Quang Hoan", "19", new DateTime(2004, 02, 04), "Dak Lak", 2, new DateTime(2020, 05, 04), 25, 25),
                new VanPhong("Bui Quang Hoan", "20", new DateTime(2004, 02, 04), "Dak Lak", 3, new DateTime(2020, 05, 04), 25, 25),

                new DieuDuong("Bui Quang Hoan", "21", new DateTime(2004, 02, 04), "Dak Lak", 1, new DateTime(2020, 05, 04), 25, 25),
                new DieuDuong("Bui Quang Hoan", "22", new DateTime(2004, 02, 04), "Dak Lak", 1, new DateTime(2020, 05, 04), 25, 25),
                new DieuDuong("Bui Quang Hoan", "23", new DateTime(2004, 02, 04), "Dak Lak", 1, new DateTime(2020, 05, 04), 25, 25),
                new DieuDuong("Bui Quang Hoan", "24", new DateTime(2004, 02, 04), "Dak Lak", 2, new DateTime(2020, 05, 04), 25, 25),
                new DieuDuong("Bui Quang Hoan", "26", new DateTime(2004, 02, 04), "Dak Lak", 1, new DateTime(2020, 05, 04), 25, 25),
            };
            BenhNhan[] danhSachBenhNhan = {
                new BenhNhan("Nguyen Van An", "00", new DateTime(2004, 05, 09), "Gia Lai", BenhNhan.ETinhTrangBenh.DacBiet),
                new BenhNhan("Nguyen Van An", "01", new DateTime(2004, 05, 09), "Gia Lai", BenhNhan.ETinhTrangBenh.DacBiet),
                new BenhNhan("Nguyen Van An", "02", new DateTime(2004, 05, 09), "Gia Lai", BenhNhan.ETinhTrangBenh.DacBiet),
                new BenhNhan("Nguyen Van An", "03", new DateTime(2004, 05, 09), "Gia Lai", BenhNhan.ETinhTrangBenh.DacBiet),
                new BenhNhan("Nguyen Van An", "04", new DateTime(2004, 05, 09), "Gia Lai", BenhNhan.ETinhTrangBenh.DacBiet),
                new BenhNhan("Nguyen Van An", "05", new DateTime(2004, 05, 09), "Gia Lai", BenhNhan.ETinhTrangBenh.DacBiet),
                new BenhNhan("Nguyen Van An", "06", new DateTime(2004, 05, 09), "Gia Lai", BenhNhan.ETinhTrangBenh.DacBiet),
                new BenhNhan("Nguyen Van An", "07", new DateTime(2004, 05, 09), "Gia Lai", BenhNhan.ETinhTrangBenh.DacBiet),
                new BenhNhan("Nguyen Van An", "08", new DateTime(2004, 05, 09), "Gia Lai", BenhNhan.ETinhTrangBenh.DacBiet),
                new BenhNhan("Nguyen Van An", "09", new DateTime(2004, 05, 09), "Gia Lai", BenhNhan.ETinhTrangBenh.DacBiet),
                new BenhNhan("Nguyen Van An", "10", new DateTime(2004, 05, 09), "Gia Lai", BenhNhan.ETinhTrangBenh.DacBiet),
                new BenhNhan("Nguyen Van An", "11", new DateTime(2004, 05, 09), "Gia Lai", BenhNhan.ETinhTrangBenh.DacBiet),
                new BenhNhan("Nguyen Van An", "12", new DateTime(2004, 05, 09), "Gia Lai", BenhNhan.ETinhTrangBenh.DacBiet),
                new BenhNhan("Nguyen Van An", "13", new DateTime(2004, 05, 09), "Gia Lai", BenhNhan.ETinhTrangBenh.DacBiet),
                new BenhNhan("Nguyen Van An", "14", new DateTime(2004, 05, 09), "Gia Lai", BenhNhan.ETinhTrangBenh.DacBiet),
                new BenhNhan("Nguyen Van An", "15", new DateTime(2004, 05, 09), "Gia Lai", BenhNhan.ETinhTrangBenh.DacBiet),
                new BenhNhan("Nguyen Van An", "16", new DateTime(2004, 05, 09), "Gia Lai", BenhNhan.ETinhTrangBenh.DacBiet),
                new BenhNhan("Nguyen Van An", "17", new DateTime(2004, 05, 09), "Gia Lai", BenhNhan.ETinhTrangBenh.DacBiet),
                new BenhNhan("Nguyen Van An", "18", new DateTime(2004, 05, 09), "Gia Lai", BenhNhan.ETinhTrangBenh.DacBiet),
                new BenhNhan("Nguyen Van An", "19", new DateTime(2004, 05, 09), "Gia Lai", BenhNhan.ETinhTrangBenh.DacBiet),
                new BenhNhan("Nguyen Van An", "20", new DateTime(2004, 05, 09), "Gia Lai", BenhNhan.ETinhTrangBenh.DacBiet),

                new BenhNhan("Nguyen Van An", "21", new DateTime(2004, 05, 09), "Gia Lai", BenhNhan.ETinhTrangBenh.Nhe),
                new BenhNhan("Nguyen Van An", "22", new DateTime(2004, 05, 09), "Gia Lai", BenhNhan.ETinhTrangBenh.Nhe),
                new BenhNhan("Nguyen Van An", "23", new DateTime(2004, 05, 09), "Gia Lai", BenhNhan.ETinhTrangBenh.Nhe),
                new BenhNhan("Nguyen Van An", "24", new DateTime(2004, 05, 09), "Gia Lai", BenhNhan.ETinhTrangBenh.Nhe),
                new BenhNhan("Nguyen Van An", "25", new DateTime(2004, 05, 09), "Gia Lai", BenhNhan.ETinhTrangBenh.Nhe),
                new BenhNhan("Nguyen Van An", "26", new DateTime(2004, 05, 09), "Gia Lai", BenhNhan.ETinhTrangBenh.Nhe),
                new BenhNhan("Nguyen Van An", "27", new DateTime(2004, 05, 09), "Gia Lai", BenhNhan.ETinhTrangBenh.Nhe),
                new BenhNhan("Nguyen Van An", "28", new DateTime(2004, 05, 09), "Gia Lai", BenhNhan.ETinhTrangBenh.Nhe),
                new BenhNhan("Nguyen Van An", "29", new DateTime(2004, 05, 09), "Gia Lai", BenhNhan.ETinhTrangBenh.Nhe),
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

            for (int i = 0; i < danhSachNhanVien.Length; i++)
            {
                batDau = ngauNhien.Next(0, danhSachBenhNhan.Length / 2);
                ketThuc = ngauNhien.Next(batDau, danhSachBenhNhan.Length);

                for (int j = batDau; j < ketThuc; j++)
                {
                    if (danhSachNhanVien[i] is QuanLy)
                    {
                        QuanLy quanLy = (QuanLy)danhSachNhanVien[i];
                        quanLy.ThemBenhNhanDeChuaTri(danhSachBenhNhan[j]);
                    }
                    else if (danhSachNhanVien[i] is YTa)
                    {
                        YTa yTa = (YTa)danhSachNhanVien[i];
                        yTa.ThemBenhNhanDeChuaTri(danhSachBenhNhan[j]);
                    }
                    else if (danhSachNhanVien[i] is DieuDuong)
                    {
                        DieuDuong dieuDuong = (DieuDuong)danhSachNhanVien[i];
                        dieuDuong.ThemBenhNhanDeChuaTri(danhSachBenhNhan[j]);
                    }
                }
            }

            foreach (NhanVien nhanVien in danhSachNhanVien)
            {
                a.ThemNhanVien(nhanVien);
            }
        }
    }
}
