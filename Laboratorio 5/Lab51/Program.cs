using System;

class PruebaVector1
{

    private int[] sueldos; //Declaración de un vector

    public void Cargar()
    {
        sueldos = new int[6];
        for (int f = 1; f <= 5; f++)
        {
            Console.Write("Ingrese el saldo del operario" + f + ": ");
            String linea;
            linea = Console.ReadLine();
            sueldos[f] = int.Parse(linea);
        }

    }
    public void Imprimir()
    {
        Console.Write("Los 5 sueldos de los operarios son: \n");
        for (int f = 1; f <= 5; f++)
        {
            Console.Write("[" + sueldos[f] + "]");
        }
        Console.ReadKey();
    }

    static void Main(string[] args)
    {
        PruebaVector1 pv = new PruebaVector1();
        pv.Cargar();
        pv.Imprimir();
    }
}