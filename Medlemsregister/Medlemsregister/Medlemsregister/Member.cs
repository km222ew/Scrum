using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medlemsregister
{
    class Member : IComparable, IComparable <Member>        
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

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            Member other = (Member)obj;

            if (other == null)
            {
                throw new ArgumentException();
            }

            return this.Name.CompareTo(other.Name);

        }

        public int CompareTo(Member other)
        {
            if (other == null)
            {
                return 1;
            }

            Member obj = (Member)other;

            if (other == null)
            {
                throw new ArgumentException();
            }

            return this.Name.CompareTo(other.Name);
        }

        public Member(string name)
        {
            Name = name;
            
        }

        public Member(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;        
        
        }


    }
}
