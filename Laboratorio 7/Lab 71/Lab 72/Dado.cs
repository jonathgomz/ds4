using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_72
{
    class Dado
    {
        private int valor;
        private static Random aleatorio;

        public Dado()
        {
            aleatorio = new Random();
        }
        public void Tirar()
        {
                       valor = aleatorio.Next(1, 7);
        }
        public void Imprimir()
        {
            Console.WriteLine("Valor del dado es: " + valor);
        }
        public int RetornarValor()
        {
            return valor;
        }
    }
}
