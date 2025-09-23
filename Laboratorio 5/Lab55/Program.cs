
class Estudiante
{
    public string Nombre { get; set; }
    public int Edad { get; set; }


    public static List<Estudiante> estudiantes = new List<Estudiante>
{
    new Estudiante { Nombre = "Ana", Edad = 12 },
    new Estudiante { Nombre = "Juan", Edad = 10 },
    new Estudiante { Nombre = "Sofia", Edad = 11 }
};
    class Program
    {
        static void Main(string[] args)
        {

            foreach (Estudiante estudiante in estudiantes)
            {
                Console.WriteLine("Nombre: " + estudiante.Nombre + ", Edad: " + estudiante.Edad);
            }
        }
    }
}
