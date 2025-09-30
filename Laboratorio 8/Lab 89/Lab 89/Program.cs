using Lab_89;

internal class Program
{
    private static void Main(string[]args)
    {
        Template temp1 = new Template();
        temp1.ponerVariable("var1", "var1");
        temp1.ponerVariable("var2", "var2");    
        temp1.ponerVariable("var3", "var3");
        temp1.verHtml("<br>Texto de prueba</br>");
    }
}