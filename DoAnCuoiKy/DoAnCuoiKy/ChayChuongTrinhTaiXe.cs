using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
{
    class ChayChuongTrinhTaiXe
    {
        public static void ChuongTrinhTaiXe()
        {
            switch (DauVaoBanPhim.Int(1, 3, "Ban muon:\n1. Xem tai xe.\n2. Them tai xe.\n3. Quay lai.\nChon 1 trong 3: "))
            {
                case 1:
                    XuLyXemTaiXe();
                    break;
                case 2:
                    XyLyKhoiTaoTaiXe();
                    break;
                case 3:
                    ChayChuongTrinh.ChuongTrinh();
                    break;
            }
        }
        private static void XuLyXemTaiXe()
        {
            TaiXe.XuatDanhSachTaiXe(DuLieu.danhSachTaiXe);
            ChuongTrinhTaiXe();
        }
        private static void XyLyKhoiTaoTaiXe()
        {
            NganHang nganHang = NganHang.KhoiTao();

            DuLieu.danhSachNganHang.Add(nganHang);
            DuLieu.danhSachTaiXe.Add(new TaiXe(nganHang));
            Console.WriteLine("Khoi tao thanh cong.\n");
            ChuongTrinhTaiXe();
        }
    }
}
