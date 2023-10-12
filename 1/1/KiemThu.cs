using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class KiemThu : NhanVien
    {
        private int soLoiTimRa;

        public KiemThu(string hoTen, string ma, DateTime ngayThangNamSinh, string diaChi, float heSoLuong, DateTime ngayBatDauLamViec, int soLanDiemDanhDi, int soLanDiemDanhVe, int soLoiTimRa) : 
            base(hoTen, ma, ngayThangNamSinh, diaChi, heSoLuong, ngayBatDauLamViec, soLanDiemDanhDi, soLanDiemDanhVe)
        {
            this.soLoiTimRa = soLoiTimRa;
        }

        public override void InThongTin()
        {
            Console.WriteLine("Cap bac: Kiem thu");
            InThongTinNhanVien();
        }

        public override decimal TienThuong()
        {
            return soLoiTimRa * 200000;
        }
    }
}
