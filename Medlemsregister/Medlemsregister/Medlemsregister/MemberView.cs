using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medlemsregister
{
    class MemberView
    {

        public void Render(List<Member> members)
        {
            foreach (Member member in members)
                {
                    Console.WriteLine("════════════════════════════════════");
                    Console.WriteLine("Medlemsnummer: {0}",member.ID);
                    Console.WriteLine("       Medlem: {0} {1}", member.FirstName, member.LastName);
                    Console.WriteLine("════════════════════════════════════");
                    Console.WriteLine("\n");
                }
         }

        public void Render(Member member)
        {
            //RenderHeader(recipe.Name);

            Console.WriteLine("══════════════════");
            Console.WriteLine("Medlemsnummer: {0}", member.ID);
            Console.WriteLine("      Förnamn: {0}", member.FirstName);
            Console.WriteLine("    Efternamn: {0}", member.LastName);
            Console.WriteLine("Telefonnummer: {0}", member.PhoneNumber);
            Console.WriteLine("══════════════════");
            Console.WriteLine("\n");
        }
    }
}
