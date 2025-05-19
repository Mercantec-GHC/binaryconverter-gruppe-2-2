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
            Console.WriteLine("Bin�r til Decimal IP-Konverter");
            Console.Write("Indtast en bin�r IP-adresse (for eksempel: 11000000.10101000.00000001.00000001): ");

            string binaryInput = Console.ReadLine();

            string[] oktetter = binaryInput.Split('.'); 
            if (oktetter.Length != 4 || !OktetGyldig(oktetter))
            {
                Console.WriteLine("Ugyldigt! Du skal indtaste 4 oktetter med 8 bin�re tal hver, adskilt af punktummer.");
                return;
            }

            string decimalIP = KonverterBin�rTilDecimal(binaryInput);
            Console.WriteLine($"IP: {decimalIP}");
        }

        static bool OktetGyldig(string[] oktetter) //loop til at kontrollere at oktetterne er bin�re eller ej.
        {
            foreach (string oktet in oktetter)
            {
                if (oktet.Length != 8 || !ErBin�r(oktet))
                    return false;
            }
            return true;
        }

        static bool ErBin�r(string s) //Kontrollere at du kun bruger 1 & 0 i din oktekt.
        {
            foreach (char c in s)
            {
                if (c != '0' && c != '1') // Hvis der IKKE er '0' eller '1', s� skal den return og lave fejl.
                    return false;
            }
            return true;
        }


        public static string KonverterBin�rTilDecimal(string bin�r)
        {
            string[] bin�reOktetter = bin�r.Split('.'); // Splitter brugerens indtasning i 4 dele.
            string[] decimaleOktetter = new string[4]; // Forbereder et sted at gemme decimal tal i de 4 oktetter.

            for (int antaloktetter = 0; antaloktetter < 4; antaloktetter++) // Regner v�rdi ud for hver oktet fra bin�r til decimal.
            {
                string bin�rOktet = bin�reOktetter[antaloktetter]; 
                int decimalOktet = 0;

                int bitV�rdi = 128; // Den h�jeste bitv�rdi 128, 64, 32, 16, 8, 4, 2, 1.

                for (int i = 0; i < bin�rOktet.Length; i++) // G�r igennem de 8 bits i oktetten og laver det til '1' eller '0'.
                {
                    int bit = bin�rOktet[i] - '0';
                    decimalOktet += bit * bitV�rdi;
                    bitV�rdi /= 2; 
                }

                decimaleOktetter[antaloktetter] = decimalOktet.ToString();
            }

            return string.Join(".", decimaleOktetter);
        }
    }
}