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
            Console.WriteLine("Decimal til Binær IP-Konverter");
            Console.Write("Indtast en decimal IP-adresse (for eksempel: 192.168.1.1): ");

            string decimalInput = Console.ReadLine();

            string[] oktetter = decimalInput.Split('.'); // Opdeler oktetter med et ".".
            if (oktetter.Length != 4 || !OktetGyldig(oktetter)) // Loop til at kontrollere om der er lavet 4 oktetter.
            {
                Console.WriteLine("Ugyldigt! Du skal indtaste 4 tal mellem 0 og 255, adskilt af punktummer.");
                return;
            }

            string binærIP = KonverterDecimalTilBinær(decimalInput);
            Console.WriteLine($"Binær: {binærIP}");
        }

        static bool OktetGyldig(string[] oktetter) // Loop der tjekker om de tastede tal er gyldigt.
        {
            foreach (string oktet in oktetter)
            {
                if (!int.TryParse(oktet, out int tal) || tal < 0 || tal > 255) // kontrol for at tallet skal være mellem 0 og 255.
                    return false;
            }
            return true;
        }

        public static string KonverterDecimalTilBinær(string decimalIP)
        {
            string[] decimaleOktetter = decimalIP.Split('.');
            string[] binæreOktetter = new string[4];

            for (int i = 0; i < 4; i++) 
            {
                int tal = int.Parse(decimaleOktetter[i]); //kontrollere om der er intastet heltal.
                string binær = "";

                int værdi = 128;
                for (int i2 = 0; i2 < 8; i2++)
                {
                    if (tal >= værdi)
                    { 
                        binær += "1"; 
                        tal -= værdi;
                    }
                    else
                    {
                        binær += "0";
                    }
                    værdi /= 2;
                }

                binæreOktetter[i] = binær;
            }

            return string.Join(".", binæreOktetter);
        }
    }
}