using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistemaHospital.Datos;
using MySql.Data.MySqlClient;
using System.Data;

namespace SistemaHospital.Negocio
{
    public class RegistroTratamientos
    {
        private int id;
        private int idExpediente;
        private int idTratamiento;
        private String fecha;

        public int agregarRegistroTratamiento()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();

            int res =nuevoDB.addRegistroTratamiento(this.idExpediente, this.idTratamiento, this.fecha);

            nuevoDB.cerrar();
            return res;
        }

        public int eliminarRegistroTratamiento()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();

            int res = nuevoDB.eliminaRegistroTratamiento(this.id);

            nuevoDB.cerrar();
            return res;
        }

        public int actualizarRegistroTratamiento()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();

            int res = nuevoDB.modificaRegistroTratamiento(this.id, this.idExpediente, this.idTratamiento, this.fecha);

            nuevoDB.cerrar();
            return res;
        }

        public int consultarRegistroTratamiento()
        {
            return 0;
        }

        public static DataTable listaRegistroTratamiento()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();

            //modificar metodo de nuevoBD para obtener registro de examenes
            DataTable tabRegistroTratamiento = nuevoDB.listaMedicos();

            nuevoDB.cerrar();
            return tabRegistroTratamiento;
        }


    }
}
