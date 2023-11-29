
using System;

namespace DoAnCuoiKy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Excel.MoUngDung();
                DuLieu.KhoiTaoDuLieu();
                ChayChuongTrinh.ChuongTrinh();
                DuLieu.LuuToanBoDuLieu();
            }
            finally
            {
                Excel.DongUngDung();
            }
        }
    }
}
