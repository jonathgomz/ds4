using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_82
{
    public class Cuenta
    {
        private string idCuenta;
        
        public Cuenta(string prmtIdCuenta)
        {
            this.idCuenta = prmtIdCuenta;
            System.Console.WriteLine("Constructor clase base para cuenta {0}", prmtIdCuenta);
        }
        public virtual void CalcularIntereses()
        {
            System.Console.WriteLine("Cuenta.CalcularIntereses() efectuado para la cuenta {0}", this.idCuenta);
        }
        public string getIdCuenta()
        {
            return this.idCuenta;
        }

    }

}
