using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistemaHospital.Datos;
using MySql.Data.MySqlClient;
using System.Data;

namespace SistemaHospital.Negocio
{
    public class RegistroExamenes
    {
        private int id;
        private int idExpediente;
        private int idExamen;
        private String fecha;
        private String resultados;

        public int agregarRegistroExamen()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();

            int res = nuevoDB.addRegistroExamen(this.idExpediente, this.idExamen, this.fecha, this.resultados);

            nuevoDB.cerrar();
            return res;
        }

        public int eliminarRegistroExamen()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();

            int res = nuevoDB.eliminaRegistroExamen(this.id);

            nuevoDB.cerrar();
            return res;
        }

        public int actualizarRegistroExamen()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();

            int res = nuevoDB.modificaRegistroExamen(this.id, this.idExpediente, this.idExamen, this.fecha, this.resultados);

            nuevoDB.cerrar();
            return res;
        }

        public int consultarRegistroExamen()
        {
            return 0;
        }

        public static DataTable listaRegistroExamen()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();
            
            //modificar metodo de nuevoBD para obtener registro de examenes
            DataTable tabRegistroExamen = nuevoDB.listaMedicos();
            
            nuevoDB.cerrar();
            return tabRegistroExamen;
        }

    }
}
