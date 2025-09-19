class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Digite el radio del circulo");
        double radio = double.Parse(Console.ReadLine());
        double area = Math.Pow(radio, 2) * Math.PI;
        Console.WriteLine($"El area del circulo es: {area}");  
    }
}