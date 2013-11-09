using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace SistemaHospital.Datos
{
   public class DB
    {
       MySqlConnection conexion = new MySqlConnection("data source=localhost;user=root;password=;database=sistemahospital");
       public string estadoConexion;
       MySqlDataAdapter adaptador = new MySqlDataAdapter();
       

       /*metodo para conectarse a la base de datos*/
       public int conectar()
       {      
        try { conexion.Open(); }
        catch (Exception ex)
        {   estadoConexion = conexion.State.ToString();
            return 0; 
        }
        return 1;
       }

       public void cerrar()
       {
           conexion.Close();
       }

      
       
       
       
/* ------------------------------------------ METODOS QUE GESTIONAN LOS USUARIOS -------------------------------------------------------------------*/
       
       public int logUsuario(string user,string contra)
       {
         // string sql=string.Concat("CALL SPUsuarios(",idUser,",",username,",",contra,",",tipoUser,",",estado,",",tipoGestion,");");
           
          
           string sql = "SELECT count(*) from usuarios where userName=@username and pass=@pass and estado='ALTA'";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
          /*adaptador.SelectCommand.Parameters.Add("@username", MySqlDbType.VarChar,10).Value = "mierda";
           adaptador.SelectCommand.Parameters.Add("@pass", MySqlDbType.VarChar,15).Value = contra;*/
           cmd.Parameters.Add("@pass", MySqlDbType.VarChar, 10).Value = contra;
           cmd.Parameters.Add("@username", MySqlDbType.VarChar, 10).Value = user;
           
           MySqlDataReader res = cmd.ExecuteReader();
           if (res.Read())
           {
               return res.GetInt32(0);
           }
           else return 0;
       }

       public int getIdUsuario(string user)
       {
           String sql = "SELECT idUsuario from usuarios WHERE userName=@user";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@user", MySqlDbType.VarChar, 10).Value = user;
           MySqlDataReader res = cmd.ExecuteReader();
           if (res.Read())
           {
               return res.GetInt32(0);
           }
           else return 0;
       }

       public int addUsuario(string user, string contra, string tipo)
       {
           String sql = "CALL SPUsuarios(null,@user,@pass,@tipo,'ALTA',1)";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@user",MySqlDbType.VarChar,10).Value=user;
           cmd.Parameters.Add("@pass", MySqlDbType.VarChar, 10).Value = contra;
           cmd.Parameters.Add("@tipo", MySqlDbType.VarChar, 10).Value = tipo;
           MySqlDataReader res = cmd.ExecuteReader();
           if (res.Read())
           {
               return res.GetInt32(0);
           }
           else return 0;

       }


       public int eliminaUsuario(string user)
       {
           int iduser = getIdUsuario(user);
           String sql = "CALL SPUsuarios(@iduser,@user,@pass,@tipo,'ALTA',3)";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@user", MySqlDbType.VarChar, 10).Value = user;
           cmd.Parameters.Add("@user", MySqlDbType.Int32).Value = iduser;
           MySqlDataReader res = cmd.ExecuteReader();
           if (res.Read())
           {
               return res.GetInt32(0);
           }
           else return 0;
       }



       public void listaUsuarios()
       {
           //implementar esto deberia retornar un tipo de dato tabla
       }
       
/*-------------------------------------------------------Metodos que gestionan a los Medicos------------------------------------------*/

       public int addMedico(string dui, int idUser, string nombres, string apellidos, string fechaNacimiento, string sexo, string jvmp)
       {
           string sql= "CALL SPMedicos(@dui,@iduser,@nombres,@apellidos,@fechaNacimiento,@sexo,@jvmp,1)";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@dui", MySqlDbType.VarChar, 10).Value = dui;
           cmd.Parameters.Add("@iduser", MySqlDbType.Int32).Value = idUser;
           cmd.Parameters.Add("@nombres", MySqlDbType.VarChar, 45).Value = nombres;
           cmd.Parameters.Add("@apellidos", MySqlDbType.VarChar, 45).Value = apellidos;
           cmd.Parameters.Add("@fechaNacimiento", MySqlDbType.Date).Value = fechaNacimiento;
           cmd.Parameters.Add("@sexo", MySqlDbType.VarChar, 10).Value = sexo;
           MySqlDataReader res = cmd.ExecuteReader();
          
           if (res.Read())
           {
               return res.GetInt32(0);
           }
           else return 0;
           
       }


       public int eliminaMedico(string dui)
       {
           return 0;
       }

       public void listaMedicos()
       {
           string sql = "SELECT * from Medicos";
          
       }


/*------------------------------------------------------Metodos que gestionan a los Recepcionistas-------------------------------------*/
       public int addRecepcionista() {

           return 0;
       }
       

 /*------------------------------------------------Metodos que gestionan las enfermeras-------------------------------------------------*/ 

  

 /*---------------------------------------Metodos que gestionan a los expedientes------------------*/

/*--------------------------------------------------------------------------------------------------*/

    }
}
