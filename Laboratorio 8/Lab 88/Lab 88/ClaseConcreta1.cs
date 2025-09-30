using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_88
{
    class ClaseConcreta1 : ClaseAbstracta
    {
        protected override string tomarValor()
        {
            return "ClaseConcreta1";
        }

        public override string prefoxValor(string prefix)
        {
            return $"{prefix}ClaseConcreta1";
        }
    }
}
