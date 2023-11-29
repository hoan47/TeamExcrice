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
            switch (DauVaoBanPhim.Int(1, 4, "Ban muon:\n1. Xem tai xe.\n2. Them tai xe.\n3. Xoa tai xe.\n4. Quay lai.\nChon 1 trong 4: "))
            {
                case 1:
                    XuLyXemTaiXe();
                    break;
                case 2:
                    XyLyKhoiTaoTaiXe();
                    break;
                case 3:
                    XuLyXoaKhachThueXe();
                    break;
                case 4:
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
            DuLieu.danhSachTaiXe.Add(TaiXe.KhoiTao());
            Console.WriteLine("Khoi tao thanh cong.\n");
            ChuongTrinhTaiXe();
        }
        private static void XuLyXoaKhachThueXe()
        {
            TaiXe.XuatDanhSachTaiXe(DuLieu.danhSachTaiXe);
            int soThuTu = DauVaoBanPhim.Int(1, DuLieu.danhSachTaiXe.Count + 1, (DuLieu.danhSachTaiXe.Count + 1).ToString() + ". Quay lai.\nChon 1 trong " + DuLieu.danhSachTaiXe.Count.ToString() + " xe can xoa: ");

            if (soThuTu != DuLieu.danhSachTaiXe.Count + 1)
            {
                DuLieu.danhSachTaiXe.RemoveAt(soThuTu - 1);
                Console.WriteLine("Da xoa.");
            }
            ChuongTrinhTaiXe();
        }
    }
}
