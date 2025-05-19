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
                if (!int.TryParse(oktet, out int tal) || tal < 0 || tal > 255) // kontrol for at tallet er mellem 0 og 255.
                    return false;
            }
            return true;
        }

        public static string KonverterDecimalTilBin�r(string decimalIP)
        {
            string[] decimaleOktetter = decimalIP.Split('.'); // Splitter brugerens indtastning i 4 dele.
            string[] bin�reOktetter = new string[4]; // Forbereder et sted at gemme de bin�r talene i de 4 oktetter.

            for (int i = 0; i < 4; i++) // K�rer igennem de 4 oktetter.
            {
                int tal = int.Parse(decimaleOktetter[i]); // Laver oktetten til et heltal g�res klar til at lave en 8-bits bin�r string.
                string bin�r = "";

                int v�rdi = 128; //v�rdi s�ttes til 128, da det er det h�jeste tal der kan tr�kkes fra n�r der skal laves fra decimal til bin�r.

                for (int i2 = 0; i2 < 8; i2++) // Et loop hvor den manuel laver tal ved at tjekke hver bit-v�rdi fra 128 til 1.
                {
                    if (tal >= v�rdi) // Hvis tallet er st�rre eller er lig med v�rdig, bliver der tilf�jet '1' til stringen og v�rdien tr�kkes fra tal.
                    { 
                        bin�r += "1"; 
                        tal -= v�rdi;
                    }
                    else
                    {
                        bin�r += "0"; // Hvis tallet IKKE er st�rre end eller er lig med, bliver der tilf�jet '0' til stringen.
                    }
                    v�rdi /= 2; //Bitv�rdien halveres hver gang: 128, 64, 32, 16, 8, 4, 2, 1.
                }

                bin�reOktetter[i] = bin�r;
            }

            return string.Join(".", bin�reOktetter);
        }
    }
}