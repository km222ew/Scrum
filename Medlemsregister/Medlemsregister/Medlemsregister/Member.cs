﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Medlemsregister
{
    //Gör att object av klassen kan sparas ner på fil
    [Serializable()]
    class Member : IComparable, IComparable <Member>        
    {
        private string _firstname;
        private string _lastName;
        private int _phoneNumber;
        private int _iD;

        public string FirstName
        {
            get { return _firstname; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }
                _firstname = value;
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }
                _lastName = value;
            }
        }

        public int PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }        
        }

        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }
        
        //Gör att man kan sortera listan med medlemmar, i det här fallet sorteras de på id-numret
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

            return this.ID.CompareTo(other.ID);
        }

        //Gör att man kan sortera listan med medlemmar, i det här fallet sorteras de på id-numret
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

            return this.ID.CompareTo(other.ID);
        }

        public Member(string name, string lastName, int phoneNumber, int iD)
        {
            FirstName = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            ID = iD;
        
        }
    }
}
