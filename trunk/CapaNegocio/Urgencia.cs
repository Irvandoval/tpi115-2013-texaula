using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistemaHospital.Datos;
using MySql.Data.MySqlClient;
using System.Data;

namespace SistemaHospital.Negocio
{
    public class Urgencia
    {
        private int idUrgencia;

        public int IdUrgencia
        {
            get { return idUrgencia; }
            set { idUrgencia = value; }
        }
        private int idExpediente;

        public int IdExpediente
        {
            get { return idExpediente; }
            set { idExpediente = value; }
        }
        private string medico_dui;

        public string Medico_dui
        {
            get { return medico_dui; }
            set { medico_dui = value; }
        }
        private string enfermera_dui;

        public string Enfermera_dui
        {
            get { return enfermera_dui; }
            set { enfermera_dui = value; }
        }
        private string fechaEmergencia;

        public string FechaEmergencia
        {
            get { return fechaEmergencia; }
            set { fechaEmergencia = value; }
        }
        

        public int agregarUrgencia()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();
            int res = nuevoDB.agregarUrgencia(this.idExpediente, this.medico_dui, this.enfermera_dui, this.fechaEmergencia);
            nuevoDB.cerrar();
            return res;
        }

        public int eliminarUrgencia()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();
            int res = nuevoDB.eliminaUrgencia(this.idUrgencia);
            nuevoDB.cerrar();
            return res;
        }

        public static DataTable obtenerListaUrgencias(int idExpediente)
        {
            DB nuevo = new DB();
            nuevo.conectar();
            DataTable tabUrgencias = nuevo.listaUrgencias(idExpediente);
            return tabUrgencias;
        }

        public int modificarUrgencia()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();
            int res = nuevoDB.modificaUrgencia(this.idUrgencia, this.idExpediente, this.medico_dui, this.enfermera_dui, this.fechaEmergencia);
            nuevoDB.cerrar();
            return res;
        }

        public int consultarUrgencia()
        {
            return 0;
        }


    }
}
