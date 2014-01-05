using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medlemsregister
{
    public enum MemberReadStatus
    {
        Indefinite,
        New,
        ID,
        PhoneNumber
    }


    class MemberRepository
    {
        private string _path;

        public string Path
        {
            get
            {
                return _path;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }
                _path = value;
            }
        }

        public List<Member> Load()
        {

            List<Member> memberList = new List<Member>();
            MemberReadStatus status = new MemberReadStatus();

            using (StreamReader reader = new StreamReader(Path))
            { 
                int memberNumber = -1;

                string line;
                status = MemberReadStatus.Indefinite;

                while ((line = reader.ReadLine()) != null)
                {
                    
                    
                
                
                }
            
            
            }
        
        
        }


    }
}
