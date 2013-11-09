using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SistemaHospital.Negocio;

namespace SistemaHospital.Presentacion
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Usuario n = new Usuario(TextBox1.Text, TextBox2.Text);
            n.tipoUsuario = TextBox3.Text;
           int r= n.agregaUsuario();
           if (r == 1) Response.Write("Se introdujo correctamente");
           else Response.Write("error");


        }
    }
}