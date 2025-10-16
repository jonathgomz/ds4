using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Lab_131
{
    public partial class Form1 : Form
    {
        string connectionString =
        @"Server=localhost;Database=Northwind;TrustServerCertificate=true;Integrated Security=SSPI;";

        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string sql = "select ProductName from [dbo].[Products]";
            SqlConnection conexion = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.CommandType =  CommandType.Text;
            SqlDataReader reader;


            conexion.Open();
            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listBox1.Items.Add(reader["ProductName"].ToString() );
                }
            }
            catch(Exception)
            {

            }

            MessageBox.Show("Se abrió la conexión con el servidor SQL Server y se seleccionó la base de datos");
            
            

            
            conexion.Close();
            MessageBox.Show("Se cerró la conexión.");

        }

    }
}
