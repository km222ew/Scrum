using System;
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
        Name,
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

    }
}
