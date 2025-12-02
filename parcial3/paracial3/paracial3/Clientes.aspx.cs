using paracial3;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace SistemaBuffeteAbogados
{
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarClientes();
            }
        }

        private void CargarClientes()
        {
            SqlConnection conn = new SqlConnection(Global.ConnectionString);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM JG_Clientes", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            gvClientes.DataSource = dt;
            gvClientes.DataBind();

            conn.Close();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Global.ConnectionString);
            conn.Open();

            int clienteID = Convert.ToInt32(hdnClienteID.Value);

            if (clienteID == 0)
            {
                string query = "INSERT INTO JG_Clientes (Nombre, Telefono, Email) VALUES (@Nombre, @Telefono, @Email)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.ExecuteNonQuery();
                lblMensaje.Text = "Cliente guardado";
            }
            else
            {
                string query = "UPDATE JG_Clientes SET Nombre=@Nombre, Telefono=@Telefono, Email=@Email WHERE ClienteID=@ClienteID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ClienteID", clienteID);
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.ExecuteNonQuery();
                lblMensaje.Text = "Cliente actualizado";
            }

            conn.Close();
            LimpiarFormulario();
            CargarClientes();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            hdnClienteID.Value = "0";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            lblMensaje.Text = "";
        }

        protected void gvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int clienteID = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Editar")
            {
                SqlConnection conn = new SqlConnection(Global.ConnectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM JG_Clientes WHERE ClienteID=@ClienteID", conn);
                cmd.Parameters.AddWithValue("@ClienteID", clienteID);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    hdnClienteID.Value = clienteID.ToString();
                    txtNombre.Text = reader["Nombre"].ToString();
                    txtTelefono.Text = reader["Telefono"].ToString();
                    txtEmail.Text = reader["Email"].ToString();
                }

                conn.Close();
            }
            else if (e.CommandName == "Eliminar")
            {
                SqlConnection conn = new SqlConnection(Global.ConnectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM JG_Clientes WHERE ClienteID=@ClienteID", conn);
                cmd.Parameters.AddWithValue("@ClienteID", clienteID);
                cmd.ExecuteNonQuery();

                conn.Close();
                lblMensaje.Text = "Cliente eliminado";
                CargarClientes();
            }
        }
    }
}