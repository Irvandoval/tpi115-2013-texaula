using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

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
           cmd.Parameters.Add("@pass", MySqlDbType.VarChar, 25).Value = contra;
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
           cmd.Parameters.Add("@pass", MySqlDbType.VarChar, 25).Value = contra;
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

       public DataTable listaUsuarios()
       { DataTable tabla = new DataTable("Usuarios");


           if (String.Equals(this.estadoConexion,"Open"))
           {
              
               String sql = "SELECT * from usuarios";
               MySqlCommand cmd = new MySqlCommand(sql, conexion);
               MySqlDataAdapter returnVal = new MySqlDataAdapter(sql, conexion);
               returnVal.Fill(tabla);
             
           }
           else{
               this.cerrar();
               
           }
           return tabla;
       }


       public int modificaUsuario(int idUser, int username, string contra, string tipo, string estado)
       {
           string sql = "SPUsuarios(@iduser,@username,@pass,@tipo,@estado,2)";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@iduser", MySqlDbType.Int32).Value = idUser;
           cmd.Parameters.Add("@username", MySqlDbType.VarChar, 10).Value = username;
           cmd.Parameters.Add("@pass", MySqlDbType.VarChar, 25).Value = contra;
           cmd.Parameters.Add("@tipo", MySqlDbType.VarChar, 10).Value = tipo;
           cmd.Parameters.Add("@estado", MySqlDbType.VarChar, 10).Value = estado;
           MySqlDataReader res = cmd.ExecuteReader();
           if (res.Read())
           {
               return res.GetInt32(0);
           }
           return 0;
         
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

       public DataTable listaMedicos()
       {
           DataTable tmed = new DataTable("Medicos");
           if (String.Equals(this.estadoConexion, "Open"))
           {

               String sql = "SELECT * from medicos";
               MySqlCommand cmd = new MySqlCommand(sql, conexion);
               MySqlDataAdapter returnVal = new MySqlDataAdapter(sql, conexion);
               returnVal.Fill(tmed);

           }
           else
           {
               this.cerrar();

           }
           return tmed;
       }


       public int modificaMedico(string dui,int idusuario,string nombres,string apellidos, string fechaNacimento,string sexo , string jvmp)
       {
           return 0;    
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

       public DataTable listaRecepcionistas()
       {
           DataTable trep = new DataTable("Recepcionistas");
           if (String.Equals(this.estadoConexion, "Open"))
           {

               String sql = "SELECT * from recepcionistas";
               MySqlCommand cmd = new MySqlCommand(sql, conexion);
               MySqlDataAdapter returnVal = new MySqlDataAdapter(sql, conexion);
               returnVal.Fill(trep);

           }
           else
           {
               this.cerrar();

           }
           return trep;
       }

       public int modificaRecepcionista(string dui,string nombres, string apellidos)
       {
           return 0;
       }

       /*------------------------------------------------------Metodos que gestionan -------------------------------------*/
      

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

       public DataTable listaEnfermera(){
           DataTable tenf = new DataTable("Enfermeras");
           if (String.Equals(this.estadoConexion, "Open"))
           {

               String sql = "SELECT * from enfermeras";
               MySqlCommand cmd = new MySqlCommand(sql, conexion);
               MySqlDataAdapter returnVal = new MySqlDataAdapter(sql, conexion);
               returnVal.Fill(tenf);

           }
           else
           {
               this.cerrar();
               
           }
           return tenf;
       }


       public int modificaEnfermera( string dui ,string nombres,string apellidos,string fechaNacimiento)
       {
           return 0;

       }

       /*------------------------------------------------------Metodos que gestionan a los Recepcionistas-------------------------------------*/
     /*  public int addRecepcionista(string dui, int idUser, string nombres, string apellidos, string fechaNacimiento)
       {
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
       */

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

       public int modificaExpediente(int idExpediente,string dui_paciente,int idDiag)
       {
           return 0;
       }
       
/*----------------------------------------Metodos que gestionan Tratamientos---------*/

       public int addTratamiento(string nombre)
       {
           string sql = "CALL SPTratamientos(null,@nombre,1)";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@nombre", MySqlDbType.VarChar, 45).Value = nombre;
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
           string sql = "CALL SPTratamientos(@idTratamiento,null,3)";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@idTratamiento", MySqlDbType.Int32).Value = id;
           MySqlDataReader res = cmd.ExecuteReader();
           if (res.Read())
           {
               return res.GetInt32(0);
           }
           return 0;
       }


       public DataTable listaTratamientos()
       {
           DataTable ttrat = new DataTable("Tratamientos");
           if (String.Equals(this.estadoConexion, "Open"))
           {

               String sql = "SELECT * from tratamientos";
               MySqlCommand cmd = new MySqlCommand(sql, conexion);
               MySqlDataAdapter returnVal = new MySqlDataAdapter(sql, conexion);
               returnVal.Fill(ttrat);

           }
           else
           {
               this.cerrar();

           }
           return ttrat;  
       }

       public int modificaTratamiento(int idtratamiento,string nombre)
       {
           return 0;
       }
/*------------------------------Metodos que gestionan consultas---------------------*/
       public int addConsulta(int idExpediente,string duiMedico, string motivo)
       {//supondremos que la fecha de la consulta es hoy!!
           string sql = "CALL SPConsultas(null,@idexp,@duimed,current_timestamp(),@motivo,1)";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@idexp", MySqlDbType.Int32).Value = idExpediente;
           cmd.Parameters.Add("@duimed",MySqlDbType.VarChar,10).Value=duiMedico;
           cmd.Parameters.Add("@motivo", MySqlDbType.VarChar, 10).Value = motivo;
           MySqlDataReader res = cmd.ExecuteReader();
           if (res.Read())
           {
               return res.GetInt32(0);
           }
          

           return 0;
       }

       public int eliminaConsulta(int idConsulta)
       {
           return 0;
       }



/*----------------------------------Metodos que gestionan Paciente--------------------*/
       public int addPaciente(string nombres, string apellidos, string dui, string telefono,
       string fechaNac, string seguro, string sexo, string estado,string direccion)
       {
           return 0;
       }
       public int eliminaPaciente(string dui)
       {
           return 0;
       }


       public DataTable ListarPaciente()
       {
           DataTable tpac = new DataTable("Pacientes");
           if (String.Equals(this.estadoConexion, "Open"))
           {

               String sql = "SELECT * from pacientes";
               MySqlCommand cmd = new MySqlCommand(sql, conexion);
               MySqlDataAdapter returnVal = new MySqlDataAdapter(sql, conexion);
               returnVal.Fill(tpac);

           }
           else
           {
               this.cerrar();

           }
           return tpac;
       }

       public int ModificarPaciente(string nombres, string apellidos, string dui, string telefono,
       string fechaNac, string seguro, string sexo, string estado,string direccion)
       {
           return 0;
       }
/*----------------------------------Gestion de Examenes--------------------------------------------------*/

       public int addExamen(string nombre)
       {
           string sql = "CALL SPConsultas(null,@nombre,1)";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@duimed", MySqlDbType.VarChar, 10).Value = duiMedico;

       }

       public int eliminaExamen(string idExamen)
       {
           return 0;
            
       }

       public int modificaExamen(string idExamen, string nombre)
       {
           return 0;
       }

       public DataTable listadeExamenes()
       {
           DataTable texa = new DataTable("Examenes");
           return texa;
       }
    /*-------------------------- Gestion de Urgencia---------------------------------------------*/

       public int agregarUrgencia(int idExpediente,string medicoDui,string enfermeraDui,string fechaEmergencia)
       {
           return 0;
       }

       public int eliminaUrgencia(int idUrgencia)
       {
           return 0;
       }

       public DataTable listaUrgencias(int idExpediente)
       {
           DataTable tur = new DataTable("urg");
           return tur;
       }

       public int modificaUrgencia(int idUrgencia,int idExpediente,string medicoDui,string enfermeraDui,string fechaEmergencia){
           return 0;
       }

       /*---------------------------------Gestion de Diagnosticos----------------------------------------------------------*/

       public int addDiagnostico(string nombre,string tipo , string fase)
       {
           return 0;
       }

       public int eliminarDiagnostico(int idDiagnostico){
           return 0;
       }
       public DataTable listaDiagnosticos(){
           DataTable tdiag= new DataTable("Diagnosticos");
           return tdiag;
       }

       public int modificaDiagnostico(int idDiagnostico,string nombre, string tipo, string fase)
       {
           return 0;
       }

       /*--------------------------------------------------------------------------------------------*/

    }
}
