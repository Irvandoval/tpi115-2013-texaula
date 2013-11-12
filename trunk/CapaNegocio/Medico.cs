using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistemaHospital.Datos;
using MySql.Data.MySqlClient;
using System.Data;

namespace SistemaHospital.Negocio
{
    public class Medico
    {
        private string dui;
        private int idUsuario;
        private string nombres;
        private string apellidos;
        private string fechaNac;
        private string sexo;
        private string jvmp;

        public int agregarMedico()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();
            int res = nuevoDB.addMedico(this.dui,this.idUsuario,this.nombres,this.apellidos,this.fechaNac,this.sexo,this.jvmp);
            nuevoDB.cerrar();
            return res;
        }

        public int eliminarMedico()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();
            int res = nuevoDB.eliminaMedico(this.dui);
            nuevoDB.cerrar();
            return res;
        }

        public int actualizarMedico()
        {
            DB nuevoDB = new DB();
            return 0;
           
        }

        public static DataTable listaMedicos() {
            DB nuevoDB = new DB();
            nuevoDB.conectar();
            DataTable tabMedicos = nuevoDB.listaMedicos();
            nuevoDB.cerrar();
            return tabMedicos;
        }

    }
}
