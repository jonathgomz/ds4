using paracial3;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace SistemaBuffeteAbogados
{
    public partial class Casos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarClientes();
                CargarAbogados();
                CargarCasos();
            }
        }

        // Cargar clientes en el dropdown
        private void CargarClientes()
        {
            SqlConnection conn = new SqlConnection(Global.ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT ClienteID, Nombre FROM JG_Clientes", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            ddlCliente.DataSource = reader;
            ddlCliente.DataTextField = "Nombre";
            ddlCliente.DataValueField = "ClienteID";
            ddlCliente.DataBind();

            conn.Close();
        }

        // Cargar abogados en el dropdown
        private void CargarAbogados()
        {
            SqlConnection conn = new SqlConnection(Global.ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT AbogadoID, Nombre FROM JG_Abogados", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            ddlAbogado.DataSource = reader;
            ddlAbogado.DataTextField = "Nombre";
            ddlAbogado.DataValueField = "AbogadoID";
            ddlAbogado.DataBind();

            conn.Close();
        }

        // Cargar todos los casos
        private void CargarCasos()
        {
            SqlConnection conn = new SqlConnection(Global.ConnectionString);
            conn.Open();

            string query = @"SELECT c.CasoID, c.NumeroCaso, c.Titulo, c.Estado,
                            cl.Nombre AS Cliente, a.Nombre AS Abogado
                            FROM JG_Casos c
                            INNER JOIN JG_Clientes cl ON c.ClienteID = cl.ClienteID
                            INNER JOIN JG_Abogados a ON c.AbogadoID = a.AbogadoID";

            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            gvCasos.DataSource = dt;
            gvCasos.DataBind();

            conn.Close();
        }

        // Guardar caso (nuevo o editar)
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Global.ConnectionString);
            conn.Open();

            int casoID = Convert.ToInt32(hdnCasoID.Value);

            if (casoID == 0) // Nuevo caso
            {
                string query = @"INSERT INTO JG_Casos 
                    (NumeroCaso, ClienteID, AbogadoID, Titulo, Descripcion, Estado, FechaInicio, FechaVencimiento)
                    VALUES (@NumeroCaso, @ClienteID, @AbogadoID, @Titulo, @Descripcion, @Estado, @FechaInicio, @FechaVencimiento)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NumeroCaso", txtNumeroCaso.Text);
                cmd.Parameters.AddWithValue("@ClienteID", ddlCliente.SelectedValue);
                cmd.Parameters.AddWithValue("@AbogadoID", ddlAbogado.SelectedValue);
                cmd.Parameters.AddWithValue("@Titulo", txtTitulo.Text);
                cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@Estado", ddlEstado.SelectedValue);
                cmd.Parameters.AddWithValue("@FechaInicio", txtFechaInicio.Text);
                cmd.Parameters.AddWithValue("@FechaVencimiento", txtFechaVencimiento.Text);

                cmd.ExecuteNonQuery();
                lblMensaje.Text = "Caso guardado";
            }
            else // Editar caso
            {
                string query = @"UPDATE JG_Casos SET 
                    NumeroCaso=@NumeroCaso, ClienteID=@ClienteID, AbogadoID=@AbogadoID,
                    Titulo=@Titulo, Descripcion=@Descripcion, Estado=@Estado,
                    FechaInicio=@FechaInicio, FechaVencimiento=@FechaVencimiento
                    WHERE CasoID=@CasoID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CasoID", casoID);
                cmd.Parameters.AddWithValue("@NumeroCaso", txtNumeroCaso.Text);
                cmd.Parameters.AddWithValue("@ClienteID", ddlCliente.SelectedValue);
                cmd.Parameters.AddWithValue("@AbogadoID", ddlAbogado.SelectedValue);
                cmd.Parameters.AddWithValue("@Titulo", txtTitulo.Text);
                cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@Estado", ddlEstado.SelectedValue);
                cmd.Parameters.AddWithValue("@FechaInicio", txtFechaInicio.Text);
                cmd.Parameters.AddWithValue("@FechaVencimiento", txtFechaVencimiento.Text);

                cmd.ExecuteNonQuery();
                lblMensaje.Text = "Caso actualizado";
            }

            conn.Close();
            LimpiarFormulario();
            CargarCasos();
        }

        // Limpiar formulario
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            hdnCasoID.Value = "0";
            txtNumeroCaso.Text = "";
            txtTitulo.Text = "";
            txtDescripcion.Text = "";
            txtFechaInicio.Text = "";
            txtFechaVencimiento.Text = "";
            lblMensaje.Text = "";
        }

        // Editar o Eliminar
        protected void gvCasos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int casoID = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Editar")
            {
                SqlConnection conn = new SqlConnection(Global.ConnectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM JG_Casos WHERE CasoID=@CasoID", conn);
                cmd.Parameters.AddWithValue("@CasoID", casoID);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    hdnCasoID.Value = casoID.ToString();
                    txtNumeroCaso.Text = reader["NumeroCaso"].ToString();
                    ddlCliente.SelectedValue = reader["ClienteID"].ToString();
                    ddlAbogado.SelectedValue = reader["AbogadoID"].ToString();
                    txtTitulo.Text = reader["Titulo"].ToString();
                    txtDescripcion.Text = reader["Descripcion"].ToString();
                    ddlEstado.SelectedValue = reader["Estado"].ToString();
                    txtFechaInicio.Text = Convert.ToDateTime(reader["FechaInicio"]).ToString("yyyy-MM-dd");

                    if (reader["FechaVencimiento"] != DBNull.Value)
                        txtFechaVencimiento.Text = Convert.ToDateTime(reader["FechaVencimiento"]).ToString("yyyy-MM-dd");
                }

                conn.Close();
            }
            else if (e.CommandName == "Eliminar")
            {
                SqlConnection conn = new SqlConnection(Global.ConnectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM JG_Casos WHERE CasoID=@CasoID", conn);
                cmd.Parameters.AddWithValue("@CasoID", casoID);
                cmd.ExecuteNonQuery();

                conn.Close();
                lblMensaje.Text = "Caso eliminado";
                CargarCasos();
            }
        }
    }
}