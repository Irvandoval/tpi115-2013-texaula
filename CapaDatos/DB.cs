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
       public DB()
       {
           this.conectar();
       }

       /*metodo para conectarse a la base de datos*/
       public int conectar()
       {      
           try { conexion.Open(); }
           catch (Exception ex)
             {  
               estadoConexion = conexion.State.ToString();
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
           string sql = "SELECT count(*) from usuarios where userName=@username and pass=@pass and estado='ALTA'";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@pass", MySqlDbType.VarChar, 10).Value = contra;
           cmd.Parameters.Add("@username", MySqlDbType.VarChar, 10).Value = user;
           MySqlDataReader res = cmd.ExecuteReader();
         
           if (res.Read())
           {
               return res.GetInt32(0);
              
           }
           
           
           return 0;
          
       }


       public int editEstadoUsuario(string nuevoEstado)
       {
           return 0;//HAY QUE IMPLEMENTARLO XD
       }

       public int getIdUsuario(string user)
       {
           String sql = "SELECT idUsuario from usuarios WHERE userName=@user";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@user", MySqlDbType.VarChar, 10).Value = user;
           MySqlDataReader res = cmd.ExecuteReader();
           int val=0;
         
           if (res.Read())
           {
               
              val =res.GetInt32(0);
              res.Close();
           }

         
           return val;
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
           String sql = "CALL SPUsuarios(null,@user,null,null,null,3)";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@user", MySqlDbType.VarChar, 10).Value = user;
          
           MySqlDataReader res = cmd.ExecuteReader();
           if (res.Read())
           {
               return res.GetInt32(0);
           }
           else return 0;
       }

       public int regisLogin(string user)
       {
           int iduser = getIdUsuario(user);
           string sql = "CALL SPRegUserLogs(@iduser,1)";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@iduser", MySqlDbType.Int32).Value = iduser;
           MySqlDataReader res = cmd.ExecuteReader();
           if (res.Read())
           {
               return res.GetInt32(0);
           }
           else return 0;

       }

       public int regisLogout()
       {
           string sql = "CALL SPRegUserLogs(null,2)";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
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
           string sql = "CALL SPMedicos(@dui,null,null,null,null,null,null,3)";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@dui", MySqlDbType.VarChar, 10).Value = dui;
           MySqlDataReader res = cmd.ExecuteReader();

           if (res.Read())
           {
               return res.GetInt32(0);
           }
           return 0;
       }

       public void listaMedicos()
       {
           string sql = "SELECT * from Medicos";
          
       }


/*------------------------------------------------------Metodos que gestionan a los Recepcionistas-------------------------------------*/
       public int addRecepcionista(string dui, int idUser,string nombres, string apellidos,string fechaNacimiento ) {
           string sql = "CALL SPRecepcionistas(@dui,@idUsuario,@nombres,@apellidos,@fechanacimiento,1)";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@dui", MySqlDbType.VarChar, 10).Value = dui;
           cmd.Parameters.Add("@iduser", MySqlDbType.Int32).Value = idUser;
           cmd.Parameters.Add("@nombres", MySqlDbType.VarChar, 45).Value = nombres;
           cmd.Parameters.Add("@apellidos", MySqlDbType.VarChar, 45).Value = apellidos;
           cmd.Parameters.Add("@fechaNacimiento", MySqlDbType.Date).Value = fechaNacimiento;
           MySqlDataReader res = cmd.ExecuteReader();

           if (res.Read())
           {
               return res.GetInt32(0);
           }
           return 0;
       }

       public int eliminaRecepcionsta(string dui)
       {
           string sql = "CALL SPRecepcionistas(@dui,null,null,null,null,3)";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@dui", MySqlDbType.VarChar, 10).Value = dui;
           MySqlDataReader res = cmd.ExecuteReader();

           if (res.Read())
           {
               return res.GetInt32(0);
           }
           return 0;
       }

       public void listaRecepcionistas()
       {
       }
       

 /*------------------------------------------------Metodos que gestionan las enfermeras-------------------------------------------------*/ 

     public int addEnfermera(string dui, string nombres,string apellidos,string fechaNacimiento){
         string sql= "CAll SPEnfermeras(@dui,@nombres,@apellidos,@fechaNacimiento,1)";
          MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@dui", MySqlDbType.VarChar, 10).Value = dui;
           cmd.Parameters.Add("@nombres", MySqlDbType.VarChar, 45).Value = nombres;
           cmd.Parameters.Add("@apellidos", MySqlDbType.VarChar, 45).Value = apellidos;
           cmd.Parameters.Add("@fechaNacimiento", MySqlDbType.Date).Value = fechaNacimiento;
         MySqlDataReader res = cmd.ExecuteReader();

           if (res.Read())
           {
               return res.GetInt32(0);
           }
           return 0;
     }

       public int eliminaEnfermera(string dui)
       {
           string sql = "CALL SPEnfermeras(@dui,null,null,null,3)";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@dui", MySqlDbType.VarChar, 10).Value = dui;
           MySqlDataReader res = cmd.ExecuteReader();

           if (res.Read())
           {
               return res.GetInt32(0);
           }
           return 0;
       }

       public void listaEnfermera(){
           //not implemented yet xD
       }


 /*---------------------------------------Metodos que gestionan a los expedientes------------------*/

       public int addExpediente(int idExpediente,string dui,int idDiagnostico)
       {
           string sql = "CALL SPExpedientes(@idExpediente,@dui,@idDiag,1)";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@idExpediente", MySqlDbType.Int32).Value = idExpediente;
           cmd.Parameters.Add("@dui", MySqlDbType.VarChar, 10).Value = dui;
           cmd.Parameters.Add("@idDiag", MySqlDbType.Int32).Value = idDiagnostico;
           MySqlDataReader res = cmd.ExecuteReader();
           if (res.Read())
           {
               return res.GetInt32(0);
           }
           return 0;
       }

      public int getIdExpediente(string iud){
           string sql= "SELECT idexpediente from expedientes where dui=@dui ";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@dui", MySqlDbType.VarChar, 10).Value = iud;
           MySqlDataReader res = cmd.ExecuteReader();
           int val=0;
          if (res.Read())

           {
              val=res.GetInt32(0);
              
           }

          res.Close();
           return val;

      }
      
       public int eliminaExpediente(string dui)
       {
           
           int id=getIdExpediente(dui);
           string sql="CALL SPExpedientes(@idExp,null,null,3)";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@idTratamiento", MySqlDbType.Int32).Value = id;
           MySqlDataReader res = cmd.ExecuteReader();
           if (res.Read())
           {
               return res.GetInt32(0);
           }
           return 0;
       }
       
/*----------------------------------------Metodos que gestionan Tratamientos---------*/

       public int addTratamiento(string nombre)
       {
           string sql = "CALL SPExpedientes(null,@nombre,1)";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           //cmd.Parameters.Add("@idTratamiento", MySqlDbType.Int32).Value = idTrat;
           MySqlDataReader res = cmd.ExecuteReader();
           if (res.Read())
           {
               return res.GetInt32(0);
           }
           return 0;

       }

       public int getidTratamiento(string name)
       {
           string sql = "SELECT idtratamiento FROM tratamientos WHERE nombre=@nombre";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@nombre", MySqlDbType.VarChar, 10).Value = name;
           MySqlDataReader res = cmd.ExecuteReader();
           int val = 0;
           if (res.Read())
           {
               val= res.GetInt32(0);
           }
           res.Close();
           return val;

       }


       public int eliminaTratamiento(string nombre)
       {
           int id=this.getidTratamiento(nombre);
           string sql = "CALL SPExpedientes(@idTratamiento,null,3)";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@idTratamiento", MySqlDbType.Int32).Value = id;
           MySqlDataReader res = cmd.ExecuteReader();
           if (res.Read())
           {
               return res.GetInt32(0);
           }
           return 0;
       }
/*------------------------------Metodos que gestionan consultas---------------------*/
       public int addConsulta(int idExpediente,string duiMedico, string motivo)
       {//supondremos que la fecha de la consulta es hoy!!


           return 0;
       }

       public int eliminaConsulta(int idConsulta)
       {
           return 0;
       }
/*----------------------------------Metodos que gestionan Paciente--------------------*/
       public int addPaciente(string nombres, string apellidos, string dui, string telefono,
       string fechaNac, string seguro, string sexo, string estado)
       {
           return 0;
       }
       public int eliminaPaciente(string dui)
       {
           return 0;
       }
/*------------------------------------------------------------------------------------*/

    }
}
