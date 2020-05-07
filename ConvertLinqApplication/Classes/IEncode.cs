using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConvertLinqApplication.Classes
{
  public  interface IEncode
    {
        static readonly string Alphabet;
        static readonly int Base;
        string Encodeint(int i);
        public  int Decode(string s);
    }
}
