using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomType.MVVM.Models
{
    public class Words
    {
        public string? word;
        public int lehgth;

        public Words(string Word,int Length)
        {
            word=Word;
            lehgth=Length;
        }

        public override string ToString()
        {
            return word;
        }
    }
}
