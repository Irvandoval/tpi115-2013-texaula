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

     protected void tUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
     {
         if (e.CommandName == "AddNew")
         {
             TextBox txtUser = (TextBox)tUsuarios.FooterRow.FindControl("TxtUser");
             TextBox txtPass = (TextBox)tUsuarios.FooterRow.FindControl("TxtPass");
             DropDownList txtTipo= (DropDownList)tUsuarios.FooterRow.FindControl("TxtTipo");
             DropDownList txtEdo = (DropDownList)tUsuarios.FooterRow.FindControl("txtEstado");

             Usuario nuevo = new Usuario(txtUser.Text,txtPass.Text);
             nuevo.TipoUsuario = txtTipo.SelectedValue;
             nuevo.agregaUsuario();
             bind();

         }
     }

     protected void tUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
     {
         GridViewRow row = tUsuarios.SelectedRow;
         Usuario nuevo = new Usuario(Convert.ToString(tUsuarios.DataKeys[e.RowIndex].Values[0]), "");
         nuevo.eliminaUsuario();
         // Response.Write(Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]));
         bind();
     }

        
    }
}