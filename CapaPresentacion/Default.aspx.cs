using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string a;
            try
            {
              a = Session["Tipo"].ToString();
            }
            catch (Exception h) {
                a = "nada";

            }
           
            
                Response.Write("pNPn" + a);

                if (a.CompareTo("ADMIN") == 0)
                    Response.Redirect("Administrador/menuppal.aspx");
                else
                    if (a.CompareTo("MEDICO") == 0)
                        Response.Redirect("Doctor/menuppal.aspx");
                    else

                        if (a.CompareTo("RECEP") == 0)
                            Response.Redirect("Recepcionista/menuppal.aspx");
                        else
                            Response.Redirect("Account/Login.aspx");
            


        }
    }
}
