using System;
class Program
{
    static double calculoArea(double radio)
    {
        return Math.PI * radio * radio;
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Ingrese el radio del circulo:");
        double radio = Convert.ToDouble(Console.ReadLine());
        double area = calculoArea(radio);
        Console.WriteLine($"El area del circulo con radio {radio} es: {area}");
    }
}