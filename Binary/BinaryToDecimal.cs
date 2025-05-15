using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryConverter
{
    public static class BinaryToDecimal
    {
        public static void Run()
        {
            Console.WriteLine("Binær til Decimal IP-Konverter");
            Console.Write("Indtast en binær IP-adresse (for eksempel: 11000000.10101000.00000001.00000001): ");

            string binaryInput = Console.ReadLine();

            string[] oktetter = binaryInput.Split('.'); 
            if (oktetter.Length != 4 || !OktetGyldig(oktetter))
            {
                Console.WriteLine("Ugyldigt! Du skal indtaste 4 oktetter med 8 binære tal hver, adskilt af punktummer.");
                return;
            }

            string decimalIP = KonverterBinærTilDecimal(binaryInput);
            Console.WriteLine($"IP: {decimalIP}");
        }

        static bool OktetGyldig(string[] oktetter) //loop til at kontrollere at oktetterne er binære eller ej.
        {
            foreach (string oktet in oktetter)
            {
                if (oktet.Length != 8 || !ErBinær(oktet))
                    return false;
            }
            return true;
        }

        static bool ErBinær(string s) //Kontrollere at du kun bruger 1 & 0 i din oktekt.
        {
            foreach (char c in s)
            {
                if (c != '0' && c != '1')
                    return false;
            }
            return true;
        }


        public static string KonverterBinærTilDecimal(string binær)
        {
            string[] binæreOktetter = binær.Split('.'); //opdeler oktetter med "." 
            string[] decimaleOktetter = new string[4]; //opdeler en ny string 4 gange.

            for (int antaloktetter = 0; antaloktetter < 4; antaloktetter++) //Start loop
            {
                string binærOktet = binæreOktetter[antaloktetter];
                int decimalOktet = 0;

                int bitVærdi = 128;

                for (int i = 0; i < binærOktet.Length; i++)
                {
                    int bit = binærOktet[i] - '0';
                    decimalOktet += bit * bitVærdi;
                    bitVærdi /= 2;
                }

                decimaleOktetter[antaloktetter] = decimalOktet.ToString();
            }

            return string.Join(".", decimaleOktetter);
        }
    }
}