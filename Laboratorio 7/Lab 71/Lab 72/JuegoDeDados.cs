using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_72
{
    class JuegoDeDados
    {
        Dado dado1 = new Dado();
        Dado dado2 = new Dado();
        Dado dado3 = new Dado();

        public void Jugar()
        {
            dado1.Tirar();
            dado1.Imprimir();
            dado2.Tirar();
            dado2.Imprimir();
            dado3.Tirar();
            dado3.Imprimir();

            if (dado1.RetornarValor() == dado2.RetornarValor()
                && dado1.RetornarValor() == dado3.RetornarValor())
            {
                Console.WriteLine("Gano");
            }
            else
            {
                Console.WriteLine("Perdio");
            }
            Console.ReadKey();
        }

    }
}    
