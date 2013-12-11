using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistemaHospital.Datos;
using MySql.Data.MySqlClient;

namespace SistemaHospital.Negocio
{
    public class Expediente
    {
        private int idExpediente;

        public int IdExpediente
        {
            get { return idExpediente; }
            set { idExpediente = value; }
        }
        private string dui;

        public string Dui
        {
            get { return dui; }
            set { dui = value; }
        }
        private int idDiagnostico;

        public int IdDiagnostico
        {
            get { return idDiagnostico; }
            set { idDiagnostico = value; }
        }

        public int agregarExpediente()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();

            int res = nuevoDB.addExpediente(this.idExpediente, this.dui, this.idDiagnostico);

            nuevoDB.cerrar();
            return res;
        }

        public int eliminarExpediente()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();

            int res = nuevoDB.eliminaExpediente(this.dui);

            nuevoDB.cerrar();
            return res;
        }

        public int actualizarExpediente()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();

            int res = nuevoDB.modificaExpediente(this.idExpediente, this.dui, this.idDiagnostico);

            nuevoDB.cerrar();
            return res;
        }

        public int consultarExpediente()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();

            int res = nuevoDB.getIdExpediente(this.dui);

            nuevoDB.cerrar();
            return res;
        }


    }
}
