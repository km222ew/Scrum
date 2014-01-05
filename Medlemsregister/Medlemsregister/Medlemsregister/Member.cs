using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medlemsregister
{
    class Member
        //: IComparable, IComparable <Member>
    {

        private string _name;
        private string _phoneNumber;

        public string Name
        {

            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }
                _name = value;
            }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }
                _phoneNumber = value;
            }
        

        }

        public Member(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;        
        
        }


    }
}
