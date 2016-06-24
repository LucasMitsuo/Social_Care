use Social_Care;

--DELETE FROM TAB_PROFISSIONAL;
--DBCC CHECKIDENT ('TAB_PROFISSIONAL', RESEED, 0)

-- ======================================= PROFISSIONAL
INSERT INTO TAB_PROFISSIONAL (nom_profissional,des_login,des_senha,des_cargo) 
VALUES ('Maria Madalena','madalena','123456','Enfermeira');

INSERT INTO TAB_PROFISSIONAL (nom_profissional,des_login,des_senha,des_cargo) 
VALUES ('Sérgio Roberto','sergio','123456','Fisioterapeuta');

INSERT INTO TAB_PROFISSIONAL (nom_profissional,des_login,des_senha,des_cargo) 
VALUES ('Carlos Alberto','carlos','123456','Médico');

select * from TAB_PROFISSIONAL;

-- ======================================== PACIENTES
--DELETE FROM TAB_PACIENTE;
--DBCC CHECKIDENT ('TAB_PACIENTE', RESEED, 0)

INSERT INTO TAB_PACIENTE (nom_paciente,dat_nasc,tel_paciente,des_sexo,des_end,num_end,Nom_cuidador,des_parentesco)
VALUES ('Ubiranir Gonçalves Bezerra',CONVERT(DATETIME,'30/12/2013',103),'4367-8765','M','Rua das Pedrosas',123,'Marieta Betânia','Mãe');

INSERT INTO TAB_PACIENTE (nom_paciente,dat_nasc,tel_paciente,des_sexo,des_end,num_end,Nom_cuidador,des_parentesco)
VALUES ('Joice Gomes Judith',CONVERT(DATETIME,'31/07/2014',103),'3892-3233','F','Rua das Ameixeiras',41,'Hugo Longuini','Tio');

INSERT INTO TAB_PACIENTE (nom_paciente,dat_nasc,tel_paciente,des_sexo,des_end,num_end,Nom_cuidador,des_parentesco)
VALUES ('Mario Ricardo',CONVERT(DATETIME,'09/09/2011',103),'3133-4782','M','Avenida Atlantida',4131,'Lurdes Oliveira','Tia');

INSERT INTO TAB_PACIENTE (nom_paciente,dat_nasc,tel_paciente,des_sexo,des_end,num_end,Nom_cuidador,des_parentesco)
VALUES ('Ana Clara Gema',CONVERT(DATETIME,'01/02/1997',103),'2881-2781','F','Rua Ricardo Buffet',123,'Lima Duarte','Pai');

INSERT INTO TAB_PACIENTE (nom_paciente,dat_nasc,tel_paciente,des_sexo,des_end,num_end,Nom_cuidador,des_parentesco)
VALUES ('Roseanne Rejanne',CONVERT(DATETIME,'01/10/1998',103),'8972-2673','F','Rua Marechal Sampaio',287,'José Felipe','Pai');

SELECT * FROM TAB_PACIENTE;

-- ================================== VISITAS

--DELETE FROM TAB_VISITA;
--DBCC CHECKIDENT ('TAB_VISITA', RESEED, 0)

INSERT INTO TAB_VISITA (cod_paciente,cod_profissional,dat_visita,des_status,des_periodicidade)
VALUES (1,1,CONVERT(DATETIME,'10/06/2016',103),'2','Mensal');

INSERT INTO TAB_VISITA (cod_paciente,cod_profissional,dat_visita,des_status,des_periodicidade)
VALUES (1,2,CONVERT(DATETIME,'10/06/2016',103),'2','Semanal');

INSERT INTO TAB_VISITA (cod_paciente,cod_profissional,dat_visita,des_status,des_periodicidade)
VALUES (2,1,CONVERT(DATETIME,'12/06/2016',103),'2','Mensal');

INSERT INTO TAB_VISITA (cod_paciente,cod_profissional,dat_visita,des_status,des_periodicidade)
VALUES (2,2,CONVERT(DATETIME,'12/06/2016',103),'2','Semanal');

INSERT INTO TAB_VISITA (cod_paciente,cod_profissional,dat_visita,des_status,des_periodicidade)
VALUES (3,1,CONVERT(DATETIME,'15/06/2016',103),'2','Mensal');

INSERT INTO TAB_VISITA (cod_paciente,cod_profissional,dat_visita,des_status,des_periodicidade)
VALUES (3,2,CONVERT(DATETIME,'15/06/2016',103),'2','Semanal');

INSERT INTO TAB_VISITA (cod_paciente,cod_profissional,dat_visita,des_status,des_periodicidade)
VALUES (4,1,CONVERT(DATETIME,'16/06/2016',103),'2','Mensal');

INSERT INTO TAB_VISITA (cod_paciente,cod_profissional,dat_visita,des_status,des_periodicidade)
VALUES (4,3,CONVERT(DATETIME,'16/06/2016',103),'2','Semanal');

INSERT INTO TAB_VISITA (cod_paciente,cod_profissional,dat_visita,des_status,des_periodicidade)
VALUES (5,1,CONVERT(DATETIME,'20/06/2016',103),'2','Mensal');

INSERT INTO TAB_VISITA (cod_paciente,cod_profissional,dat_visita,des_status,des_periodicidade)
VALUES (5,3,CONVERT(DATETIME,'20/06/2016',103),'2','Mensal');

SELECT cod_visita, cod_paciente,cod_profissional, dat_visita, des_status,des_obs  FROM TAB_VISITA;

-- ============================ INSERÇÃO DE PROCEDIMENTO ENFERMEIRA PARA A VISITA 1
INSERT INTO TAB_VISITA_PROC (cod_visita,cod_procedimento)
VALUES(1,8)
INSERT INTO TAB_VISITA_PROC (cod_visita,cod_procedimento)
VALUES(1,9)