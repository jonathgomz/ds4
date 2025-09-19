using System;

class Program
{
    static double calcularPerimetro(double lado1, double lado2)
    {
        return 2 * (lado1 + lado2);
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Ingrese el primer lado del rectangulo:");
        double lado1 = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Ingrese el segundo lado del rectangulo:");
        double lado2 = Convert.ToDouble(Console.ReadLine());
        double perimetro = calcularPerimetro(lado1, lado2);
        Console.WriteLine($"El perimetro del rectangulo con lados {lado1} y {lado2} es: {perimetro}");
    }
}