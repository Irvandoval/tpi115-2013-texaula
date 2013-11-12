SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

DROP SCHEMA IF EXISTS `sistemahospital` ;
CREATE SCHEMA IF NOT EXISTS `sistemahospital` DEFAULT CHARACTER SET utf8 ;
USE `sistemahospital` ;

-- -----------------------------------------------------
-- Table `sistemahospital`.`diagnosticos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sistemahospital`.`diagnosticos` (
  `idDiagnostico` INT(11) NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(20) NOT NULL,
  `tipo` VARCHAR(20) NOT NULL,
  `fase` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`idDiagnostico`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sistemahospital`.`pacientes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sistemahospital`.`pacientes` (
  `dui` VARCHAR(10) NOT NULL,
  `nombres` VARCHAR(45) NOT NULL,
  `apellidos` VARCHAR(45) NOT NULL,
  `fechaNacimiento` DATE NOT NULL,
  `seguroMedico` VARCHAR(45) NULL DEFAULT NULL,
  `sexo` VARCHAR(10) NOT NULL,
  `direccion` VARCHAR(45) NULL DEFAULT NULL,
  `telefono` VARCHAR(15) NULL DEFAULT NULL,
  `estado` VARCHAR(10) NULL DEFAULT NULL,
  PRIMARY KEY (`dui`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sistemahospital`.`expedientes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sistemahospital`.`expedientes` (
  `idExpediente` INT(11) NOT NULL AUTO_INCREMENT,
  `dui` VARCHAR(10) NOT NULL,
  `idDiagnostico` INT(11) NOT NULL,
  PRIMARY KEY (`idExpediente`),
  INDEX `fk_expediente_paciente1_idx` (`dui` ASC),
  INDEX `fk_expediente_diagnostico1_idx` (`idDiagnostico` ASC),
  CONSTRAINT `fk_expediente_diagnostico1`
    FOREIGN KEY (`idDiagnostico`)
    REFERENCES `sistemahospital`.`diagnosticos` (`idDiagnostico`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_expediente_paciente1`
    FOREIGN KEY (`dui`)
    REFERENCES `sistemahospital`.`pacientes` (`dui`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sistemahospital`.`usuarios`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sistemahospital`.`usuarios` (
  `idUsuario` INT(11) NOT NULL AUTO_INCREMENT,
  `userName` VARCHAR(10) NOT NULL,
  `pass` VARCHAR(25) NOT NULL,
  `tipo` VARCHAR(10) NOT NULL,
  `estado` VARCHAR(4) NOT NULL,
  PRIMARY KEY (`idUsuario`),
  UNIQUE INDEX `userName_UNIQUE` (`userName` ASC))
ENGINE = InnoDB
AUTO_INCREMENT = 11
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sistemahospital`.`medicos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sistemahospital`.`medicos` (
  `dui` VARCHAR(10) NOT NULL,
  `idUsuario` INT(11) NOT NULL,
  `nombres` VARCHAR(45) NOT NULL,
  `apellidos` VARCHAR(45) NOT NULL,
  `fechaNacimiento` DATE NOT NULL,
  `sexo` VARCHAR(10) NOT NULL,
  `jvmp` VARCHAR(4) NOT NULL,
  PRIMARY KEY (`dui`),
  INDEX `fk_Medicos_Usuarios1_idx` (`idUsuario` ASC),
  CONSTRAINT `fk_Medicos_Usuarios1`
    FOREIGN KEY (`idUsuario`)
    REFERENCES `sistemahospital`.`usuarios` (`idUsuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sistemahospital`.`consultas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sistemahospital`.`consultas` (
  `idConsulta` INT(11) NOT NULL AUTO_INCREMENT,
  `idExpediente` INT(11) NOT NULL,
  `medico_dui` VARCHAR(10) NOT NULL,
  `fechaconsulta` DATE NOT NULL,
  `motivoconsulta` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`idConsulta`),
  INDEX `fk_consulta_expediente1_idx` (`idExpediente` ASC),
  INDEX `fk_consulta_medico1_idx` (`medico_dui` ASC),
  CONSTRAINT `fk_consulta_expediente1`
    FOREIGN KEY (`idExpediente`)
    REFERENCES `sistemahospital`.`expedientes` (`idExpediente`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_consulta_medico1`
    FOREIGN KEY (`medico_dui`)
    REFERENCES `sistemahospital`.`medicos` (`dui`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sistemahospital`.`enfermeras`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sistemahospital`.`enfermeras` (
  `dui` VARCHAR(10) NOT NULL,
  `nombres` VARCHAR(45) NOT NULL,
  `apellidos` VARCHAR(45) NOT NULL,
  `fechaNacimiento` DATE NOT NULL,
  PRIMARY KEY (`dui`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sistemahospital`.`examenes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sistemahospital`.`examenes` (
  `idExamen` INT(11) NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`idExamen`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sistemahospital`.`expediente_tiene_examenes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sistemahospital`.`expediente_tiene_examenes` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `idExpediente` INT(11) NOT NULL,
  `idExamen` INT(11) NOT NULL,
  `fecha` DATETIME NOT NULL,
  `resultados` VARCHAR(100) NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_expediente_has_examen_examen1_idx` (`idExamen` ASC),
  INDEX `fk_expediente_has_examen_expediente1_idx` (`idExpediente` ASC),
  CONSTRAINT `fk_expediente_has_examen_examen1`
    FOREIGN KEY (`idExamen`)
    REFERENCES `sistemahospital`.`examenes` (`idExamen`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_expediente_has_examen_expediente1`
    FOREIGN KEY (`idExpediente`)
    REFERENCES `sistemahospital`.`expedientes` (`idExpediente`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sistemahospital`.`tratamientos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sistemahospital`.`tratamientos` (
  `idTratamiento` INT(11) NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idTratamiento`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sistemahospital`.`expedientes_tiene_tratamientos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sistemahospital`.`expedientes_tiene_tratamientos` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `idExpediente` INT(11) NOT NULL,
  `idTratamiento` INT(11) NOT NULL,
  `fecha` DATETIME NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_expediente_has_tratamiento_tratamiento1_idx` (`idTratamiento` ASC),
  INDEX `fk_expediente_has_tratamiento_expediente1_idx` (`idExpediente` ASC),
  CONSTRAINT `fk_expediente_has_tratamiento_expediente1`
    FOREIGN KEY (`idExpediente`)
    REFERENCES `sistemahospital`.`expedientes` (`idExpediente`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_expediente_has_tratamiento_tratamiento1`
    FOREIGN KEY (`idTratamiento`)
    REFERENCES `sistemahospital`.`tratamientos` (`idTratamiento`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sistemahospital`.`recepcionistas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sistemahospital`.`recepcionistas` (
  `dui` VARCHAR(10) NOT NULL,
  `idUsuario` INT(11) NOT NULL,
  `nombres` VARCHAR(45) NOT NULL,
  `apellidos` VARCHAR(45) NOT NULL,
  `fechaNacimiento` DATE NOT NULL,
  PRIMARY KEY (`dui`),
  INDEX `fk_recepcionista_usuario1_idx` (`idUsuario` ASC),
  CONSTRAINT `fk_recepcionista_usuario1`
    FOREIGN KEY (`idUsuario`)
    REFERENCES `sistemahospital`.`usuarios` (`idUsuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sistemahospital`.`urgencias`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sistemahospital`.`urgencias` (
  `idUrgencia` INT(11) NOT NULL AUTO_INCREMENT,
  `idExpediente` INT(11) NOT NULL,
  `medico_dui` VARCHAR(10) NOT NULL,
  `enfermera_dui` VARCHAR(10) NOT NULL,
  `fechaEmergencia` DATETIME NOT NULL,
  PRIMARY KEY (`idUrgencia`),
  INDEX `fk_urgencia_expediente1_idx` (`idExpediente` ASC),
  INDEX `fk_urgencia_medico1_idx` (`medico_dui` ASC),
  INDEX `fk_urgencia_enfermera1_idx` (`enfermera_dui` ASC),
  CONSTRAINT `fk_urgencia_enfermera1`
    FOREIGN KEY (`enfermera_dui`)
    REFERENCES `sistemahospital`.`enfermeras` (`dui`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_urgencia_expediente1`
    FOREIGN KEY (`idExpediente`)
    REFERENCES `sistemahospital`.`expedientes` (`idExpediente`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_urgencia_medico1`
    FOREIGN KEY (`medico_dui`)
    REFERENCES `sistemahospital`.`medicos` (`dui`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sistemahospital`.`recepcionistas_registra_urgencias`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sistemahospital`.`recepcionistas_registra_urgencias` (
  `dui` VARCHAR(10) NOT NULL,
  `idUrgencia` INT(11) NOT NULL,
  `fecha` DATETIME NOT NULL,
  UNIQUE INDEX `idUrgencia_UNIQUE` (`idUrgencia` ASC),
  INDEX `fk_Recepcionistas_has_Urgencias_Urgencias1_idx` (`idUrgencia` ASC),
  INDEX `fk_Recepcionistas_has_Urgencias_Recepcionistas1_idx` (`dui` ASC),
  CONSTRAINT `fk_Recepcionistas_has_Urgencias_Recepcionistas1`
    FOREIGN KEY (`dui`)
    REFERENCES `sistemahospital`.`recepcionistas` (`dui`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Recepcionistas_has_Urgencias_Urgencias1`
    FOREIGN KEY (`idUrgencia`)
    REFERENCES `sistemahospital`.`urgencias` (`idUrgencia`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sistemahospital`.`reguserlogs`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sistemahospital`.`reguserlogs` (
  `idregUserLog` INT(11) NOT NULL AUTO_INCREMENT,
  `idUsuario` INT(11) NOT NULL,
  `loginDate` DATETIME NOT NULL,
  `logoutDate` DATETIME NOT NULL,
  PRIMARY KEY (`idregUserLog`),
  INDEX `fk_regUserLogs_Usuarios1_idx` (`idUsuario` ASC),
  CONSTRAINT `fk_regUserLogs_Usuarios1`
    FOREIGN KEY (`idUsuario`)
    REFERENCES `sistemahospital`.`usuarios` (`idUsuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 14
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sistemahospital`.`usuarios_registra_expedientes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sistemahospital`.`usuarios_registra_expedientes` (
  `idUsuario` INT(11) NOT NULL,
  `idExpediente` INT(11) NOT NULL,
  `fecha` DATETIME NOT NULL,
  INDEX `fk_usuario_has_expediente_expediente1_idx` (`idExpediente` ASC),
  INDEX `fk_usuario_has_expediente_usuario1_idx` (`idUsuario` ASC),
  CONSTRAINT `fk_usuario_has_expediente_expediente1`
    FOREIGN KEY (`idExpediente`)
    REFERENCES `sistemahospital`.`expedientes` (`idExpediente`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_usuario_has_expediente_usuario1`
    FOREIGN KEY (`idUsuario`)
    REFERENCES `sistemahospital`.`usuarios` (`idUsuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

USE `sistemahospital` ;

-- -----------------------------------------------------
-- function NUMRLOGS
-- -----------------------------------------------------

DELIMITER $$
USE `sistemahospital`$$
CREATE DEFINER=`root`@`localhost` FUNCTION `NUMRLOGS`() RETURNS int(11)
BEGIN
/* Esta funcion devuelve la cantidad de registros de  logueos que existen en la tabla reguserlogs*/
         declare num int;
     set num = (select count(1) from reguserlogs);
RETURN num;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure SPConsultas
-- -----------------------------------------------------

DELIMITER $$
USE `sistemahospital`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `SPConsultas`(sidConsulta int,sidExpediente int,smedico_dui varchar(10),sfechaconsulta DATETIME,smotivoconsulta varchar(100),tipoGestion int)
BEGIN
   if tipoGestion=1 then 
      begin /* no existe otro indice que no sea el id asi que no requiere un exists*/
        if exists(SELECT * from medicos Where dui=smedico_dui) and
            exists( SELECT * from expedientes where idExpediente=sidExpediente) then
             INSERT INTO `sistemaHospital`.`Consultas`(`sidExpediente`,`smedico_dui`,`sfechaconsulta`,`smotivoconsulta`)
              values (sidExpediente,smedico_dui,sfechaconsulta,smotivoconsulta);
			  SELECT 1 FROM DUAL;
       else  select -1 from dual;  
             end if;
         
	  end;
	  end if;
if tipoGestion=2 then
begin
   if exists (select * from Consultas where idConsulta=sidConsulta) then
     UPDATE `sistemaHospital`.`Consultas`
     SET
	 `idDiagnostico`=sidDiagnostico
     where idExpediente=sidExpediente;  
     SELECT 1 FROM DUAL; 
      ELSE  SELECT -1 FROM DUAL;
    end if;
end;
end if;
if tipoGestion=3 then
begin
 if exists (select * from Consultas where idConsulta=idConsulta)then
   delete  from Consultas where idConsulta=sidConsulta;
   select 1;
    else  select -1 from dual;
     end if;
end;
end if;
if tipoGestion=4 then
begin
    if exists(select * from Consultas where idConsulta=sidConsulta) then
       select * from Consultas where idConsulta=sidConsulta;
     else select -1 FROM DUAL; 
    end if;
end;
end if;

END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure SPDiagnosticos
-- -----------------------------------------------------

DELIMITER $$
USE `sistemahospital`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `SPDiagnosticos`(sidDiagnostico int, snombre varchar(20),stipo varchar(20),sfase varchar(20), tipoGestion int)
BEGIN
    if tipoGestion=1 then 
      begin 
        if not exists (select * from Diganosticos where nombre=snombre and fase=sfase and tipo=stipo) then
             INSERT INTO `sistemaHospital`.`Diagnosticos`(`nombre`,`tipo`,`fase`)
              values (snombre,stipo,sfase);
			  SELECT 1 FROM DUAL;
          else  select -1 from dual; 
		end if;
	  end;
	  end if;  


    if tipoGestion=2 then
     begin
         if exists (select * from Diagnosticos where idDiagnostico=sidDiagnostico) then
     UPDATE `sistemaHospital`.`Diagnosticos`
     SET
	  `nombre` = snombre,
       `tipo`=stipo,
       `fase`=sfase
     where idDiagnostico=sidDiagnostico;  
     SELECT 1  FROM DUAL; 
      ELSE  SELECT -1 FROM DUAL;
    end if; 
     end;
     end if;

if tipoGestion=3 then
begin
 if exists (select * from Diagnosticos where idDiagnostico=sidDiagnostico) 
 AND not exists (select * from Diagnosticos, Expedientes
				  where  Diagnosticos.idDiagnostico=Expedientes.idDiagnostico)   then
   delete  from Diagnosticos where idDiagnostico=sidDiagnostico;
   select 1 from dual;
    else  select -1 from dual;
     end if;
end;
end if;
if tipoGestion=4 then
begin
    if exists(select * from Diagnosticos where idDiagnostico=sidDiagnostico) then
      select * from Diagnosticos where idDiagnostico=sidDiagnostico;
     else select -1 FROM DUAL; 
    end if;
end;
end if;

END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure SPEnfermeras
-- -----------------------------------------------------

DELIMITER $$
USE `sistemahospital`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `SPEnfermeras`( sdui varchar(10),snombres varchar(45),sapellidos varchar(45),sFechaNacimiento DATE, tipoGestion int)
BEGIN
/*tipoGestion:
1. insert
2. actualiza
3.elimina
4.consulta*/

if tipoGestion=1 then 
      begin 
        if not exists (select * from Enfermeras where dui=sdui) then
             INSERT INTO `sistemaHospital`.`Enfermeras`(`dui`,`nombres`,`apellidos`,`fechaNacimiento`)
              values (sdui,snombres,sapellidos,sfechaNacimiento);
			  SELECT 1 FROM DUAL;
          else  select -1; 
		end if;
	  end;
	  end if;
if tipoGestion=2 then
begin
   if exists (select * from Enfermeras where dui=sdui) then
     UPDATE `sistemaHospital`.`Enfermeras`
     SET
	  `nombres` = snombres,
      `apellidos` = sapellidos
     where dui=sdui;  
     SELECT 1 FROM DUAL; 
      ELSE  SELECT -1 FROM DUAL;
    end if;
end;
end if;

if tipoGestion=3 then
begin
 if exists (select * from Enfermeras where dui=sdui) 
 AND not exists (select * from Enfermeras, Urgencias
                       where  Enfermeras.dui=Urgencias.enfermera_dui)   then
   delete  from Enfermeras where dui=sdui;
   select 1  from dual;
    else  select -1 from dual;
     end if;
end;
if tipoGestion=4 then
begin
    if exists(select * from Enfermeras where dui=sdui) then
       select * from  Enfermeras where dui=sdui;
     else select -1 FROM DUAL; 
    end if;
end;
end if;

end if;


END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure SPExamenes
-- -----------------------------------------------------

DELIMITER $$
USE `sistemahospital`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `SPExamenes`()
BEGIN
  /*tipoGestion:
1. insert
2. actualiza
3.elimina
4.consulta*/

if tipoGestion=1 then 
      begin 
        if not exists (select * from Examenes where nombre=snombre) then
             INSERT INTO `sistemaHospital`.`Examenes`(`nombre`)
              values (snombre);
			  SELECT 1 FROM DUAL;
          else  select -1; 
		end if;
	  end;
	  end if;   
    if tipoGestion=2 then
begin
   if exists (select * from Examenes where idExamen=sidExamen) then
     UPDATE `sistemaHospital`.`Examenes`
     SET
	  `nombre` = snombre
     where idExamen=sidExamen;  
     SELECT 1 FROM DUAL; 
      ELSE  SELECT -1 FROM DUAL;
    end if;
end;
end if;
if tipoGestion=3 then
begin
 if exists (select * from Examenes where idExamen=sidExamen) 
 AND not exists (select * from Examenes, Expediente_tiene_Examenes
                       where  Examenes.idExamen=Expediente_tiene_Examenes.idExamen)   then
   delete  from Examenes where idExamen=sidExamen;
   select 1 from dual;
    else  select -1 from dual;
     end if;
end;
end if;
if tipoGestion=4 then
begin
    if exists(select * from Examenes where idExamen=sidExamen) then
      select * from Examenes where idExamen=sidExamen;
     else select -1 FROM DUAL; 
    end if;
end;
end if;


END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure SPExpedienteExamen
-- -----------------------------------------------------

DELIMITER $$
USE `sistemahospital`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `SPExpedienteExamen`(sid int,sidExpediente int,sidExamen int ,sfecha DATETIME, sresultados varchar(100))
BEGIN
 if tipoGestion=1 then 
      begin 
        if exists (select * from Expedientes where idExpediente=sidExpediente) and
              exists (select * from Examenes where idExamen=sidExamen)  then
             INSERT INTO `sistemahospital`.`expediente_tiene_examenes`
                       (`idExpediente`,`idExamen`,`fecha`,`resultados`)
              VALUES   (sidExpediente,sidExamen,sfecha,sresultados);
			  SELECT 1 FROM DUAL;
          else  select -1 from dual; 
		end if;
	  end;
	end if;  
 /* if tipoGestion=2 then
   begin
   if exists (select * from expediente_tiene_examenes where id=sid) then
     UPDATE `sistemaHospital`.`Expedientes`
     SET
	 `idDiagnostico`=sidDiagnostico
     where idExpediente=sidExpediente;  
     SELECT 1 FROM DUAL; 
      ELSE  SELECT -1 FROM DUAL;
    end if;
  end;   la  actualizacion para este tipo de datos no la encuentro necesaria
 end if;*/

if tipoGestion=3 then
begin
   DELETE FROM `sistemahospital`.`expediente_tiene_examenes`
WHERE id=sid;
select 1 from dual;
end;
end if;

if tipoGestion=4 then 
begin 
if exists(select * from `sistemahospital`.`expediente_tiene_examenes` where id=sid) then
    select * from `sistemahospital`.`expediente_tiene_examenes` where id=sid;
   else  select -1 from dual;
  end if;
end;
end if;



END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure SPExpedientes
-- -----------------------------------------------------

DELIMITER $$
USE `sistemahospital`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `SPExpedientes`(sidExpediente int,sdui varchar(10),sidDiagnostico int , tipoGestion int)
BEGIN
if tipoGestion=1 then 
      begin 
        if not exists (select * from Expedientes where dui=sdui) then
             INSERT INTO `sistemaHospital`.`Expedientes`(`dui`,`idDiagnostico`)
              values (sdui,sidDiagnostico);
			  SELECT 1 FROM DUAL;
          else  select -1 from dual; 
		end if;
	  end;
	  end if; 
if tipoGestion=2 then
begin
   if exists (select * from Expedientes where idExpediente=sidExpediente) then
     UPDATE `sistemaHospital`.`Expedientes`
     SET
	 `idDiagnostico`=sidDiagnostico
     where idExpediente=sidExpediente;  
     SELECT 1 FROM DUAL; 
      ELSE  SELECT -1 FROM DUAL;
    end if;
end;
end if;
if tipoGestion=3 then
begin
 if exists (select * from Expedientes where idExpediente=sidExpediente)
   AND not exists (select * from Expedientes, Consultas
                       where  Expedientes.idExpediente=Consultas.idExpediente)  
AND not exists (select * from Expedientes, Urgencias
                       where  Expedientes.idExpediente=Urgencias.idExpediente)
AND not exists (select * from Expedientes, Expediente_tiene_Examenes
                       where  Expedientes.idExpediente=Expediente_tiene_Examenes.idExpediente)
AND not exists (select * from Expedientes, Expedientes_tiene_Tratamientos
                       where  Expedientes.idExpediente=Expedientes_tiene_Tratamientos.idExpediente)
AND not exists (select * from Expedientes, Usuarios_registra_Expedientes
                       where  Expedientes.idExpediente=Usuarios_registra_Expedientes.idExpediente)then
   delete  from Expedientes where idExpediente=sidExpediente;
   select 1 from dual;
    else  select -1 from dual;
     end if;
end;
end if;
if tipoGestion=4 then
begin
    if exists(select * from Expedientes where idExpediente=sidExpediente) then
       select * from  Expedientes where idExpediente=sidExpediente;
     else select -1 FROM DUAL; 
    end if;
end;
end if;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure SPMedicos
-- -----------------------------------------------------

DELIMITER $$
USE `sistemahospital`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `SPMedicos`(sdui varchar(10),sidUsuario int,snombres varchar(45),sapellidos varchar(45),sfechaNacimiento DATE,ssexo varchar(10),sjvmp varchar(4),tipoGestion int)
BEGIN
/*tipoGestion:
1. insert
2. actualiza
3.elimina
4.consulta*/

if tipoGestion=1 then 
      begin 
        if not exists (select * from Medicos where dui=sdui) then
             INSERT INTO `sistemaHospital`.`Medicos`(`dui`,`idUsuario`,`nombres`,`apellidos`,`fechaNacimiento`,`sexo`,`jvmp`)
              values (sdui,sidusuario,snombres,sapellidos,sfechaNacimiento,ssexo,sjvmp);
			  SELECT 1 FROM DUAL;
          else  select -1; 
		end if;
	  end;
	  end if;
if tipoGestion=2 then
begin
   if exists (select * from Medicos where dui=sdui) then
     UPDATE `sistemaHospital`.`Medicos`
     SET
	  `nombres` = snombres,
      `apellidos` = sapellidos,
      `jvmp` = sjvmp
     where dui=sdui;  
     SELECT 1 FROM DUAL; 
      ELSE  SELECT -1 FROM DUAL;
    end if;
end;
end if;

if tipoGestion=3 then
begin
 if exists (select * from Medicos where dui=sdui)
   AND not exists (select * from Medicos, Urgencias
                       where  Medicos.dui=Urgencias.medico_dui)  
   AND not exists (select * from Medicos, Consultas
                       where  Medicos.dui=Consultas.medico_dui )then
   delete  from Medicos where dui=sdui;
   select 1 from dual;
    else  select -1 from dual;
     end if;
end;
end if;

if tipoGestion=4 then
begin
    if exists(select * from Medicos where dui=sdui) then
       select * from  Medicos where dui=sdui;
     else select -1 FROM DUAL; 
    end if;
end;
end if;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure SPPacientes
-- -----------------------------------------------------

DELIMITER $$
USE `sistemahospital`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `SPPacientes`(sdui varchar(10),snombres varchar(45),sapellidos varchar(45),
sfechaNacimiento DATE,sseguroMedico varchar(45),ssexo  varchar(10), sdireccion varchar(45),stelefono varchar(15),sestado varchar(10))
BEGIN
     /* tipoGestion
	    1 inserta
		2 actualiza
		3 elimina
	    4 consulta*/ 

if tipoGestion=1 then 
      begin 
        if not exists (select * from Pacientes where dui=sdui) then
             INSERT INTO `sistemahospital`.`pacientes`(`dui`,`nombres`,`apellidos`,`fechaNacimiento`,
                          `seguroMedico`,`sexo`,`direccion`,`telefono`,`estado`)
			 VALUES(sdui,snombres,sapellidos,sfechaNacimiento,sseguroMedico,
                    ssexo,sdireccion,stelefono,sestado);
			  SELECT 1 FROM DUAL;
          else  select -1; 
		end if;
	  end;
	  end if;

if tipoGestion=2 then
begin
   if exists (select * from Pacientes where dui=sdui) then
     UPDATE `sistemaHospital`.`Pacientes`
     SET
     `nombres` = snombres,
     `apellidos` = sapellidos,
      `seguroMedico` = sseguroMedico,
       `direccion` = sdireccion,
      `telefono` = stelefono,
      `estado` = sestado
     where dui=sdui;  
     SELECT 1 FROM DUAL; 
      ELSE  SELECT -1 FROM DUAL;
    end if;
end;
end if;

if tipoGestion=3 then
begin
 if exists (select * from Pacientes where dui=sdui)
   AND not exists (select * from Pacientes, Expedientes
                       where  Pacientes.dui=Expedientes.dui)  then
   delete  from Pacientes where dui=sdui;
   select 1 from dual;
    else  select -1 from dual;
     end if;
end;
end if;

if tipoGestion=4 then
begin
    if exists(select * from Pacientes where dui=sdui) then
       select * from  Pacientes where dui=sdui;
     else select -1 FROM DUAL; 
    end if;
end;
end if;


END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure SPRecepcionistas
-- -----------------------------------------------------

DELIMITER $$
USE `sistemahospital`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `SPRecepcionistas`(sdui varchar(10),snombres varchar(45),sapellidos varchar(45))
BEGIN
/*
*/

/*tipoGestion:
1. insert
2. actualiza
3.elimina
4.consulta*/

if tipoGestion=1 then 
      begin 
        if not exists (select * from Recepcionistas where dui=sdui) then
             INSERT INTO `sistemaHospital`.`Recepcionistas`(`dui`,`idUsuario`,`nombres`,`apellidos`)
              values (sdui,sidusuario,snombres,sapellidos);
			  SELECT 1 FROM DUAL;
          else  select -1 from dual; 
		end if;
	  end;
	  end if;
if tipoGestion=2 then
begin
   if exists (select * from Recepcionistas where dui=sdui) then
     UPDATE `sistemaHospital`.`Recepcionistas`
     SET
	  `nombres` = snombres,
      `apellidos` = sapellidos
     where dui=sdui;  
     SELECT 1 FROM DUAL; 
      ELSE  SELECT -1 FROM DUAL;
    end if;
end;
end if;
if tipoGestion=3 then
begin
 if exists (select * from Recepcionistas where dui=sdui)
   AND not exists (select * from Recepcionistas, Recepcionistas_registra_Urgencias
                       where  Recepcionistas.dui=Recepcionistas_registra_Urgencias.dui) then
   delete  from Recepcionistas where dui=sdui;
   select 1 from dual;
    else  select -1 from dual;
     end if;
end;
end if;
if tipoGestion=4 then
begin
    if exists(select * from Recepcionistas where dui=sdui) then
       select * from  Recepcionistas where dui=sdui;
     else select -1 FROM DUAL; 
    end if;
end;
end if;

END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure SPRegUserLogs
-- -----------------------------------------------------

DELIMITER $$
USE `sistemahospital`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `SPRegUserLogs`(sidUsuario int,opc int)
BEGIN

/*
    opc=1  agregar registro de  inicio de sesion
	opc=2  agregar registro de  cierre de sesion
*/

  DECLARE NUMREGS INT;

 if opc=1  then
   begin
     if exists(select * from `sistemahospital`.Usuarios where idUsuario=sidUsuario)then 
      begin
         INSERT INTO `sistemahospital`.`reguserlogs`
             (`idUsuario`,`loginDate`)
		 VALUES(sidUsuario,current_timestamp());
         select 1 from dual;
      end;
     else 
         select -1 from dual;
      end if;
   end;
end if;

   if opc=2 then 
     begin
     if exists(select * from `sistemahospital`.Usuarios) then 
     begin 
          SET  NUMREGS=NUMRLOGS();
          UPDATE `sistemahospital`.`reguserlogs`
           SET`logoutDate` = current_timestamp()
      /* le agregamos la fecha de cierre de sesion  al ultimo registro*/
          WHERE `idregUserLog` = NUMREGS ; 
          select 1  from dual;
     end;
    else select -1 from dual;
     end if;
end;
end if;
       
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure SPTratamientos
-- -----------------------------------------------------

DELIMITER $$
USE `sistemahospital`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `SPTratamientos`(sidTratamiento int ,snombre varchar(45),tipoGestion int)
BEGIN
   /*tipoGestion:
1. insert
2. actualiza
3.elimina
4.consulta*/

if tipoGestion=1 then 
      begin 
        if not exists (select * from Tratamientos where nombre=snombre) then
             INSERT INTO `sistemaHospital`.`Tratamientos`(`nombre`)
              values (snombre);
			  SELECT 1 FROM DUAL;
          else  select -1 from dual; 
		end if;
	  end;
	  end if;   
    if tipoGestion=2 then
begin
   if exists (select * from Tratamientos where idTratamiento=sidTratamiento) then
     UPDATE `sistemaHospital`.`Tratamientos`
     SET
	  `nombre` = snombre
     where idTratamiento=sidTratamiento;  
     SELECT 1  FROM DUAL; 
      ELSE  SELECT -1 FROM DUAL;
    end if;
end;
end if;
if tipoGestion=3 then
begin
 if exists (select * from Tratamientos where idTratamiento=sidTratamiento) 
 AND not exists (select * from Tratamientos, Expedientes_tiene_Tratamientos
                       where  Tratamientos.idTratamiento=Expedientes_tiene_Tratamientos.idTratamiento)   then
   delete  from Tratamientos where idTratamiento=sidTratamiento;
   select 1 from dual;
    else  select -1 from dual;
     end if;
end;
end if;
if tipoGestion=4 then
begin
    if exists(select * from Tratamientos where idTratamiento=sidTratamiento) then
      select * from Tratamientos where idTratamiento=sidTratamiento;
     else select -1 FROM DUAL; 
    end if;
end;
end if;


END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure SPUrgencias
-- -----------------------------------------------------

DELIMITER $$
USE `sistemahospital`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `SPUrgencias`(sidUrgencia int,sidExpediente int,smedico_dui varchar(10),senfermera_dui varchar(10),sfechaEmergencia DATETIME,tipoGestion int)
BEGIN
    if tipoGestion=1 then 
      begin 
        if not exists (select * from Urgencias where idUrgencia=sidUrgencia) then
             INSERT INTO `sistemaHospital`.`Urgencias`(`idExpediente`,`medico_dui`,`enfermera_dui`,`fechaEmergencia`)
              values (sidExpediente ,smedico_dui,senfermera_dui,sfechaEmergencia);
			  SELECT 1 FROM DUAL;
          else  select -1; 
		end if;
	  end;
	  end if;   

if tipoGestion=2 then
begin
   if exists (select * from Urgencias where idUrgencia=sidUrgencia) then
     UPDATE `sistemaHospital`.`Urgencias`
     SET
	 `idUrgencia`=sidUrgencia
     where idUrgencia=sidUrgencia;  
     SELECT 1 FROM DUAL; 
      ELSE  SELECT -1 FROM DUAL;
    end if;
end;
end if;
if tipoGestion=3 then
begin
 if exists (select * from Urgencias where dui=sdui) then
   delete  from Urgencias where idUrgencia=sidUrgencia;
   select 1 from dual;
    else  select -1 from dual;
     end if;
end;
if tipoGestion=4 then
begin
    if exists(select * from Urgencias where idUrgencia=sidUrgencia) then
       select * from Urgencias where idUrgencia=sidUrgencia;
     else select -1 FROM DUAL; 
    end if;
end;
end if;

end if;





END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure SPUsuarios
-- -----------------------------------------------------

DELIMITER $$
USE `sistemahospital`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `SPUsuarios`(sidUsuario int,suserName varchar(10),spass varchar(25),stipo varchar(10),sestado varchar(4),tipoGestion int)
BEGIN
/*tipoGestion:
   1. insercion
   2. actualizacion
   3.eliminacion
   4. consulta
	valor de retorno
    0 : exito
   -1 : error
*/
  if tipoGestion=1  then
    begin
        if not exists (select * from  `sistemaHospital`.`Usuarios` where userName=suserName) then
           
        INSERT INTO `sistemaHospital`.`Usuarios`(`userName`,`pass`,`tipo`,`estado`)
            VALUES (suserName,spass,stipo,sestado);
           select 1 from dual;
         else  select -1 FROM DUAL;
          
	    end if;

     end;
   end if;

if tipoGestion=2 then
 begin
       if exists(select * from `sistemaHospital`.`Usuarios`
                 where idUsuario=sidUsuario) then
		UPDATE `sistemaHospital`.`Usuarios`
		SET `userName` =suserName , `pass` =spass,`estado`=sestado
         where idUsuario=sidUsuario;
	     select "ACTUALIZACION DEL REGISTRO CON EXITO" FROM DUAL;
             else select -1;
         end if;
  end ;
end if;

if tipoGestion=3 then
 begin
       if exists(select * from `sistemaHospital`.`Usuarios`
                 where userName=suserName)
	   AND not exists (select * from Usuarios , Medicos 
                       where  Usuarios.idUsuario=Medicos.idUsuario) 
	   AND not exists (select * from Usuarios , Recepcionistas
                       where  Usuarios.idUsuario=Recepcionistas.idUsuario) 
	   AND not exists (select * from Usuarios_registra_Expedientes,Usuarios 
                       where  Usuarios.idUsuario=Usuarios_registra_Expedientes.idUsuario)
	   AND not exists (select * from Usuarios,regUserLogs 
                       where  Usuarios.idUsuario=regUserLogs.idUsuario) then
		      delete from `sistemaHospital`.`Usuarios` where userName=suserName;
               select  1  from dual;
            else select -1 from dual;
         end if;
  end;
end if;

if tipoGestion=4 then
 begin
       if exists(select * from `sistemaHospital`.`Usuarios`
                 where userName=suserName and pass=spass) then
		   select * from `sistemaHospital`.`Usuarios` where userName= suserName and pass=spass;
          else  select -1 from dual;
         end if;
  end;
end if;
END$$

DELIMITER ;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
USE `sistemahospital`;

DELIMITER $$
USE `sistemahospital`$$
CREATE
DEFINER=`root`@`localhost`
TRIGGER `sistemahospital`.`registro_expedientes`
AFTER INSERT ON `sistemahospital`.`expedientes`
FOR EACH ROW
begin
/* este trigger  registra el expediente creado y al usuario que lo realizo*/
declare idu int;
set idu= (select idUsuario from reguserlogs where idregUserLog=NUMRLOGS());
INSERT INTO `sistemahospital`.`usuarios_registra_expedientes`
(`idUsuario`,
`idExpediente`,
`fecha`)
VALUES
(idu,
new.idExpediente,
current_timestamp());

end$$


DELIMITER ;
