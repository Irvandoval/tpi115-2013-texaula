using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistemaHospital.Datos;
using MySql.Data.MySqlClient;

namespace SistemaHospital.Negocio
{
    public class Consulta
    {
        private int idConsulta;

        public int IdConsulta
        {
            get { return idConsulta; }
            set { idConsulta = value; }
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
        private string fechaConsulta;

        public string FechaConsulta
        {
            get { return fechaConsulta; }
            set { fechaConsulta = value; }
        }
        private string motivoConsulta;

        public string MotivoConsulta
        {
            get { return motivoConsulta; }
            set { motivoConsulta = value; }
        }

        public int agregarConsulta()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();
            int res = nuevoDB.addConsulta(this.idExpediente,this.medico_dui,this.motivoConsulta);
            nuevoDB.cerrar();
            return res;

           
        }

        public int eliminarConsulta()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();
            int res = nuevoDB.eliminaConsulta(this.idConsulta);
            nuevoDB.cerrar();
            return res;
        }

        public int actualizarConsulta()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();
            int res = nuevoDB.modificaConsulta(this.idConsulta,this.idExpediente,this.fechaConsulta,this.medico_dui,this.motivoConsulta);
            nuevoDB.cerrar();
            return res;
          
        }

        public int consultarConsulta()
        {
            return 0;
        }



    }
}
