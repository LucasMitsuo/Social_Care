use Social_Care;

-- =================== CRIANDO UM FORMULÁRIO PARA UM PACIENTE

-- CRIA UM FORMULÁRIO
INSERT INTO TAB_FORM (cod_paciente) VALUES (1);

-- CE DO PACIENTE
UPDATE TAB_PACIENTE SET num_grau_ce = 3 WHERE cod_paciente = 1;

-- VINCULA OS MATERIAIS
INSERT INTO TAB_FORM_MAT (cod_form,cod_material)
VALUES(1,2);
INSERT INTO TAB_FORM_MAT (cod_form,cod_material)
VALUES(1,4);
INSERT INTO TAB_FORM_MAT (cod_form,cod_material)
VALUES(1,6);
INSERT INTO TAB_FORM_MAT (cod_form,cod_material)
VALUES(1,8);
INSERT INTO TAB_FORM_MAT (cod_form,cod_material)
VALUES(1,10);

-- VINCULA OS PROCEDIMENTOS_ENFERMEIRA
INSERT INTO TAB_FORM_PROC_ENF (cod_form,cod_proc_enf)
VALUES(1,2);
INSERT INTO TAB_FORM_PROC_ENF (cod_form,cod_proc_enf)
VALUES(1,4);
INSERT INTO TAB_FORM_PROC_ENF (cod_form,cod_proc_enf)
VALUES(1,6);

-- VINCULA OS CID´s 10
INSERT INTO TAB_DIAGNOSTICO (cod_form,cod_cid)
VALUES(1,56);
INSERT INTO TAB_DIAGNOSTICO (cod_form,cod_cid)
VALUES(1,98);
INSERT INTO TAB_DIAGNOSTICO (cod_form,cod_cid)
VALUES(1,1005);

-- INSERE O UP
INSERT INTO TAB_UP (cod_paciente, des_momento, des_estagio,dat_up)
VALUES(1,'PRÉ','Estágio V',CONVERT(DATETIME,'31/07/2015',103));
