using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistemaHospital.Datos;
using MySql.Data.MySqlClient;
using System.Data;

namespace SistemaHospital.Negocio
{
    public class Tratamiento
    {
        private int idTratamiento;

        public int IdTratamiento
        {
            get { return idTratamiento; }
            set { idTratamiento = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }


        public Tratamiento(string nombre)
        {
            this.nombre = nombre;
        }

        public Tratamiento(string nombre, int idTratamiento)
        {
            this.idTratamiento = idTratamiento;
            this.nombre = nombre;
        }

        public int agregarTratamiento()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();
            int res = nuevoDB.addTratamiento(this.nombre);
            nuevoDB.cerrar();
            return res;
        }

        public int obteneridTratamiento()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();
            int res = nuevoDB.getidTratamiento(this.nombre);
            nuevoDB.cerrar();
            return res;
        }

        public int eliminarTratamiento()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();
            int res = nuevoDB.eliminaTratamiento(this.nombre);
            nuevoDB.cerrar();
            return res;
        }

        public static DataTable obtenerListaTratamientos()
        {
            DB nuevo = new DB();
            nuevo.conectar();
            DataTable tabTratamientos = nuevo.listaTratamientos();
            return tabTratamientos;
        }

        public int modificarTratamiento()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();
            int res = nuevoDB.modificaTratamiento(this.idTratamiento, this.nombre);
            nuevoDB.cerrar();
            return res;
        }

        public int consultarTratamiento()
        {
            return 0;
        }


    }
}
