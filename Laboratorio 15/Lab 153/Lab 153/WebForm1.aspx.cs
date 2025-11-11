using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab_153
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String texto = TextBox1.Text;
            Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "MessageBox", "window.alert('Hola: " + texto + "');", true);

        }
    }
}