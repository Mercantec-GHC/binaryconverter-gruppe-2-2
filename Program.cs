namespace BinaryConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Velkommen til BinaryConverter opgaven!");
            Help();
            bool isRunning = true;
            while (isRunning)
            {
                string? choice = Console.ReadLine();
                switch (choice?.ToLower())
                {
                    case "1":
                        DecimalToBinary.Run();
                        break;
                    case "2":
                        BinaryToDecimal.Run();
                        break;
                    case "3":
                        Subnet.Run();
                        break;
                    case "?":
                        Help();
                        break;
                    case "exit":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Ugyldigt valg. Prøv igen.");
                        break;
                }
            }
        }

        public static void Help()
        {
            Console.WriteLine("--------------MENU--------------");
            Console.WriteLine("-* 1: Decimal to Binary       *-");
            Console.WriteLine("-* 2: Binary to Decimal       *-");
            Console.WriteLine("-* 3: Subnet                  *-");
            Console.WriteLine("-* ?: Help                    *-");
            Console.WriteLine("-* exit: Afslut programmet    *-");
            Console.WriteLine("--------------------------------");
            Console.Write("Indtast dit valg: ");
        }
    }
}
