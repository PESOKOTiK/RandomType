using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomType.MVVM.Models
{
    public class Words
    {
        public string? Word;
        public int Lehgth;

        public Words(string? word,int length)
        {
            this.Word=word;
            Lehgth=length;
        }

        public override string ToString()
        {
            return Word;
        }
    }
}
