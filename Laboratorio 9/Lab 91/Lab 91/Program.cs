public class pedirPrecio
{
    public static void Main(string[] args)
    {
        Console.WriteLine("ingrese el precio del producto");
        double precio = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("el precio del producto es: " + precio);
        Console.WriteLine("Eliga metodo de pago ");
        Console.WriteLine("1. Efectivo");
        Console.WriteLine("2. Tarjeta de credito");
        int metodoPago = Convert.ToInt32(Console.ReadLine());
        double precioFinal = 0;
        string numeroTarjeta;

        if (metodoPago != 1 && metodoPago != 2)
        {
            Console.WriteLine("Metodo de pago no valido");
        }
        if (metodoPago == 1)
        {
            Console.WriteLine("Gracias por su compra");
        }
        if (metodoPago == 2)
        {
            Console.WriteLine("Ingrese su numero de tarjeta");
            numeroTarjeta = Console.ReadLine();

            if (numeroTarjeta.Length < 16)
            {
                Console.WriteLine("Tarjeta no valida");
            }
            else if (numeroTarjeta.Length > 16)
            {
                Console.WriteLine("Tarjeta no existe");
            }
            else { Console.WriteLine("Pago realizado. Gracias por su compra"); }


        }

    }
}