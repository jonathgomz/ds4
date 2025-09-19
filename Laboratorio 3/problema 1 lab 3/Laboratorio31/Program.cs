using System;

class Program
{
    static int calcular(int a, int b)
    {
        return (a + b) * (a - b);
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Ingrese el primer numero:");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Ingrese el segundo numero:");
        int b = Convert.ToInt32(Console.ReadLine());

        int resultado = calcular(a, b);
        Console.WriteLine($"El resultado de {a} + {b} * {a} - {b} es: {resultado}");
    }
}

