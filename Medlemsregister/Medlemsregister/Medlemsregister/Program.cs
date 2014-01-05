using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medlemsregister
{
    class Program
    {
        static void Main(string[] args)
        {

            bool terminate = false;

            do
            {
                switch (ApplicationMenu())
                {

                    case 0:
                        terminate = true;
                        break;

                    case 1:
                        //CreateMember();
                        break;

                    case 2:
                        //EditMember();
                        break;

                    case 3:
                        //DeleteMember();
                        break;

                    case 4:
                        //ViewMember();
                        break;

                    case 5:
                        bool viewAll = true;
                        //ViewMember(viewAll);
                        break;
                }
            }
            while (!terminate);

        }

        private static int ApplicationMenu()
        {
            int index;

            do
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" ╔═══════════════════════════════════╗ ");
                Console.WriteLine(" ║           Medlemsregister         ║ ");
                Console.WriteLine(" ╚═══════════════════════════════════╝ ");
                Console.ResetColor();
                Console.WriteLine("\n - Arkiv -----------------------------\n");
                Console.WriteLine(" 0. Avsluta.");
                Console.WriteLine(" 1. Registrera ny medlem.");
                Console.WriteLine("\n - Redigera --------------------------\n");
                Console.WriteLine(" 2. Ändra uppgifter på befintlig medlem.");
                Console.WriteLine(" 3. Ta bort medlem.");
                Console.WriteLine("\n - Visa ------------------------------\n");
                Console.WriteLine(" 4. Visa medlem.");
                Console.WriteLine(" 5. Visa alla medlemmar.");
                Console.WriteLine("\n ═════════════════════════════════════\n");
                Console.Write(" Ange menyval [0-5]: ");

                if (int.TryParse(Console.ReadLine(), out index) && index >= 0 && index <= 6)
                {
                    return index;
                }

                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n FEL! Ange ett nummer mellan 0 och 5.\n");
                //ContinueOnKeyPressed();
            } while (true);

        }

    }
}
