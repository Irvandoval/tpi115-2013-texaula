using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistemaHospital.Datos;
using MySql.Data.MySqlClient;
using System.Data;

namespace SistemaHospital.Negocio
{
    public class Paciente
    {
        public Paciente(){
    
    }

        private string dui;

        public string Dui
        {
            get { return dui; }
            set { dui = value; }
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
        private string seguroMedico;

        public string SeguroMedico
        {
            get { return seguroMedico; }
            set { seguroMedico = value; }
        }
        private string sexo;

        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }
        private string direccion;

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        private string telefono;

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public int agregarPaciente()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();
            int res = nuevoDB.addPaciente(this.Nombres,this.Apellidos,this.Dui,this.Telefono,this.FechaNac,this.SeguroMedico,this.Sexo,this.Estado,this.Direccion);
            nuevoDB.cerrar();
            return res;
        }

        public int eliminarPaciente()
        {
            DB nuevoDB = new DB();
            nuevoDB.conectar();
            int res = nuevoDB.eliminaPaciente(this.Dui);
            nuevoDB.cerrar();
            return res;
            
        }

        public int actualizarPaciente()
        {
            DB nueviDB = new DB();
            nueviDB.conectar();
            int res = nueviDB.ModificarPaciente(this.Nombres,this.Apellidos,this.Dui,Telefono,this.FechaNac,this.SeguroMedico,this.Sexo,this.Estado,this.Direccion);
            nueviDB.cerrar();
            return res;
            
        }

        public int consultarPaciente()
        {
            return 0;
        }

        public static DataTable obtenerListaPacientes()
        {
            DB nuevo = new DB();
            nuevo.conectar();
            DataTable tabPacientes = nuevo.ListarPaciente();
            nuevo.cerrar();
            return tabPacientes;
        }

    }
}
