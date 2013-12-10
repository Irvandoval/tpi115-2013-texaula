using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistemaHospital.Datos;
using MySql.Data.MySqlClient;
using System.Data;

namespace SistemaHospital.Negocio
{
    public class Recepcionist
    {
        private int idRecepcionista;
        private string nombres;
        private string apellidos;
        private string fechaNac;

        public int agregarRecepcionista()
        {
            return 0;
        }

        public int eliminarRecepcionista()
        {
            return 0;
        }

        public int actualizarRecepcionista()
        {
            return 0;
        }

        public int consultarRecepcionista()
        {
            return 0;
        }

        public static DataTable listaRecepcionistas()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();
            DataTable tabRecep = nuevoDB.listaRecepcionistas();
            nuevoDB.cerrar();
            return tabRecep;
        }


    }
}
