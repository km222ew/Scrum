﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Medlemsregister
{
    class Program
    {
        static void Main(string[] args)
        {
            //Laddar den sparade listan med medlemmar från filen
            List<Member> memberRegister = OpenRegister();

            bool terminate = false;

            do
            {
                switch (ApplicationMenu())
                {

                    case 0:
                        SavePrompt(memberRegister);
                        terminate = true;
                        break;

                    case 1:
                        SaveRegister(memberRegister);
                        break;

                    case 2:
                        CreateMember(memberRegister);
                        break;

                    case 3:
                        EditMember(memberRegister);
                        break;

                    case 4:
                        DeleteMember(memberRegister);
                        break;

                    case 5:
                        ViewMember(memberRegister);
                        break;

                    case 6:
                        bool viewAll = true;
                        ViewMember(memberRegister, viewAll);
                        break;
                }
            }
            while (!terminate);
        }

        private static void ContinueOnKeyPressed()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write("\n   Tryck tangent för att fortsätta   ");
            Console.ResetColor();
            Console.CursorVisible = false;
            Console.ReadKey(true);
            Console.Clear();
            Console.CursorVisible = true;
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
                Console.WriteLine(" 1. Spara register.");
                Console.WriteLine(" 2. Registrera ny medlem.");
                Console.WriteLine("\n - Redigera --------------------------\n");
                Console.WriteLine(" 3. Ändra uppgifter på befintlig medlem.");
                Console.WriteLine(" 4. Ta bort medlem.");
                Console.WriteLine("\n - Visa ------------------------------\n");
                Console.WriteLine(" 5. Visa medlem.");
                Console.WriteLine(" 6. Visa alla medlemmar.");
                Console.WriteLine("\n ═════════════════════════════════════\n");
                Console.Write(" Ange menyval [0-6]: ");

                if (int.TryParse(Console.ReadLine(), out index) && index >= 0 && index <= 6)
                {
                    return index;
                }

                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n FEL! Ange ett nummer mellan 0 och 6.\n");
                ContinueOnKeyPressed();
            } while (true);
        }

        //Används för att välja en medlem att hantera
        private static Member GetMember(string header, List<Member> members)
        {
            do
            {
                int index = 0;
                int read = 0;
                Member memberSelection = null;

                if (members == null || members.Count == 0)
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n Det finns inga medlemmar i registret");
                    Console.ResetColor();
                    ContinueOnKeyPressed();
                    return memberSelection;
                }
                else
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" ╔═══════════════════════════════════╗ ");
                    Console.WriteLine(" ║{0}║ ", header);
                    Console.WriteLine(" ╚═══════════════════════════════════╝ ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("\n -------------------------------------\n");
                    Console.WriteLine(" 0. Avbryt.");
                    Console.WriteLine("\n -------------------------------------\n");

                    for (int i = 0; i < members.Count; i++)
                    {
                        index++;
                        Console.WriteLine(" {0}. {1} {2}", index, members[i].FirstName, members[i].LastName);
                    }

                    Console.WriteLine("\n ═════════════════════════════════════\n");
                    Console.Write(" Ange menyval [0-{0}]: ", members.Count);
                    Console.ResetColor();

                    if (int.TryParse(Console.ReadLine(), out read) && read >= 0 && read <= members.Count)
                    {
                        if (read == 0)
                        {
                            memberSelection = null;
                            return memberSelection;
                        }
                        else
                        {
                            read--;
                            memberSelection = members[read];
                            return memberSelection;
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\n FEL! Ange ett nummer mellan 0 och {0}.\n", members.Count);
                        ContinueOnKeyPressed();
                    }
                }
            }
            while (true);
        }

        private static List<Member> CreateMember(List<Member> members)
        {
            string firstName;  
            string lastName;
            int phoneNumber = 0;
            int id;
            int index;

            do
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" ╔═══════════════════════════════════╗ ");
                Console.WriteLine(" ║       Registrera ny medlem        ║ ");
                Console.WriteLine(" ╚═══════════════════════════════════╝ ");
                Console.ResetColor();
                Console.WriteLine("\n -------------------------------------\n");
                Console.WriteLine(" 0. Avbryt.");
                Console.WriteLine(" 1. Registrera ny medlem.");
                Console.WriteLine("\n -------------------------------------\n");
                Console.Write(" Ange menyval [0-1]: ");

                if (int.TryParse(Console.ReadLine(), out index) && index >= 0 && index <= 1)
                {
                    if (index == 1)
                    {                    
                        Console.WriteLine("\n ═════════════════════════════════════\n");

                        Console.Write(" Förnamn: ");
                        firstName = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(firstName))
                        {
                            Messages(0);
                            continue;
                        }

                        Console.Write(" Efternamn: ");
                        lastName = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(lastName))
                        {
                            Messages(0);
                            continue;
                        }
                        
                        Console.Write(" Telefonnummer: ");
                        if (int.TryParse(Console.ReadLine(), out phoneNumber) && phoneNumber >= 0 && phoneNumber <= int.MaxValue)
                        {
                            id = MemberId(members);
                            members.Add(new Member(firstName, lastName, phoneNumber, id));

                            Console.WriteLine("\n ═════════════════════════════════════\n");
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(" ╔═══════════════════════════════════╗ ");
                            Console.WriteLine(" ║       Medlemmen har skapats       ║ ");
                            Console.WriteLine(" ╚═══════════════════════════════════╝ ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ResetColor();                            

                            SavePrompt(members);                            
                        }
                        else
                        {
                            Messages(1);
                        }

                        phoneNumber = 0;                    
                    }
                    else
                    {
                        return members;
                    }                
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n FEL! Ange nummer 0 eller 1.\n");
                    ContinueOnKeyPressed();
                }
            } while (true);
        }
        
        //Olika varnings-meddelanden
        private static void Messages(int choice)
        {
            if (choice == 0)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" ╔══════════════════════════════════════════╗ ");
                Console.WriteLine(" ║    Du måste fylla i alla fält för att    ║ ");
                Console.WriteLine(" ║        kunna registrera en medlem        ║ ");
                Console.WriteLine(" ╚══════════════════════════════════════════╝ ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ResetColor();
                ContinueOnKeyPressed();
            }
            else if (choice == 1) 
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" ╔══════════════════════════════════════════╗ ");
                Console.WriteLine(" ║      Fältet får inte vara tomt och       ║ ");
                Console.WriteLine(" ║        får bara innehålla siffror        ║ ");
                Console.WriteLine(" ╚══════════════════════════════════════════╝ ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ResetColor();
                ContinueOnKeyPressed();
            }
            else if (choice == 2)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" ╔══════════════════════════════════════════╗ ");
                Console.WriteLine(" ║        Fältet får inte vara tomt         ║ ");
                Console.WriteLine(" ╚══════════════════════════════════════════╝ ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ResetColor();
                ContinueOnKeyPressed();
            }
            else if (choice == 3)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n ╔══════════════════════════════════════════╗ ");
                Console.WriteLine(" ║          Medlemmen har ändrats           ║ ");
                Console.WriteLine(" ╚══════════════════════════════════════════╝ \n");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ResetColor();                
            }            
        }

        private static void SavePrompt(List<Member> members)
        {
            Console.WriteLine("\n Vill du spara registret [j/n]?");

            ConsoleKeyInfo tan = Console.ReadKey(true);

            if (tan.KeyChar == 'j')
            {
                SaveRegister(members);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nInget har sparats");
                Console.ResetColor();
                ContinueOnKeyPressed();
            }        
        }

        //Genererar ett id-nummer
        private static int MemberId(List<Member> members)
        {
            int id = 0;

            for (int i = 0; i < members.Count; i++ )
            {
                if (members.ElementAt(i).ID >= id )
                {
                    id = (members.ElementAt(i).ID) + 1;
                }
            }
            return id;
        }

        private static List<Member> OpenRegister()
        {
            List<Member> memberRegister = new List<Member>();

            try
            {
                using (Stream stream = File.Open("register.bin", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();

                    List<Member> register = (List<Member>)bin.Deserialize(stream);
                    
                    memberRegister = register;

                    return memberRegister;
                }
            }
            catch (IOException)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" ╔═══════════════════════════════════╗ ");
                Console.WriteLine(" ║   Spara registret för att öppna   ║ ");
                Console.WriteLine(" ╚═══════════════════════════════════╝ ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ResetColor();

                ContinueOnKeyPressed();

                return memberRegister;
            }            
        }
		    
        private static void SaveRegister(List<Member> members)
        {
            try
            {
                using (Stream stream = File.Open("register.bin", FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    members.Sort();
                    bin.Serialize(stream, members);

                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" ╔═══════════════════════════════════╗ ");
                    Console.WriteLine(" ║       Registret har sparats       ║ ");
                    Console.WriteLine(" ╚═══════════════════════════════════╝ ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ResetColor();
                    ContinueOnKeyPressed();
                }
            }
            catch (IOException)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" ╔═══════════════════════════════════╗ ");
                Console.WriteLine(" ║  Ett fel inträffade vid sparning  ║ ");
                Console.WriteLine(" ╚═══════════════════════════════════╝ ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ResetColor();

                ContinueOnKeyPressed();
            }            
        }

        private static void DeleteMember(List<Member> members)
        {
            do
            {
                string header = "     Välj medlem att ta bort       ";
                Member memberSelection = GetMember(header, members);

                if (memberSelection == null)
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.WriteLine();
                    Console.WriteLine("Är du säker på att du vill ta bort medlem '{0}, {1} {2} [j/n]?", memberSelection.ID, memberSelection.FirstName, memberSelection.LastName);
                    Console.ResetColor();

                    ConsoleKeyInfo tan = Console.ReadKey(true);

                    if (tan.KeyChar == 'j')
                    {
                        members.Remove(memberSelection);

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("\nMedlemmen har tagits bort");
                        Console.ResetColor();
                        ContinueOnKeyPressed();
                    }
                    else if(tan.KeyChar == 'n')
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\nIngen medlem har tagits bort");
                        Console.ResetColor();
                        ContinueOnKeyPressed();
                    }
                }
            } while (true);
        }
        private static void EditMember(List<Member> members) 
        {
            int index;
            string firstName;
            string lastName;
            int phoneNumber = 0;

            string header = "       Välj medlem att ändra       ";
            Member memberSelection = GetMember(header, members);

            do
            {                
                if (memberSelection == null)
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" ╔═══════════════════════════════════╗ ");
                    Console.WriteLine(" ║         Ändring av medlem         ║ ");
                    Console.WriteLine(" ╚═══════════════════════════════════╝ ");
                    Console.ResetColor();
                    Console.WriteLine("\n -------------------------------------\n");
                    Console.WriteLine(" 0. Avbryt.");
                    Console.WriteLine("\n -------------------------------------\n");
                    Console.WriteLine(" 1. Ändra förnamn");
                    Console.WriteLine(" 2. Ändra efternamn");
                    Console.WriteLine(" 3. Ändra telefonnummer");
                    Console.WriteLine("\n ═════════════════════════════════════\n");
                    Console.Write(" Ange menyval [0-3]: ");
                    
                    if (int.TryParse(Console.ReadLine(), out index) && index >= 0 && index <= 3)
                    {
                        if (index == 1)
                        {
                            Console.WriteLine("\n -------------------------------------\n");
                            Console.Write(" Förnamn: ");
                            firstName = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(firstName))
                            {
                                Messages(2);
                                continue;
                            }

                            memberSelection.FirstName = firstName;

                            Messages(3);

                            SavePrompt(members);
                            
                        }
                        else if (index == 2)
                        {
                            Console.WriteLine("\n -------------------------------------\n");
                            Console.Write(" Efternamn: ");
                            lastName = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(lastName))
                            {
                                Messages(2);
                                continue;
                            }

                            memberSelection.LastName = lastName;

                            Messages(3);

                            SavePrompt(members);
                        }
                        else if (index == 3)
                        {
                            Console.WriteLine("\n -------------------------------------\n");
                            Console.Write(" Telefonnummer: ");
                            if (int.TryParse(Console.ReadLine(), out phoneNumber) && phoneNumber >= 0 && phoneNumber <= int.MaxValue)
                            {
                                memberSelection.PhoneNumber = phoneNumber;

                                Messages(3);

                                SavePrompt(members);
                            }

                            Messages(1);
                        }
                        else
                        {
                            break;
                        }                        
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\n FEL! Ange nummer mellan 0 och 3.\n");
                        ContinueOnKeyPressed();
                    }                    
                }
            } while (true);        
        }

        //Visar antingen en eller alla medlemmar beroende på om viewAll är true eller false
        private static void ViewMember(List<Member> members, bool viewAll = false)
        {
            MemberView memberView = new MemberView();
            
            if (viewAll == false)
            {
                do
                {
                    string header = "       Välj medlem att visa        ";
                    Member memberSelection = GetMember(header, members);

                    if (memberSelection == null)
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        
                        memberView.Render(memberSelection);

                        ContinueOnKeyPressed();
                    }
                } while (true);
            }            
            else
            {
                if (members == null || members.Count == 0)
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n Det finns inga medlemmar i registret");
                    Console.ResetColor();
                    ContinueOnKeyPressed();
                }
                else
                {
                    Console.Clear();
                    memberView.Render(members);
                    ContinueOnKeyPressed();
                }
            }
        }
    }
}
