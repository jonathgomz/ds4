public class aleatorio
{
    public Random random;
     
    public aleatorio()
    {
        random = new Random();
    }

    public int generarNumeros(int min, int max)
    { 
        return random.Next(min, max + 1 );
    }

    public int[] crearArreglo(int cantidad, int min, int max)
    {
        int[] arreglo = new int[cantidad];
        for (int i = 0; i < cantidad; i++)
        {
            arreglo[i] = generarNumeros(min, max);
        }
        return arreglo;
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            aleatorio ale = new aleatorio();

            int numero = ale.generarNumeros(1, 100);
            Console.WriteLine("Numero aleatorio: " + numero);
            int[] arreglo = ale.crearArreglo(10, 1, 50);
            Console.WriteLine("Arreglo de numeros aleatorios:");

            foreach (int n in arreglo)
            {
                Console.WriteLine("["+n+"]");
            }
        }
    }



}