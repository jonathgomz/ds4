using System;
namespace Labortorio21
{
    public class program
    {
    public static void Main()
        {
        MyClass.Valor = 1;
        Console.WriteLine(MyClass.Valor); 
        }
    }
public class MyClass
    {
        public static int Valor;
}
}