using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistemaHospital.Datos;
using MySql.Data.MySqlClient;
using System.Data;

namespace SistemaHospital.Negocio
{
    public class Medico
    {
        public Medico() { 
        }
        private string dui;

        public string Dui
        {
            get { return dui; }
            set { dui = value; }
        }
        private int idUsuario;

        public int IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }
        private string nombres;

        public string Nombres
        {
            get { return nombres; }
            set { nombres = value; }
        }
        private string apellidos;

        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }
        private string fechaNac;

        public string FechaNac
        {
            get { return fechaNac; }
            set { fechaNac = value; }
        }
        private string sexo;

        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }
        private string jvmp;

        public string Jvmp
        {
            get { return jvmp; }
            set { jvmp = value; }
        }

        public int agregarMedico()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();
            int res = nuevoDB.addMedico(this.Dui,this.IdUsuario,this.Nombres,this.Apellidos,this.FechaNac,this.Sexo,this.Jvmp);
            nuevoDB.cerrar();
            return res;
        }

        public int eliminarMedico()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();
            int res = nuevoDB.eliminaMedico(this.Dui);
            nuevoDB.cerrar();
            return res;
        }

        public int actualizarMedico()
        {
            DB nuevoDB = new DB();
            int res = nuevoDB.modificaMedico(this.Dui,this.idUsuario,this.nombres,this.apellidos,this.fechaNac,this.sexo,this.jvmp);
            nuevoDB.cerrar();
            return 0;
           
        }

        public static DataTable listaMedicos() {
            DB nuevoDB = new DB();
            nuevoDB.conectar();
            DataTable tabMedicos = nuevoDB.listaMedicos();
            nuevoDB.cerrar();
            return tabMedicos;
        }


    }
}
