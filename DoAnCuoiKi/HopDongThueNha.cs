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
        public event Action<HopDongThueNha> EDaThue;

        public HopDongThueNha(int tienDatCoc, PhongTro phongTro, NguoiChoThue nguoiChoThue, NguoiThue nguoiThue, DateTime thoiHan, string thongTinBoiThuong)
        {
            this.tienDatCoc = tienDatCoc;
            this.phongTro = phongTro;
            this.nguoiChoThue = nguoiChoThue;
            this.nguoiThue = nguoiThue;
            this.thoiHan = thoiHan;
            this.thongTinBoiThuong = thongTinBoiThuong;
            DaThue = false;
        }
        public bool DaThue { get; private set; }
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
        public void ThuePhong()
        {
            if (DateTime.Now >= thoiHan)
            {
                Console.WriteLine("Hop dong het han.");
            }
            else if (DaThue == true)
            {
                Console.WriteLine("Phong hien da co nguoi thue.");
            }
            else
            {
                Console.WriteLine("Thue phong thanh cong.");
                DaThue = true;
                if (EDaThue != null)
                {
                    EDaThue.Invoke(this);
                }
            }
        }
    }
}
