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
                if (c != '0' && c != '1')
                    return false;
            }
            return true;
        }


        public static string KonverterBin�rTilDecimal(string bin�r)
        {
            string[] bin�reOktetter = bin�r.Split('.'); //opdeler oktetter med "." 
            string[] decimaleOktetter = new string[4]; //opdeler en ny string 4 gange.

            for (int antaloktetter = 0; antaloktetter < 4; antaloktetter++) //Start loop
            {
                string bin�rOktet = bin�reOktetter[antaloktetter];
                int decimalOktet = 0;

                int bitV�rdi = 128;

                for (int i = 0; i < bin�rOktet.Length; i++)
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