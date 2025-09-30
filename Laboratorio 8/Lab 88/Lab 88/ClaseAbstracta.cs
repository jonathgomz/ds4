using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_88
{
    abstract class ClaseAbstracta
    {
        abstract protected string tomarValor();
        abstract public string prefoxValor(string prefix);

        public void printOut()
        {
            Console.WriteLine(tomarValor());
        }
    }


}
