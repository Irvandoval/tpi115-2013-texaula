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
    public partial class gEnfermeras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bind();
        }

        void bind()
        {
            DataTable dt = Negocio.Enfermera.listaEnfermera();
             tEnfermeras.DataSource = dt;
            tEnfermeras.DataBind();
        }

    }
}