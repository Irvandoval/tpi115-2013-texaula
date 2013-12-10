using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SistemaHospital.Negocio;

namespace SistemaHospital.Presentacion.Administrador
{
    public partial class gMedicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bind();

        }
        protected void bind()
        {
            DataTable dt = Medico.listaMedicos();
              tMedicos.DataSource = dt;
            tMedicos.DataBind();


        }
    }
}