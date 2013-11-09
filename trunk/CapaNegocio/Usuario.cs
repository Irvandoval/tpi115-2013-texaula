using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistemaHospital.Datos;
using MySql.Data.MySqlClient;


namespace SistemaHospital.Negocio
{
    public class Usuario
    {
        private string username;
        private string pass;
        private string tipoUsuario;
        private string estado;

       public Usuario(string username,string pass)
        {
            this.username=username;
            this.pass = pass;
           
        }

        public  bool login(){
            DB nuevoDB = new DB();
            nuevoDB.conectar();
           int resultado =nuevoDB.logUsuario(this.username,this.pass);
                   nuevoDB.cerrar();
                   if (resultado == 1)
                       return true;
                   else return false;
            
        }

       
    }
}
