using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using SistemaHospital.Negocio;
using System.Data;

namespace CapaPresentacion.Account
{
    public partial class Login : System.Web.UI.Page
    {
        public static int MaxError = 3;
        public static  int intentos = 0;
       
        protected void Page_Load(object sender, EventArgs e)
        {
         
        }
        protected void LoginUser_Authenticate(object sender, AuthenticateEventArgs e)
        {
            bool autentifica = false;
            Usuario nuevo = new Usuario(LoginUser.UserName, LoginUser.Password);
            autentifica = nuevo.login();
            e.Authenticated = autentifica;

            if (autentifica)
            {
               // nuevo.registrarLogin();
               // Response.Write(HttpContext.Current.User.Identity.Name);
              string nn=nuevo.getTipoUsuario();
               Response.Write(nn);
               Session["Tipo"] = nuevo.getTipoUsuario();

            }
            else
            {
                intentos++;
                Response.Write(intentos);
                if (intentos == MaxError) {
                   /*ACA SE DEBE IMPLEMENTAR UN BLOQUEO  PARA EL USER QUE YA HIZO EL MAXIMO DE INTENTOS y MOSTRAR UN MENSAJE*/
                    nuevo.bloquear();
                }

            }
           
        }

       

        protected void LoginButton_Click(object sender, EventArgs e)
        {

            MySqlConnection conexion = new MySqlConnection("data source=localhost;user=root;password=;database=sistemahospital");
            conexion.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) from my_aspnet_users Where ", conexion);
            Response.Write("hola");
                conexion.Close();

            string uName = LoginUser.UserName;
            string pass = LoginUser.Password;
         
            Usuario nuevoUser= new Usuario(uName,pass);

            string compare = nuevoUser.getTipoUsuario();

            
             bool res= nuevoUser.login();


             if (res )
             {
                 if (compare.CompareTo("ADMIN") == 0)
                     Response.Write(compare);
                 //    Response.Redirect("../Administrador/menuppal.aspx");
                 else
                     Response.Write(compare);
                //     Response.Redirect("../Default.aspx");      
               
                // Response.Redirect("../Default.aspx");
             //    Response.Redirect("google.com");
               
             }

             
        }
    }
}
