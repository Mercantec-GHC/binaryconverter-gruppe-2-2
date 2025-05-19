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
                if (!int.TryParse(oktet, out int tal) || tal < 0 || tal > 255) // kontrol for at tallet er mellem 0 og 255.
                    return false;
            }
            return true;
        }

        public static string KonverterDecimalTilBinær(string decimalIP)
        {
            string[] decimaleOktetter = decimalIP.Split('.'); // Splitter brugerens indtastning i 4 dele.
            string[] binæreOktetter = new string[4]; // Forbereder et sted at gemme de binær talene i de 4 oktetter.

            for (int i = 0; i < 4; i++) // Kører igennem de 4 oktetter.
            {
                int tal = int.Parse(decimaleOktetter[i]); // Laver oktetten til et heltal gøres klar til at lave en 8-bits binær string.
                string binær = "";

                int værdi = 128; //værdi sættes til 128, da det er det højeste tal der kan trækkes fra når der skal laves fra decimal til binær.

                for (int i2 = 0; i2 < 8; i2++) // Et loop hvor den manuel laver tal ved at tjekke hver bit-værdi fra 128 til 1.
                {
                    if (tal >= værdi) // Hvis tallet er større eller er lig med værdig, bliver der tilføjet '1' til stringen og værdien trækkes fra tal.
                    { 
                        binær += "1"; 
                        tal -= værdi;
                    }
                    else
                    {
                        binær += "0"; // Hvis tallet IKKE er større end eller er lig med, bliver der tilføjet '0' til stringen.
                    }
                    værdi /= 2; //Bitværdien halveres hver gang: 128, 64, 32, 16, 8, 4, 2, 1.
                }

                binæreOktetter[i] = binær;
            }

            return string.Join(".", binæreOktetter);
        }
    }
}