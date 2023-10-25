using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi
{
    public class HopDongThueNha
    {
        private decimal tienDatCoc;
        private PhongTro phongTro;
        private NguoiChoThue nguoiChoThue;
        private NguoiThue nguoiThue;
        private DateTime thoiHan;
        private string thongTinBoiThuong;
        public Action<HopDongThueNha> EphongDaDuocThue;
        public HopDongThueNha(int tienDatCoc, PhongTro phongTro, NguoiChoThue nguoiChoThue, NguoiThue nguoiThue, DateTime thoiHan, string thongTinBoiThuong)
        {
            this.tienDatCoc = tienDatCoc;
            this.phongTro = phongTro;
            this.nguoiChoThue = nguoiChoThue;
            this.nguoiThue = nguoiThue;
            this.thoiHan = thoiHan;
            this.thongTinBoiThuong = thongTinBoiThuong;
        }
        public decimal TienDatCoc
        {
            get { return tienDatCoc; }
            set { tienDatCoc = value; }
        }

        public PhongTro PhongTro
        {
            get { return phongTro; }
            set { phongTro = value; }
        }

        public NguoiChoThue NguoiChoThue
        {
            get { return nguoiChoThue; }
            private set { }
        }
        public NguoiThue NguoiThue
        {
            get { return nguoiThue; }
            private set { }
        }
        public DateTime ThoiHan
        {
            get { return thoiHan; }
            private set { }
        }
        public string ThongTinBoiThuong
        {
            get { return thongTinBoiThuong; }
            private set { }
        }

        public void ThuePhong()
        {
            if (DateTime.Now >= thoiHan)
            {
                Console.WriteLine("Hop dong het han");
            }
            else if (phongTro.DaThue)
            {
                Console.WriteLine("Phong da duoc thue.");
            }
            else
            {
                Console.WriteLine("Thuê phòng thành công.");
                phongTro.DaThue = true;
                EphongDaDuocThue?.Invoke(this);
            }
        }
    }
}
