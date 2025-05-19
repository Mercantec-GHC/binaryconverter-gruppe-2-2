using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryConverter
{
    public static class Subnet
    {
        public static void Run()
        {
            Console.WriteLine("Subnet Beregner");
            Console.WriteLine("\nOpgave 1: Lav følgende genbrugelige metoder:");
            CalculateSubnet("192.168.1.1", 24);
            CalculateBroadcastAddress("192.168.1.1", 24);
            CalculateUsableHostInterval("192.168.1.1", 24);
            CalculateNumberOfUsableHosts(24);

            Console.WriteLine("\nOpgave 2: Lav en metode til at tjekke subnet kommunikation:");
            CheckSubnetCommunication("192.168.1.1", 24, "192.168.1.2", 24);
        }

        public static string CalculateSubnet(string ipAddress, int subnetMask)
        {
            Console.WriteLine("- CalculateSubnet(string ipAddress, int subnetMask)");
            return "192.168.1.1";
        }

        public static string CalculateBroadcastAddress(string ipAddress, int subnetMask)
        {
            Console.WriteLine("- CalculateBroadcastAddress(string ipAddress, int subnetMask)");
            return "192.168.1.1";
        }

        public static string CalculateUsableHostInterval(string ipAddress, int subnetMask)
        {
            Console.WriteLine("- CalculateUsableHostInterval(string ipAddress, int subnetMask)");
            return "192.168.1.1";
        }

        public static int CalculateNumberOfUsableHosts(int subnetMask)
        {
            Console.WriteLine("- CalculateNumberOfUsableHosts(int subnetMask)");
            return 24;
        }

        public static bool CheckSubnetCommunication(
            string ipAddress1,
            int subnetMask1,
            string ipAddress2,
            int subnetMask2
        )
        {
            Console.WriteLine(
                "- CheckSubnetCommunication(string ipAddress1, int subnetMask1, string ipAddress2, int subnetMask2)"
            );
            return true;
        }
    }
}
