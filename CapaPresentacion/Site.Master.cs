using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SistemaHospital.Negocio;


namespace CapaPresentacion
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
        }

        protected void HeadLoginView_ViewChanged(object sender, EventArgs e)
        {

        }

        protected void HeadLoginStatus_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Usuario.registrarLogout();
            
        }
    }
}
