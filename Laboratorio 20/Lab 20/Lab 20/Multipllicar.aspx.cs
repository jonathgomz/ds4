using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab_20
{
    public partial class Multipllicar : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {


        }
        protected void btnMultiplicar_Click(object sender, EventArgs e)
        {

            int numero;

            if (!int.TryParse(txtA.Text, out numero))
            {
                lblResultado.Text = "Ingrese un número válido.";
                return;
            }

            string resultado = "";

            for (int i = 1; i <= 25; i++)
            {
                resultado += $"{numero} x {i} = {numero * i}<br/>";
            }

            lblResultado.Text = resultado;

        }


    }
}