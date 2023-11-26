using System;

namespace DoAnCuoiKy
{
    internal static class ChayChuongTrinh
    {
        public static void ChuongTrinh()
        {
            Console.WriteLine("Chuong trinh quan li thue xe vui long chon doi tuong.\n1. Chu cho thue\n2. Khach thue xe\n3. Dong chuong trinh");
            switch (DauVaoBanPhim.Int(1, 3, "Chon 1 trong 3: "))
            {
                case 1:
                    ChayChuongTrinhChuXe.ChuongTrinhChonChuXe();
                    break;
                case 2:
                    ChayChuongTrinhKhachThueXe.ChuongTrinhChonKhachThueXe();
                    break;
                case 3:
                    Console.WriteLine("Dong chuong trinh.");
                    break;
            }
        }
    }
}

