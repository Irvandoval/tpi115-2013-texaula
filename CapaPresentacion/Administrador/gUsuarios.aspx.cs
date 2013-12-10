using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SistemaHospital.Negocio;
using System.Data;




namespace SistemaHospital.Presentacion.Administrador
{
    public partial class gUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bind();

        }

        protected void bind()
        {
            DataTable dt = Usuario.obtenerListaUsuarios();
            tUsuarios.DataSource = dt;
            tUsuarios.DataBind();


        }



        void GridView_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {
            
        }

     protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
     {

     }

        
    }
}