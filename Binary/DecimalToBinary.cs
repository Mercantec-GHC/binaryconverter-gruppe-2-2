using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryConverter
{
    public static class DecimalToBinary
    {
        public static void Run()
        {
            Console.WriteLine("Decimal til Bin�r IP-Konverter");
            Console.Write("Indtast en decimal IP-adresse (for eksempel: 192.168.1.1): ");

            string decimalInput = Console.ReadLine();

            string[] oktetter = decimalInput.Split('.'); // Opdeler oktetter med et ".".
            if (oktetter.Length != 4 || !OktetGyldig(oktetter)) // Loop til at kontrollere om der er lavet 4 oktetter.
            {
                Console.WriteLine("Ugyldigt! Du skal indtaste 4 tal mellem 0 og 255, adskilt af punktummer.");
                return;
            }

            string bin�rIP = KonverterDecimalTilBin�r(decimalInput);
            Console.WriteLine($"Bin�r: {bin�rIP}");
        }

        static bool OktetGyldig(string[] oktetter) // Loop der tjekker om de tastede tal er gyldigt.
        {
            foreach (string oktet in oktetter)
            {
                if (!int.TryParse(oktet, out int tal) || tal < 0 || tal > 255) // kontrol for at tallet skal v�re mellem 0 og 255.
                    return false;
            }
            return true;
        }

        public static string KonverterDecimalTilBin�r(string decimalIP)
        {
            string[] decimaleOktetter = decimalIP.Split('.');
            string[] bin�reOktetter = new string[4];

            for (int i = 0; i < 4; i++) 
            {
                int tal = int.Parse(decimaleOktetter[i]); //kontrollere om der er intastet heltal.
                string bin�r = "";

                int v�rdi = 128;
                for (int i2 = 0; i2 < 8; i2++)
                {
                    if (tal >= v�rdi)
                    { 
                        bin�r += "1"; 
                        tal -= v�rdi;
                    }
                    else
                    {
                        bin�r += "0";
                    }
                    v�rdi /= 2;
                }

                bin�reOktetter[i] = bin�r;
            }

            return string.Join(".", bin�reOktetter);
        }
    }
}