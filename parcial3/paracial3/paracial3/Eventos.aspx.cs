using paracial3;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace SistemaBuffeteAbogados
{
    public partial class Eventos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCasos();
                CargarEventos();
            }
        }

        private void CargarCasos()
        {
            System.Diagnostics.Debug.WriteLine("Cadena: " + Global.ConnectionString);


            SqlConnection conn = new SqlConnection(Global.ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT CasoID, NumeroCaso FROM JG_Casos", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            ddlCaso.DataSource = reader;
            ddlCaso.DataTextField = "NumeroCaso";
            ddlCaso.DataValueField = "CasoID";
            ddlCaso.DataBind();

            conn.Close();
        }

        private void CargarEventos()
        {
            SqlConnection conn = new SqlConnection(Global.ConnectionString);
            conn.Open();

            string query = @"SELECT e.EventoID, e.Fecha, e.Descripcion, c.NumeroCaso
                            FROM JG_Eventos e
                            INNER JOIN JG_Casos c ON e.CasoID = c.CasoID
                            ORDER BY e.Fecha DESC";

            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            gvEventos.DataSource = dt;
            gvEventos.DataBind();

            conn.Close();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Global.ConnectionString);
            conn.Open();

            int eventoID = Convert.ToInt32(hdnEventoID.Value);

            if (eventoID == 0)
            {
                string query = "INSERT INTO JG_Eventos (CasoID, Fecha, Descripcion) VALUES (@CasoID, @Fecha, @Descripcion)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CasoID", ddlCaso.SelectedValue);
                cmd.Parameters.AddWithValue("@Fecha", txtFecha.Text);
                cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);
                cmd.ExecuteNonQuery();
                lblMensaje.Text = "Evento guardado";
            }
            else
            {
                string query = "UPDATE JG_Eventos SET CasoID=@CasoID, Fecha=@Fecha, Descripcion=@Descripcion WHERE EventoID=@EventoID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EventoID", eventoID);
                cmd.Parameters.AddWithValue("@CasoID", ddlCaso.SelectedValue);
                cmd.Parameters.AddWithValue("@Fecha", txtFecha.Text);
                cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);
                cmd.ExecuteNonQuery();
                lblMensaje.Text = "Evento actualizado";
            }

            conn.Close();
            LimpiarFormulario();
            CargarEventos();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            hdnEventoID.Value = "0";
            txtFecha.Text = "";
            txtDescripcion.Text = "";
            lblMensaje.Text = "";
        }

        protected void gvEventos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int eventoID = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Editar")
            {
                SqlConnection conn = new SqlConnection(Global.ConnectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM JG_Eventos WHERE EventoID=@EventoID", conn);
                cmd.Parameters.AddWithValue("@EventoID", eventoID);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    hdnEventoID.Value = eventoID.ToString();
                    ddlCaso.SelectedValue = reader["CasoID"].ToString();
                    txtFecha.Text = Convert.ToDateTime(reader["Fecha"]).ToString("yyyy-MM-ddTHH:mm");
                    txtDescripcion.Text = reader["Descripcion"].ToString();
                }

                conn.Close();
            }
            else if (e.CommandName == "Eliminar")
            {
                SqlConnection conn = new SqlConnection(Global.ConnectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM JG_Eventos WHERE EventoID=@EventoID", conn);
                cmd.Parameters.AddWithValue("@EventoID", eventoID);
                cmd.ExecuteNonQuery();

                conn.Close();
                lblMensaje.Text = "Evento eliminado";
                CargarEventos();
            }
        }
    }
}