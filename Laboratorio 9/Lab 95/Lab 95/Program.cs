using System;

public class Aleatorio
{
    public Random random;

    public Aleatorio()
    {
        random = new Random();
    }

    public int GenerarNumero(int min, int max)
    {
        return random.Next(min, max + 1);
    }

    public int[] CrearArreglo(int cantidad, int min, int max)
    {
        // Verificar si es posible generar la cantidad solicitada sin repeticiones
        if (cantidad > (max - min + 1))
        {
            Console.WriteLine("Error: No se pueden generar " + cantidad + " números únicos entre " + min + " y " + max);
            return new int[0];
        }

        int[] arreglo = new int[cantidad];

        for (int i = 0; i < cantidad; i++)
        {
            int numero;
            bool repetido;

            do
            {
                repetido = false;
                numero = GenerarNumero(min, max);

                // Verificar si el número ya existe en el arreglo
                for (int j = 0; j < i; j++)
                {
                    if (arreglo[j] == numero)
                    {
                        repetido = true;
                        break;
                    }
                }
            } while (repetido);

            arreglo[i] = numero;
        }
        return arreglo;
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Aleatorio ale = new Aleatorio();

            int numero = ale.GenerarNumero(1, 10);
            Console.WriteLine("Número aleatorio: " + numero);

            int[] arreglo = ale.CrearArreglo(10, 1, 10);
            Console.WriteLine("Arreglo de números aleatorios sin repetición:");

            foreach (int n in arreglo)
            {
                Console.WriteLine("[" + n + "]");
            }
        }
    }
}