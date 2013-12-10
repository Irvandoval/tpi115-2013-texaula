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
            DB nuevoDB = new DB();
            nuevoDB.conectar();
            int res = nuevoDB.addDiagnostico(this.idDiagnostico,this.nombre, this.tipo, this.fase);
            nuevoDB.cerrar();
            return res;
            
        }

        public int eliminarDiagnostico()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();
            int res = nuevoDB.eliminarDiagnostico(this.idDiagnostico);
            nuevoDB.cerrar();
            return res;
            

            
        }

        public int actualizarDiagnostico()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();
            int res = nuevoDB.modificaDiagnostico(this.idDiagnostico, this.nombre, this.tipo, this.fase);
            nuevoDB.cerrar();
            return res;
            
            
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
