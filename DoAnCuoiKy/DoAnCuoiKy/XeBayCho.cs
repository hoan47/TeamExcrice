using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
{
    class XeBayCho : Xe
    {
        public XeBayCho(string hangXe, DateTime namMua, double soKilomet, bool baoHiem, EMucDich mucDich, decimal giaThueMotNgay, 
            decimal tienCoc, decimal giaDenXuotXe, decimal giaDenBeBanh, decimal giaDenHuDen, decimal uuDai, decimal tangGia) 
            : base(hangXe, namMua, soKilomet, baoHiem, mucDich, giaThueMotNgay, tienCoc, giaDenXuotXe, giaDenBeBanh, giaDenHuDen, uuDai, tangGia)
        { }
        public override void XuatThongTinXe()
        {
            Console.WriteLine("Loai xe:  Xe bay cho");
        }
    }
}
