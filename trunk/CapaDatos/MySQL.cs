using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SistemaHospital.Datos
{
   public class MySQL
    {
       //  cadena para conectarse  a la DB
       public String cadenaConexion { get; set; }
      
       // Este metodo servira para hacer la obtencion de datos a la base
       public String obtenerDatos(int idPaciente){
           return "nada";
       }

    }
}
