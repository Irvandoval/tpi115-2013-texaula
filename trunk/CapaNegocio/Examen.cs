using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistemaHospital.Datos;
using MySql.Data.MySqlClient;
using System.Data;

namespace SistemaHospital.Negocio
{
    public class Examen
    {
        private int idExamen;

        public int IdExamen
        {
            get { return idExamen; }
            set { idExamen = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

     public Examen(int idExamen, String nombre)
        {
            this.idExamen=idExamen;
            this.nombre =nombre;
          
           
        }
        public int agregarExamen()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();
            int exam= nuevoDB.addExamen(this.nombre);
            nuevoDB.cerrar();
            return exam;
        }

        public int eliminarExamen()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();
            int exam = nuevoDB.eliminaExamen(this.idExamen);
            nuevoDB.cerrar();
            return exam;
        }

        public int actualizarExamen()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();
            int exam = nuevoDB.modificaExamen(this.idExamen,this.nombre);
            nuevoDB.cerrar();
            return exam;
            
        }

        public int consultarExamen()
        {
            return 0;
        }
        public static DataTable listaExamen()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();
            DataTable tabExamen = nuevoDB.listaExamenes();
            nuevoDB.cerrar();
            return tabExamen;
        }

    }
}
