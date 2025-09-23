class Program
{
    static void Main(String[] args)
    { 
        try 
        {
    int[] myNumbers = { 1, 2, 3 };
    Console.WriteLine(myNumbers[10]);
        }
            catch (Exception e)
            {
    Console.WriteLine("algo salio mal, valide el indice del arreglo");
            }
    finally
    {
        Console.WriteLine("Continuacion de la apliacion");
        }
    }
}
