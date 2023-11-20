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
                switch (DauVaoBanPhim.Int(1, 2, "Chon 1 hoac 2: "))
                {
                    case 1:
                        ChuChoThue.XuatToanBoChuXe(danhSachChuChoThue);
                        ChuChoThue chuChoThue = danhSachChuChoThue[DauVaoBanPhim.Int(1, danhSachChuChoThue.Count, "Chon 1 trong " + danhSachChuChoThue.Count.ToString() + " chu cho thue: ") - 1];
                        Console.WriteLine("Ban co ten la: " + chuChoThue.HoTen);
                        ChuongTrinhChuChoThue(chuChoThue);
                        break;
                    case 2:
                        break;
                }
            }

            void ChuongTrinhChuChoThue(ChuChoThue chuChoThue)
            {
                Console.WriteLine("Ban muon: ");
                Console.WriteLine("1. Xem xe cho thue.");
                Console.WriteLine("2. Them xe cho thue.");
                Console.WriteLine("3. Xem danh gia.");
                switch (DauVaoBanPhim.Int(1, 3, "Chon 1 trong 3: "))
                {
                    case 1:
                        ChuongTrinhXe();
                        break;
                    case 2:
                        ChuongTrinhKhoiTaoXe();
                        break;
                    case 3:
                        Console.WriteLine("Ban muon:");
                        Console.WriteLine("1. Xem khach hang danh gia chu.");
                        Console.WriteLine("2. Xem khach hang danh gia xe.");
                        Console.WriteLine("3. Danh gia khach hang.");
                        switch(DauVaoBanPhim.Int(1, 3, "Chon 1 trong 3: "))
                        {
                            case 1:
                                chuChoThue.DanhGia.XuatToanBoDanhGia();
                                break;
                            case 2:
                                ChuChoThue.XuatToanBoDanhGiaXe(chuChoThue.DanhSachXe);
                                break;
                            case 3:
                                break;
                        }
                        break;
                }

                void ChuongTrinhXe()
                {
                    Console.WriteLine(chuChoThue.HoTen + " muon xem loai xe:");
                    Console.WriteLine("1. Xe may.");
                    Console.WriteLine("2. Xe bon cho.");
                    Console.WriteLine("3. Xe bay cho.");
                    int luaChon = DauVaoBanPhim.Int(1, 3, "Chon 1 trong 3 loai xe: ");

                    Console.WriteLine("\nBan muon xem xe da co nguoi thue hay chua co:");
                    Console.WriteLine("1. Da co nguoi thue");
                    Console.WriteLine("2. Chua co nguoi thue");
                    bool daThue = DauVaoBanPhim.Int(1, 2, "Chon 1 hoac 2: ") == 1 ? true : false;

                    switch (luaChon)
                    {
                        case 1:
                            Xe.XuatDanhSachXe(chuChoThue.DanhSachXe[(int)Xe.EPhanLoai.XeMay], daThue);
                            break;
                        case 2:
                            Xe.XuatDanhSachXe(chuChoThue.DanhSachXe[(int)Xe.EPhanLoai.XeBonCho], daThue);
                            break;
                        case 3:
                            Xe.XuatDanhSachXe(chuChoThue.DanhSachXe[(int)Xe.EPhanLoai.XeBayCho], daThue);
                            break;
                    }
                    if(daThue == false)
                    {
                        Console.WriteLine("Chon:\n1.De xoa xe.\n2.Quay lai.");
                        if (DauVaoBanPhim.Int(1, 2, "Chon 1 hoac 2: ") == 1)
                        {
                            int soThuTu = DauVaoBanPhim.Int(1, chuChoThue.DanhSachXe[luaChon].Count, "Chon 1 trong " + chuChoThue.DanhSachXe[luaChon].Count + " can xoa: ");
                            chuChoThue.DanhSachXe[luaChon - 1][soThuTu - 1] = null;
                            chuChoThue.DanhSachXe[luaChon-1].RemoveAt(soThuTu - 1);
                        }
                    }
                    ChuongTrinhChuChoThue(chuChoThue);
                }
                void ChuongTrinhKhoiTaoXe()
                {
                    Console.WriteLine("Chon loai xe: ");
                    Console.WriteLine("1. Xe may");
                    Console.WriteLine("2. Xe bon cho");
                    Console.WriteLine("3. Xe bay cho");
                    switch (DauVaoBanPhim.Int(1, 3, "Chon 1 trong 3 loai xe: "))
                    {
                        case 1:
                            XeMay.KhoiTaoXe(chuChoThue);
                            break;
                        case 2:
                            XeBonCho.KhoiTaoXe(chuChoThue);
                            break;
                        case 3:
                            XeBayCho.KhoiTaoXe(chuChoThue);
                            break;
                    }
                    ChuongTrinhChuChoThue(chuChoThue);
                }
            }
        }
    }
}
