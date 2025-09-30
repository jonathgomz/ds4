namespace Lab_81
{
    class Persona
    {
        public string Nombre;// campo donde el objeto persona guarda su nombre
        public int Edad;// campo donde el objeto persona guarda su edad
        public string NIF; // campo donde el objeto persona guarda su NIF

        void cumpleaños()
        {
            Edad++;// incrementa en uno la edad del objeto persona
        }

        public Persona(string nombre, int edad, string nif)
        {
            Nombre = nombre;
            Edad = edad;
            NIF = nif;
        }
    }

}
