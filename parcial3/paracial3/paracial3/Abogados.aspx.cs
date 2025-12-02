using paracial3;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace SistemaBuffeteAbogados
{
    public partial class Abogados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarAbogados();
            }
        }

        private void CargarAbogados()
        {
            SqlConnection conn = new SqlConnection(Global.ConnectionString);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM JG_Abogados", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            gvAbogados.DataSource = dt;
            gvAbogados.DataBind();

            conn.Close();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Global.ConnectionString);
            conn.Open();

            int abogadoID = Convert.ToInt32(hdnAbogadoID.Value);

            if (abogadoID == 0)
            {
                string query = "INSERT INTO JG_Abogados (Nombre, Telefono) VALUES (@Nombre, @Telefono)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                cmd.ExecuteNonQuery();
                lblMensaje.Text = "Abogado guardado";
            }
            else
            {
                string query = "UPDATE JG_Abogados SET Nombre=@Nombre, Telefono=@Telefono WHERE AbogadoID=@AbogadoID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@AbogadoID", abogadoID);
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                cmd.ExecuteNonQuery();
                lblMensaje.Text = "Abogado actualizado";
            }

            conn.Close();
            LimpiarFormulario();
            CargarAbogados();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            hdnAbogadoID.Value = "0";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            lblMensaje.Text = "";
        }

        protected void gvAbogados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int abogadoID = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Editar")
            {
                SqlConnection conn = new SqlConnection(Global.ConnectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM JG_Abogados WHERE AbogadoID=@AbogadoID", conn);
                cmd.Parameters.AddWithValue("@AbogadoID", abogadoID);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    hdnAbogadoID.Value = abogadoID.ToString();
                    txtNombre.Text = reader["Nombre"].ToString();
                    txtTelefono.Text = reader["Telefono"].ToString();
                }

                conn.Close();
            }
            else if (e.CommandName == "Eliminar")
            {
                SqlConnection conn = new SqlConnection(Global.ConnectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM JG_Abogados WHERE AbogadoID=@AbogadoID", conn);
                cmd.Parameters.AddWithValue("@AbogadoID", abogadoID);
                cmd.ExecuteNonQuery();

                conn.Close();
                lblMensaje.Text = "Abogado eliminado";
                CargarAbogados();
            }
        }
    }
}