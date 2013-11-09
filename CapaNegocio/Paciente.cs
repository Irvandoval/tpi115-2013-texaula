using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistemaHospital.Datos;
using MySql.Data.MySqlClient;

namespace SistemaHospital.Negocio
{
    public class Paciente
    {
        private string dui;
        private string nombres;
        private string apellidos;
        private string fechaNac;
        private string seguroMedico;
        private string sexo;
        private string direccion;
        private string telefono;
        private string estado;

        public int agregarPaciente()
        {
            return 0;
        }

        public int eliminarPaciente()
        {
            return 0;
        }

        public int actualizarPaciente()
        {
            return 0;
        }

        public int consultarPaciente()
        {
            return 0;
        }

    }
}
