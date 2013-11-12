using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistemaHospital.Datos;
using MySql.Data.MySqlClient;
using System.Data;


namespace SistemaHospital.Negocio
{
    public class Usuario
    {
        private string username;
        private string pass;
        public string tipoUsuario;
          

       public Usuario(string username,string pass)
        {
            this.username=username;
            this.pass =Encriptador.RijndaelSimple.Encriptar (pass);
          
           
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

       
        
        public int agregaUsuario()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();
            int res=nuevoDB.addUsuario(this.username,this.pass,this.tipoUsuario);
            nuevoDB.cerrar();
            return res;
        }

        /* metodo que cambie el estado de un usuario a BAJA
           */
        public void bloquear()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();
            int res = nuevoDB.editEstadoUsuario("BAJA");
            nuevoDB.cerrar();

        }

        public  int registrarLogin(){

            DB nuevoDB= new DB();
            nuevoDB.conectar();
            int res= nuevoDB.regisLogin(this.username);
            nuevoDB.cerrar();
            return res;
        }

        public static int registrarLogout()
        {
            DB nuevo = new DB();
            nuevo.conectar();
           int res= nuevo.regisLogout();
           nuevo.cerrar();
           return res;
        }

        public static DataTable obtenerListaUsuarios()
        {
            DB nuevo = new DB();
            nuevo.conectar();
            DataTable tabUsuarios = nuevo.listaUsuarios();
            return tabUsuarios;
        }
       
    }
}
