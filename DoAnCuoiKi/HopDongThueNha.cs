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
        public event Action<HopDongThueNha> EThuePhong;

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
        public EKetQuaThue ThuePhong()
        {
            if (DateTime.Now >= thoiHan)
            {
                return EKetQuaThue.HetHan;
            }
            else if (DaThue == true)
            {
                return EKetQuaThue.DaCoNguoiThue;
            }
            else
            {
                DaThue = true;
                EThuePhong?.Invoke(this);
                return EKetQuaThue.ThanhCong;
            }
        }
        public enum EKetQuaThue
        {
            HetHan,
            DaCoNguoiThue,
            ThanhCong
        }
    }
}
