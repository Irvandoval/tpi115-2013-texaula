using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistemaHospital.Datos;


namespace pruebas
{
    class Program
    {
        static void Main(string[] args)
        {
           DB n = new DB();
           // n.conectar();
            //int res = n.getIdUsuario("admin");
            Console.WriteLine(n.estadoConexion);
            Console.Read();
            n.cerrar();

        }
    }
}
