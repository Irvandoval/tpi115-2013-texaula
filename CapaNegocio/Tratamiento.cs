using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistemaHospital.Datos;
using MySql.Data.MySqlClient;

namespace SistemaHospital.Negocio
{
    public class Tratamiento
    {
        private int idTratamiento;
        private string nombre;


        public Tratamiento(int idTratamiento, string nombre)
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

        public int actualizarTratamiento()
        {
            return 0;
        }

        public int consultarTratamiento()
        {
            return 0;
        }


    }
}
