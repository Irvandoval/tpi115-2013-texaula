using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistemaHospital.Datos;
using MySql.Data.MySqlClient;
using System.Data;

namespace SistemaHospital.Negocio
{
    public class Diagnostico
    {
        private int idDiagnostico;
        private string nombre;
        private string tipo;
        private string fase;

        public int agregarDiagnostico()
        {
            return 0;
        }

        public int eliminarDiagnostico()
        {
            return 0;
        }

        public int actualizarDiagnostico()
        {
            return 0;
        }

        public int consultarDiagnostico()
        {
            return 0;
        }

        public static DataTable listaDiagnostico()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();
            DataTable tabDiagnostico = nuevoDB.listaDiagnosticos();
            nuevoDB.cerrar();
            return tabDiagnostico;
        }


    }
}
