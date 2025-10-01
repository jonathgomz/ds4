public class numerosPares
{

    public static void Main(string[] args)

    {
        for
        (int i = 1; i <= 100; i++)
        {
            if (i % 3 == 0 && i % 2 == 0)
            {
                Console.WriteLine(i);
            }


        }
    }
}
