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
        private string dui;

        public string Dui
        {
            get { return dui; }
            set { dui = value; }
        }
        private int idUsuario;

        public int IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }
        private string nombres;

        public string Nombres
        {
            get { return nombres; }
            set { nombres = value; }
        }
        private string apellidos;

        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }
        private string fechaNac;

        public string FechaNac
        {
            get { return fechaNac; }
            set { fechaNac = value; }
        }

        public int agregarRecepcionista()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();
            int  rcp= nuevoDB.addRecepcionista(this.dui,this.idUsuario,this.nombres,this.apellidos,this.fechaNac);
            nuevoDB.cerrar();
            return rcp;
        }

        public int eliminarRecepcionista()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();
            int  rcp= nuevoDB.eliminaRecepcionsta(this.dui);
            nuevoDB.cerrar();
            return rcp;
           
        }

        public int actualizarRecepcionista()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();
            int rcp = nuevoDB.modificaRecepcionista(this.dui, this.idUsuario, this.nombres, this.apellidos, this.fechaNac);
            nuevoDB.cerrar();
            return rcp;
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
