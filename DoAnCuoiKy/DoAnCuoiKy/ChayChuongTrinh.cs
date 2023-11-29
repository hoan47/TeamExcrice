using System;

namespace DoAnCuoiKy
{
    internal static class ChayChuongTrinh
    {
        public static void ChuongTrinh()
        {
            switch (DauVaoBanPhim.Int(1, 4, "Chuong trinh quan li thue xe vui long chon doi tuong.\n1. Chu cho thue\n2. Khach thue xe\n3. Tai xe.\n4. Dong chuong trinh.\nChon 1 trong 4: "))
            {
                case 1:
                    ChayChuongTrinhChuXe.ChuongTrinhChuXe();
                    break;
                case 2:
                    ChayChuongTrinhKhachThueXe.ChuongTrinhKhachThueXe();
                    break;
                case 3:
                    ChayChuongTrinhTaiXe.ChuongTrinhTaiXe();
                    break;
                case 4:
                    Console.WriteLine("Dong chuong trinh.");
                    break;
            }
        }
    }
}

