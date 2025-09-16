using System;

namespace P1Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            client.FirstName = "Jonathan";
            client.LastName = "Gomez";
            client.Age = 22;
            client.Id = 8 - 1002 - 785;

            Console.WriteLine(client.GetFullName());
        }
        public class Client
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public int Id { get; set; }
            public string GetFullName()
            {
                return FirstName + " " + LastName;
            }
        }
    }
}