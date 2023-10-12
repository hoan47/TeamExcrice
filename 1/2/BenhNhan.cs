using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    class BenhNhan : ThongTinNguoi
    {
        private string maSoBenhNhan;
        private ETinhTrangBenh tinhTrang;

        public BenhNhan(string hoTen, string maSoBenhNhan, DateTime ngayThangNamSinh, string diaChi, ETinhTrangBenh tinhTrang) : base(hoTen, ngayThangNamSinh, diaChi)
        {
            this.maSoBenhNhan = maSoBenhNhan;
            this.tinhTrang = tinhTrang;
        }

        public ETinhTrangBenh TinhTrang
        {
            get { return tinhTrang; }
            private set { }
        }

        public enum ETinhTrangBenh
        {
            Nhe,
            DacBiet
        }
    }
}
