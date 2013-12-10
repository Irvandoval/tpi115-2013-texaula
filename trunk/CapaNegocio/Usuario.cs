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
        private string userName;
        private string pass;
        public string tipoUsuario;
        public int idusuario;

        public Usuario() { }
        public Usuario(string username, string pass)
        {
            this.userName = username;
            this.pass = Encriptador.RijndaelSimple.Encriptar(pass);


        }
        public Usuario(string username,string pass,string tipouser,int id)
        {
            this.userName = username;
            this.pass = pass;
            this.tipoUsuario = tipouser;
            this.idusuario = id;
        }

        public bool login()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();
            int resultado = nuevoDB.logUsuario(this.userName, this.pass);
            nuevoDB.cerrar();
            if (resultado == 1)
                return true;
            else return false;

        }



        public int agregaUsuario()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();
            int res = nuevoDB.addUsuario(this.userName, this.pass, this.tipoUsuario);
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

        public int registrarLogin()
        {

            DB nuevoDB = new DB();
            nuevoDB.conectar();
            int res = nuevoDB.regisLogin(this.userName);
            nuevoDB.cerrar();
            return res;
        }

        public static int registrarLogout()
        {
            DB nuevo = new DB();
            nuevo.conectar();
            int res = nuevo.regisLogout();
            nuevo.cerrar();
            return res;
        }

        public static DataTable obtenerListaUsuarios()
        {
            DB nuevo = new DB();
            nuevo.conectar();
            DataTable tabUsuarios = nuevo.listaUsuarios();
            nuevo.cerrar();
            return tabUsuarios;
        }

        public  string getTipoUsuario()
        { 
            
            DB nuevo = new DB();
            string obt = nuevo.getTipoUsuario(this.userName);
            nuevo.cerrar();
            return obt;

        }

    }
}
