using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistemaHospital.Datos;
using MySql.Data.MySqlClient;
using System.Data;


namespace SistemaHospital.Negocio
{
    public class Enfermera
    {
        private string dui;

        public string Dui
        {
            get { return dui; }
            set { dui = value; }
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


        public Enfermera(string dui,string nombres, string apellidos, string fechaNac)
        {
            this.dui=dui;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.fechaNac = fechaNac;

          }
        public int agregarEnfermera()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();
            int enf = nuevoDB.addEnfermera(this.dui, this.nombres, this.apellidos, this.fechaNac);
            nuevoDB.cerrar();
            return enf;
         
        }

        public int eliminarEnfermera()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();
            int enf = nuevoDB.eliminaEnfermera(this.dui);
            nuevoDB.cerrar();
            return enf;
        }

        public int actualizarEnfermera()
        {
             DB nuevoDB = new DB();
            nuevoDB.conectar();
            int enf = nuevoDB.modificaEnfermera(this.dui, this.nombres, this.apellidos, this.fechaNac);
            nuevoDB.cerrar();
            return enf;
         
          
        }

        public int consultarEnfermera()
        {
            return 0;
        }

        public static DataTable listaEnfermera()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();
            DataTable tabEnfermera = nuevoDB.listaMedicos();
            nuevoDB.cerrar();
            return tabEnfermera;
        }

    }
}
