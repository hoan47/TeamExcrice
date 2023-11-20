using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
{
    static class DauVaoBanPhim
    {
        public static int Int(int batDau, int ketThuc, string noiDung)
        {
            int giaTri;
            while (true)
            {
                try
                {
                    Console.Write(noiDung);
                    giaTri = int.Parse(Console.ReadLine());
                    if ((batDau <= giaTri && giaTri <= ketThuc) == false)
                    {
                        continue;
                    }
                    Console.WriteLine();
                    return giaTri;
                }
                catch (FormatException)
                {
                    continue;
                }
            }
        }
        public static string String(string noiDung)
        {
            Console.Write(noiDung);
            return Console.ReadLine();
        }
        static public DateTime DateTime_(string noiDung)
        {
            DateTime ngayThang;
            while (true)
            {
                Console.Write(noiDung);
                if (DateTime.TryParse(Console.ReadLine(), out ngayThang))
                {
                    return ngayThang;
                }
            }
        }
        static public double Double(string noiDung)
        {
            double giaTri;
            while (true)
            {
                try
                {
                    Console.Write(noiDung);
                    giaTri = double.Parse(Console.ReadLine());
                    return giaTri;
                }
                catch (FormatException)
                {
                    continue;
                }
            }
        }
        static public decimal Decimal(string noiDung)
        {
            decimal giaTri;
            while (true)
            {
                try
                {
                    Console.Write(noiDung);
                    giaTri = decimal.Parse(Console.ReadLine());
                    return giaTri;
                }
                catch (FormatException)
                {
                    continue;
                }
            }
        }
        static public bool Bool(string noiDung)
        {
            bool giaTri;
            while (true)
            {
                try
                {
                    Console.Write(noiDung);
                    giaTri = bool.Parse(Console.ReadLine());
                    return giaTri;
                }
                catch (FormatException)
                {
                    continue;
                }
            }
        }
        static public Xe.EMucDich MucDich()
        {
            int giaTri;

            while (true)
            {
                try
                {
                    Console.WriteLine("Muc dich mua xe: ");
                    Console.WriteLine("1. Du lich");
                    Console.WriteLine("2. Dam cuoi");
                    Console.WriteLine("3. Tap lai");
                    Console.WriteLine("4. Khac");
                    Console.Write("Chon 1 trong 4: ");
                    giaTri = int.Parse(Console.ReadLine());
                    switch (giaTri)
                    {
                        case 1:
                            return Xe.EMucDich.DuLich;
                        case 2:
                            return Xe.EMucDich.DamCuoi;
                        case 3:
                            return Xe.EMucDich.TapLai;
                        case 4:
                            return Xe.EMucDich.Khac;
                    }
                }
                catch (FormatException)
                {
                    continue;
                }
            }
        }
    }
}
