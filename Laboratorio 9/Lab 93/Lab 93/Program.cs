public class triangulo
{
    public static void main(string[] args)
    {
        Console.Write("ingrese el primer lado");
        int L1 = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el segundo lado");
        int L2 = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese le tercer lado");
        int L3 = int.Parse(Console.ReadLine());

        if (L1 + L2 > L3 && L1 + L3 > L2 && L2 + L3 > L1)
        {
            if (L1 == L2 && L2 == L3)
            {
                Console.WriteLine("LADOS IGUALES: TRIANGULO EQUILATERO");
            }
            if (L1 == L2 || L1 == L3 || L2 == L3)
            {
                Console.WriteLine("LADOS 1 Y 2 IGUALES: TRIANGULO ISOSELES ");
            }
            else
            {
                Console.WriteLine("LADOS DIFERENTES: TRIANGULO ESCALENO");
            }


        }
        else { Console.WriteLine("NO SE FORMA NINGUN TRIANGULO "); }


    }
}