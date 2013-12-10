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
        private int idExpediente;
        private string medico_dui;
        private string fechaConsulta;
        private string motivoConsulta;

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
