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


       public String getTipoUsuario(string username)
       {
           DataTable tipoUsuario= new DataTable("usuario");
           string tu = "";
           if (String.Equals(this.estadoConexion, "Open"))
           {

               String sql = "CALL SPUsuarios(null,@user,null,null,null,4);";
               MySqlCommand cmd = new MySqlCommand(sql, conexion);
               MySqlDataAdapter returnVal = new MySqlDataAdapter(sql, conexion);
               returnVal.Fill(tipoUsuario);

           }
           else
           {
               this.cerrar();

           }

           return "jj";


       }

       public DataTable listaUsuarios()
       { DataTable tabla = new DataTable("Usuarios");


           if (String.Equals(this.estadoConexion,"Open"))
           {
              
               String sql = "call SPUsuarios(null,null,null,null,null,4)";
               MySqlCommand cmd = new MySqlCommand(sql, conexion);
               MySqlDataAdapter returnVal = new MySqlDataAdapter(sql, conexion);
               returnVal.Fill(tabla);
             
           }
           else{
               this.cerrar();
               
           }
           return tabla;
       }
        public DataSet obtenerUsuario()
       {
           DataSet dataUser= new DataSet("user");
            String sql = "select * from usuarios where idusuario=1";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           MySqlDataAdapter returnVal = new MySqlDataAdapter(sql, conexion);
           returnVal.Fill(dataUser);
            return dataUser;

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

               String sql = "call SPMedicos(null,null,null,null,null,null,null,4)";
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
           string sql = "CALL SPMedicos(@dui,@iduser,@nombres,@apellidos,@fechaNacimiento,@sexo,@jvmp,2)";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@dui", MySqlDbType.VarChar, 10).Value = dui;
           cmd.Parameters.Add("@iduser", MySqlDbType.Int32).Value = idusuario;
           cmd.Parameters.Add("@nombres", MySqlDbType.VarChar, 45).Value = nombres;
           cmd.Parameters.Add("@apellidos", MySqlDbType.VarChar, 45).Value = apellidos;
           cmd.Parameters.Add("@fechaNacimiento", MySqlDbType.Date).Value = fechaNacimento;
           cmd.Parameters.Add("@sexo", MySqlDbType.VarChar, 10).Value = sexo;
           MySqlDataReader res = cmd.ExecuteReader();

           int v = 0;
           if (res.Read())
           {
              v= res.GetInt32(0);
           }
           

           return v;    
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

               String sql = "CALL SPRecepcionistas(null,null,null,null,4)";
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
       public int modificaRecepcionista(string dui, int idUser, string nombres, string apellidos, string fechaNacimiento)
       {
           string sql = "CALL SPRecepcionistas(@dui,@idUsuario,@nombres,@apellidos,@fechanacimiento,2)";
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

               String sql = "CALL SPEnfermeras(null,null,null,null,4)";
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


       public int modificaEnfermera(string dui, string nombres, string apellidos, string fechaNacimiento)
       {
           string sql = "CAll SPEnfermeras(@dui,@nombres,@apellidos,@fechaNacimiento,2)";
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
           string sql = "CALL SPExpedientes(@idexp,@dui,@diag,2)";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@idexp", MySqlDbType.Int32).Value = idExpediente;
           cmd.Parameters.Add("@dui", MySqlDbType.VarChar,10).Value = dui_paciente;
           cmd.Parameters.Add("@diag", MySqlDbType.Int32).Value = idDiag;
           MySqlDataReader res = cmd.ExecuteReader();
           int val = 0;
           if (res.Read())
           {
             val= res.GetInt32(0);
           }
           return val;
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

               String sql = "CALL SPTratamientos(null,null,4)";
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
           string sql = "CALL SPTratamientos(@idTratamiento,@nombre,2)";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@idTratamiento", MySqlDbType.Int32).Value = idtratamiento;
           cmd.Parameters.Add("@nombre", MySqlDbType.VarChar,45).Value = nombre;
           int val = 0;
            MySqlDataReader res = cmd.ExecuteReader();
           if (res.Read())
           {
              val= res.GetInt32(0);
           }


           return val;
       }
/*------------------------------Metodos que gestionan consultas---------------------*/
       public int addConsulta(int idExpediente,string duiMedico, string motivo)
       {//supondremos que la fecha de la consulta es hoy!!
           string sql = "CALL SPConsultas(null,@idexp,@duimed,current_timestamp(),@motivo,1)";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@idexp", MySqlDbType.Int32).Value = idExpediente;
           cmd.Parameters.Add("@duimed",MySqlDbType.VarChar,10).Value=duiMedico;
           cmd.Parameters.Add("@motivo", MySqlDbType.VarChar, 100).Value = motivo;
           MySqlDataReader res = cmd.ExecuteReader();
           if (res.Read())
           {
               return res.GetInt32(0);
           }
          

           return 0;
       }

       public int eliminaConsulta(int idConsulta)
       {
           string sql = "CALL SPConsultas(@idConsulta,null,null,null,null,3)";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@idconsulta", MySqlDbType.Int32).Value = idConsulta;
           MySqlDataReader res = cmd.ExecuteReader();
           if (res.Read())
           {
               return res.GetInt32(0);
           }
          
           return 0;
       }

       public int modificaConsulta(int idConsulta, int idExpediente,string fecha, string duiMedico,string motivo) { 
            string sql = "CALL SPConsultas(@idconsulta,@idexp,@duimed,@fecha,@motivo,2)";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@idconsulta", MySqlDbType.Int32).Value = idConsulta;
           cmd.Parameters.Add("@idexp", MySqlDbType.Int32).Value = idExpediente;
           cmd.Parameters.Add("@duimed",MySqlDbType.VarChar,10).Value=duiMedico;
           cmd.Parameters.Add("@motivo", MySqlDbType.VarChar, 100).Value = motivo;
           cmd.Parameters.Add("@fecha", MySqlDbType.DateTime).Value = fecha;
           MySqlDataReader res = cmd.ExecuteReader();
           if (res.Read())
           {
               return res.GetInt32(0);
           }
           return 0;
       }



/*----------------------------------Metodos que gestionan Paciente--------------------*/
       public int addPaciente(string nombres, string apellidos, string dui, string telefono,
       string fechaNac, string seguro, string sexo, string estado,string direccion)
       {
           string sql = "call SPPAcientes(@dui,@nombres,@apellidos,@fechaNacimiento,@seguro,@sexo,@direccion,@telefono,@estado,1)";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
         //  cmd.Parameters.Add("@idexp", MySqlDbType.Int32).Value = idExpediente;
           cmd.Parameters.Add("@dui", MySqlDbType.VarChar, 10).Value = dui;
           cmd.Parameters.Add("@nombres", MySqlDbType.VarChar, 45).Value = nombres;
           cmd.Parameters.Add("@apellidos", MySqlDbType.VarChar, 45).Value = apellidos;
           cmd.Parameters.Add("@fechaNacimeinto", MySqlDbType.Date).Value = fechaNac;
           cmd.Parameters.Add("@seguro", MySqlDbType.VarChar, 45).Value = seguro;
           cmd.Parameters.Add("@sexo", MySqlDbType.VarChar, 10).Value = sexo;
           cmd.Parameters.Add("@direccion", MySqlDbType.VarChar, 100).Value = direccion;
           cmd.Parameters.Add("@telefono", MySqlDbType.VarChar, 15).Value = telefono;
           cmd.Parameters.Add("@estado", MySqlDbType.VarChar, 10).Value = estado;
           MySqlDataReader res = cmd.ExecuteReader();
           if (res.Read())
           {
               return res.GetInt32(0);
           }


           return 0;
       }


       public int eliminaPaciente(string dui)
       {
           string sql = "call SPPAcientes(@dui,null,null,null,null,null,null,null,null,3)";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@dui", MySqlDbType.VarChar, 10).Value = dui;
           MySqlDataReader res = cmd.ExecuteReader();
           if (res.Read())
           {
               return res.GetInt32(0);
           }


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
           string sql = "call SPPAcientes(@dui,@nombres,@apellidos,@fechaNacimiento,@seguro,@sexo,@direccion,@telefono,@estado,2)";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           //  cmd.Parameters.Add("@idexp", MySqlDbType.Int32).Value = idExpediente;
           cmd.Parameters.Add("@dui", MySqlDbType.VarChar, 10).Value = dui;
           cmd.Parameters.Add("@nombres", MySqlDbType.VarChar, 45).Value = nombres;
           cmd.Parameters.Add("@apellidos", MySqlDbType.VarChar, 45).Value = apellidos;
           cmd.Parameters.Add("@fechaNacimeinto", MySqlDbType.Date).Value = fechaNac;
           cmd.Parameters.Add("@seguro", MySqlDbType.VarChar, 45).Value = seguro;
           cmd.Parameters.Add("@sexo", MySqlDbType.VarChar, 10).Value = sexo;
           cmd.Parameters.Add("@direccion", MySqlDbType.VarChar, 100).Value = direccion;
           cmd.Parameters.Add("@telefono", MySqlDbType.VarChar, 15).Value = telefono;
           cmd.Parameters.Add("@estado", MySqlDbType.VarChar, 10).Value = estado;
           MySqlDataReader res = cmd.ExecuteReader();
           if (res.Read())
           {
               return res.GetInt32(0);
           }


           return 0;
         
       }
/*----------------------------------Gestion de Examenes--------------------------------------------------*/

       public int addExamen(string nombre)
       {
           string sql = "CALL SPExamenes(null,@nombre,1)";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@nombre",MySqlDbType.VarChar,45).Value = nombre;
           MySqlDataReader res = cmd.ExecuteReader();
           int val = 0;
           if (res.Read())
           {
               val= res.GetInt32(0);
           }


           return val;
          


       }

       public int eliminaExamen(int idExamen)
       {
           string sql = "CALL SPExamenes(@idExamen,null,3)";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@idExamen", MySqlDbType.Int32).Value = idExamen;
           MySqlDataReader res = cmd.ExecuteReader();
           int val = 0;
           if (res.Read())
           {
               val = res.GetInt32(0);
           }

           return val;   
       }

       public int modificaExamen(int idExamen, string nombre)
       {
           string sql = "CALL SPExamenes(@idExamen,@nombre,2)";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@idExamen", MySqlDbType.Int32).Value = idExamen;
           cmd.Parameters.Add("@nombre", MySqlDbType.VarChar,45).Value =nombre;
           MySqlDataReader res = cmd.ExecuteReader();
           int val = 0;
           if (res.Read())
           {
               val = res.GetInt32(0);
           }

           return val;   
       }

       public DataTable listaExamenes()
       {
           DataTable texa = new DataTable("Examenes");
           if (String.Equals(this.estadoConexion, "Open"))
           {

               String sql = "CALL SPExamenes(null,null,4)";
               MySqlCommand cmd = new MySqlCommand(sql, conexion);
               MySqlDataAdapter returnVal = new MySqlDataAdapter(sql, conexion);
               returnVal.Fill(texa);

           }
           else
           {
               this.cerrar();

           }
           return texa;
       }
    /*-------------------------- Gestion de Urgencia---------------------------------------------*/

       public int agregarUrgencia(int idExpediente,string medicoDui,string enfermeraDui,string fechaEmergencia)
       {
           string sql = "call SPUrgencia(null,@idExpediente,@medico_dui,@enfermera_dui,@fecha,1)";
          
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@idExpediente", MySqlDbType.Int32).Value = idExpediente;
           cmd.Parameters.Add("@medico_dui", MySqlDbType.VarChar,10).Value = medicoDui;
           cmd.Parameters.Add("@enfermera_dui", MySqlDbType.VarChar,10).Value = enfermeraDui;
           cmd.Parameters.Add("@fecha", MySqlDbType.DateTime).Value = fechaEmergencia;
           MySqlDataReader res = cmd.ExecuteReader();
           int val = 0;
           if (res.Read())
           {
               val = res.GetInt32(0);
           }

           return val; 

       }

       public int eliminaUrgencia(int idUrgencia)
       {

           string sql = "call SPUrgencia(@idUrgencia,null,null,null,null,3)";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@idExpediente", MySqlDbType.Int32).Value = idUrgencia;

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

       public int addDiagnostico(int iddiag,string nombre,string tipo , string fase)
       {
           string sql = "CALL SPDiagnosticos(@id,@nombre,@tipo,@fase,1)";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = iddiag;
           cmd.Parameters.Add("@nombre", MySqlDbType.VarChar,45).Value =nombre;
           cmd.Parameters.Add("@tipo", MySqlDbType.VarChar,45).Value =tipo;
           cmd.Parameters.Add("@fase", MySqlDbType.VarChar,45).Value =fase;
           MySqlDataReader res = cmd.ExecuteReader();
           int val = 0;
           if (res.Read())
           {
               val = res.GetInt32(0);
           }

           return val;
          
       }

       public int eliminarDiagnostico(int idDiagnostico){
           return 0;
       }
       public DataTable listaDiagnosticos(){
           DataTable tdiag= new DataTable("Diagnosticos");
           if (String.Equals(this.estadoConexion, "Open"))
           {

               String sql = "call SPDiagnosticos(null,null,null,null,4)";
               MySqlCommand cmd = new MySqlCommand(sql, conexion);
               MySqlDataAdapter returnVal = new MySqlDataAdapter(sql, conexion);
               returnVal.Fill(tdiag);

           }
           else
           {
               this.cerrar();

           }
           return tdiag;
        
       }

       public int modificaDiagnostico(int idDiagnostico,string nombre, string tipo, string fase)
       {
           string sql = "CALL SPDiagnosticos(@id,@nombre,@tipo,@fase,2)";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = idDiagnostico;
           cmd.Parameters.Add("@nombre", MySqlDbType.VarChar, 45).Value = nombre;
           cmd.Parameters.Add("@tipo", MySqlDbType.VarChar, 45).Value = tipo;
           cmd.Parameters.Add("@fase", MySqlDbType.VarChar, 45).Value = fase;
           MySqlDataReader res = cmd.ExecuteReader();
           int val = 0;
           if (res.Read())
           {
               val = res.GetInt32(0);
           }

           return val;
       }

       /*-------------------------------------RegistrodeExamenes-------------------------------------------------------*/
       public int addRegistroExamen(int idExpediente, int idExamen,String fecha,string resultados)
       {
           string sql = "call SPExpedienteExamen(null,@idExpediente,@idExamen,@fecha,@resultados,1)";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@idExpediente", MySqlDbType.Int32).Value = idExpediente;
           cmd.Parameters.Add("@idExamen", MySqlDbType.Int32, 45).Value = idExamen;
           cmd.Parameters.Add("@fecha", MySqlDbType.DateTime).Value = fecha;
           cmd.Parameters.Add("@resultados", MySqlDbType.VarChar, 100).Value =resultados;
           MySqlDataReader res = cmd.ExecuteReader();
           int val = 0;
           if (res.Read())
           {
               val = res.GetInt32(0);
           }

           return val;
       }

       public int eliminaRegistroExamen(int idReg)
       {

           string sql = "call SPExpedienteExamen(@idReg,null,null,null,null,3)";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@idReg", MySqlDbType.Int32).Value = idReg;
           MySqlDataReader res = cmd.ExecuteReader();
           int val = 0;
           if (res.Read())
           {
               val = res.GetInt32(0);
           }

           return val;
       }

       public int modificaRegistroExamen(int idReg,int idExpediente, int idExamen, String fecha, string resultados)
       {
           string sql = "call SPExpedienteExamen(@idReg,@idExpediente,@idExamen,@fecha,@resultados,2)";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@idExpediente", MySqlDbType.Int32).Value = idExpediente;
           cmd.Parameters.Add("@idExamen", MySqlDbType.Int32, 45).Value = idExamen;
           cmd.Parameters.Add("@fecha", MySqlDbType.DateTime).Value = fecha;
           cmd.Parameters.Add("@resultados", MySqlDbType.VarChar, 100).Value = resultados;
           MySqlDataReader res = cmd.ExecuteReader();
           int val = 0;
           if (res.Read())
           {
               val = res.GetInt32(0);
           }

           return val;
       }

       /*---------------------------------------------------registroTratamientos-------------------------------------------*/
       public int addRegistroTratamiento( int idExpediente,int idTratamiento,string fecha)
       {
           string sql = "call SPExpediente(null,@idExpediente,@idTratamiento,@fecha,1)";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@idExpediente", MySqlDbType.Int32).Value = idExpediente;
           cmd.Parameters.Add("@idTratamiento", MySqlDbType.Int32, 45).Value = idTratamiento;
           cmd.Parameters.Add("@fecha", MySqlDbType.DateTime).Value = fecha;
           MySqlDataReader res = cmd.ExecuteReader();
           int val = 0;
           if (res.Read())
           {
               val = res.GetInt32(0);
           }

           return val;

       }

       public int eliminaRegistroTratamiento(int idReg)
       {

           string sql = "call SPExpediente(@idReg,null,null,null,3)";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@idReg", MySqlDbType.Int32).Value = idReg;
           MySqlDataReader res = cmd.ExecuteReader();
           int val = 0;
           if (res.Read())
           {
               val = res.GetInt32(0);
           }

           return val;
       }

       public int modificaRegistroTratamiento(int idReg,int idExpediente, int idTratamiento, string fecha)
       {
           string sql = "call SPExpediente(@idReg,@idExpediente,@idTratamiento,@fecha,2)";
           MySqlCommand cmd = new MySqlCommand(sql, conexion);
           cmd.Parameters.Add("@idReg", MySqlDbType.Int32).Value = idReg;
           cmd.Parameters.Add("@idExpediente", MySqlDbType.Int32).Value = idExpediente;
           cmd.Parameters.Add("@idTratamiento", MySqlDbType.Int32, 45).Value = idTratamiento;
           cmd.Parameters.Add("@fecha", MySqlDbType.DateTime).Value = fecha;
           MySqlDataReader res = cmd.ExecuteReader();
           int val = 0;
           if (res.Read())
           {
               val = res.GetInt32(0);
           }

           return val;

       }
       /*-----------------------------------------------------------------------------------------------------------*/

    }
}
