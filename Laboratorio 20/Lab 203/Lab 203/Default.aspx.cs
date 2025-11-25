using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab_203
{
    public partial class _Default : Page
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ProductosConnection"].ConnectionString;
        private bool nuevo;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ConfigurarInicio();
            }

        }
        private void ConfigurarInicio()
        {
            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnEliminar.Enabled = false;
            btnBuscar.Enabled = true;
            
            txtId.Enabled = false;
            txtNombre.Enabled = false;
            txtPrecio.Enabled = false;
            txtStock.Enabled = false;

            Limpiar();
            lblMensaje.Text = "";
        }

        private void Limpiar()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtBuscar.Text = "";
        }

        protected void btnNuevo_Click(object sender, EventArgs e) 
        {
            btnNuevo.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnEliminar.Enabled = false;
            btnBuscar.Enabled = false;

            txtNombre.Enabled = true;
            txtPrecio.Enabled = true;
            txtStock.Enabled = true;

            Limpiar();
            txtNombre.Focus();
            nuevo = true;
            lblMensaje.Text = "Nuevo Registro añadido";
        }




        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (nuevo)
            {
                InsertarRegistro();
            }
            else
            {
                ActualizarRegistro();
            }
        }

        private void InsertarRegistro()
        {
            string sql = "INSERT INTO Laptops (nombre, precio, stock) VALUES (@nombre, @precio, @stock)";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@precio", decimal.Parse(txtPrecio.Text));
                    cmd.Parameters.AddWithValue("@stock", int.Parse(txtStock.Text));

                    try
                    {
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            lblMensaje.Text = "Registro ingresado correctamente!";
                            ConfigurarInicio();
                        }
                    }
                    catch (Exception ex)
                    {
                        lblMensaje.Text = "Error: " + ex.Message;
                    }
                }
            }
        }

        private void ActualizarRegistro()
        {
            string sql = "UPDATE Laptops SET nombre=@nombre, precio=@precio, stock=@stock WHERE id=@id";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@precio", decimal.Parse(txtPrecio.Text));
                    cmd.Parameters.AddWithValue("@stock", int.Parse(txtStock.Text));
                    cmd.Parameters.AddWithValue("@id", int.Parse(txtId.Text));

                    try
                    {
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            lblMensaje.Text = "Registro actualizado correctamente!";
                            ConfigurarInicio();
                        }
                    }
                    catch (Exception ex)
                    {
                        lblMensaje.Text = "Error: " + ex.Message;
                    }
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ConfigurarInicio();
            lblMensaje.Text = "Operación cancelada";
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM Laptops WHERE id=@id";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@id", int.Parse(txtId.Text));

                    try
                    {
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            lblMensaje.Text = "Registro eliminado correctamente!";
                            ConfigurarInicio();
                        }
                    }
                    catch (Exception ex)
                    {
                        lblMensaje.Text = "Error: " + ex.Message;
                    }
                }
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBuscar.Text))
            {
                lblMensaje.Text = "Ingrese un ID para buscar";
                return;
            }

            string sql = "SELECT * FROM Laptops WHERE ID=@id";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@id", int.Parse(txtBuscar.Text));

                    try
                    {
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            btnNuevo.Enabled = false;
                            btnGuardar.Enabled = true;
                            btnCancelar.Enabled = true;
                            btnEliminar.Enabled = true;
                            btnBuscar.Enabled = false;

                            txtNombre.Enabled = true;
                            txtPrecio.Enabled = true;
                            txtStock.Enabled = true;

                            txtId.Text = reader["id"].ToString();
                            txtNombre.Text = reader["nombre"].ToString();
                            txtPrecio.Text = reader["precio"].ToString();
                            txtStock.Text = reader["stock"].ToString();

                            nuevo = false;
                            lblMensaje.Text = "Registro encontrado - Modo Edición";
                        }
                        else
                        {
                            lblMensaje.Text = "Ningún registro encontrado con el ID ingresado!";
                            ConfigurarInicio();
                        }
                    }
                    catch (Exception ex)
                    {
                        lblMensaje.Text = "Error: " + ex.Message;
                    }
                }
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            // Puedes redireccionar a otra página o cerrar sesión
            Response.Write("<script>alert('¡Hasta pronto!');</script>");
        }

    }
}