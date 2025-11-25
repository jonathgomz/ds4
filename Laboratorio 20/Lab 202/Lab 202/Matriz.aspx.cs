using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab_202
{
    public partial class Matriz : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIniciar_Click(object sender, EventArgs e)
        {
            int N;

            if (!int.TryParse(txtN.Text, out N) || N <= 0)
            {
                GMatriz.Rows.Clear();
                return;
            }

            GMatriz.Rows.Clear();

            for (int fila = 0; fila < N; fila++)
            {
                TableRow tr = new TableRow();

                for (int col = 0; col < fila; col++)
                {
                    TableCell td = new TableCell();

                    if (fila + col == N - 1) td.Text = "1";
                    else td.Text = "0";

                    tr.Cells.Add(td);

                }
                GMatriz.Rows.Add(tr);

            }
        }
    }
}
