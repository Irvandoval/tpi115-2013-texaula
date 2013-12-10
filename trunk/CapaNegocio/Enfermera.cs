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
        private string nombres;
        private string apellidos;
        private string fechaNac;


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
            int enf = nuevoDB.modificaEnfermera(this.dui, this.nombres, this.apellidos, this.fechaNac);
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
            return 0;
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
