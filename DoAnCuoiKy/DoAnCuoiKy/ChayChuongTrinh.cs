using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
{
    static class ChayChuongTrinh
    {
        public static void ChuongTrinh()
        {
            List<ChuChoThue> danhSachChuChoThue = new List<ChuChoThue>();
            List<TaiXe> danhSachTaiXe = new List<TaiXe>();
            List<KhachThueXe> danhSachKhachThueXe = new List<KhachThueXe>();
            string[] doiTuong = { "Chu cho thue", "Khach thue xe" };

            if (FileXe.Doc(danhSachChuChoThue, danhSachTaiXe, danhSachKhachThueXe) == true)
            {
                Console.WriteLine("Nhan du lieu tu file thanh cong.");
            }
            else
            {
                throw new Exception("Doc file that bai");
            }

            while (true)
            {
                Console.WriteLine("Chuong trinh quan li thue xe vui long chon doi tuong.");
                Console.WriteLine("1. " + doiTuong[0]);
                Console.WriteLine("2. " + doiTuong[1]);

                switch(SoNguyenBanPhim(1, 2, "Chon 1 hoac 2: "))
                {
                    case 1:
                        ChuongTrinhChuChoThue();
                        break;
                    case 2:

                        break;
                }
            }

            void ChuongTrinhChuChoThue()
            {
                ChuChoThue.XuatToanBoChuXe(danhSachChuChoThue);
                ChuChoThue chuChoThue = danhSachChuChoThue[SoNguyenBanPhim(1, danhSachChuChoThue.Count, "Chon 1 trong " + danhSachChuChoThue.Count.ToString() + " chu cho thue: ") - 1];
                Console.WriteLine("\nBan co ten la: " + chuChoThue.HoTen);
                Console.WriteLine("Ban muon: ");
                Console.WriteLine("1. Xem xe cho thue.");
                Console.WriteLine("2. Xem danh gia xe.");

                switch (SoNguyenBanPhim(1, 2, "Chon 1 trong 2: "))
                {
                    case 1:
                        Console.WriteLine("\n" + chuChoThue.HoTen + " muon xem loai xe:");
                        Console.WriteLine("1. Xe may.");
                        Console.WriteLine("2. Xe bon cho.");
                        Console.WriteLine("3. Xe bay cho.");

                        switch (SoNguyenBanPhim(1, 3, "Chon 1 trong 3: "))
                        {
                            case 1:
                                Xe.XuatDanhSachXe(chuChoThue.DanhSachXe[(int)Xe.EPhanLoai.XeMay]);
                                break;
                            case 2:
                                Xe.XuatDanhSachXe(chuChoThue.DanhSachXe[(int)Xe.EPhanLoai.XeBonCho]);
                                break;
                            case 3:
                                Xe.XuatDanhSachXe(chuChoThue.DanhSachXe[(int)Xe.EPhanLoai.XeBayCho]);
                                break;
                        }
                        throw new Exception("Tam Dung");
                    case 2:
                        throw new Exception("Tam Dung");
                }
            }

            int SoNguyenBanPhim(int batDau, int ketThuc, string noiDung)
            {
                int giaTri;
                while (true)
                {
                    try
                    {
                        Console.Write(noiDung);
                        giaTri = int.Parse(Console.ReadLine());
                        if ((batDau <= giaTri && giaTri <= ketThuc) == false)
                        {
                            continue;
                        }
                        return giaTri;
                    }
                    catch (FormatException)
                    {
                        continue;
                    }
                }
            }
        }
    }
}
