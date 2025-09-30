namespace Lab_81
{
    class Trabajador: Persona
    {
        public int Sueldo;
        
       public Trabajador(string nombre, int edad, string nif, int sueldo)
            : base(nombre, edad, nif)
        {
                       Sueldo = sueldo;
        }

    }
}
