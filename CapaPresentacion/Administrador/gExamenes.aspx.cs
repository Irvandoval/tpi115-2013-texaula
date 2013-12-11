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
    public partial class gExamenes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            bind();
        }

        void bind()
        {
            DataTable dt =Examen.listaExamen();
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        /*comando para agregar un nuevom elemento*/
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddNew")
            {
                TextBox txtNombre = (TextBox)GridView1.FooterRow.FindControl("txtNombre");
                Examen nuevo = new Examen(-1,txtNombre.Text);
                nuevo.agregarExamen();
                bind();
            
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
          
            GridViewRow row = GridView1.SelectedRow;
            Examen nuevo = new Examen(Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]),"");
            nuevo.eliminarExamen();
           // Response.Write(Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]));
            bind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            bind();

        }

        protected void GridView1_RowUpdating1(object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtNombre = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtNombre");
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            Examen nuevo = new Examen(id, txtNombre.Text);
            nuevo.actualizarExamen();
            // Response.Write(Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]));
            GridView1.EditIndex = -1;
            bind();

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            bind();

        }

     

       

    }
}