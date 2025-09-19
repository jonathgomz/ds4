class Program
{
    static void Main(string[] args)
    {
        int numeroUno = 70;
        double numeroDos = 67.89;
        double numeroTres = 67.89;
        Console.WriteLine(Suma(numeroUno, numeroDos));
        Console.WriteLine(Suma(numeroDos, numeroTres, numeroTres));

    }
    static double Suma(int x, double y, double z = 0)
    {
               return x + y + z;
    }
    

}