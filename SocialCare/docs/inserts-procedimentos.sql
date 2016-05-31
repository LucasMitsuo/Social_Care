use Social_Care;

select * from TAB_PROCEDIMENTO;

INSERT INTO TAB_PROCEDIMENTO VALUES ('C1','AGE','Curativos');
INSERT INTO TAB_PROCEDIMENTO VALUES ('C2','Desbridamento','Curativos');
INSERT INTO TAB_PROCEDIMENTO VALUES ('C3','Hidrocolóide','Curativos');
INSERT INTO TAB_PROCEDIMENTO VALUES ('C4','Papaína','Curativos');
INSERT INTO TAB_PROCEDIMENTO VALUES ('C5','Prata','Curativos');
INSERT INTO TAB_PROCEDIMENTO VALUES ('C6','SF09%','Curativos');
INSERT INTO TAB_PROCEDIMENTO VALUES ('C7','SF20%','Curativos');
INSERT INTO TAB_PROCEDIMENTO VALUES ('C0','Outros curativos','Curativos');

INSERT INTO TAB_PROCEDIMENTO VALUES ('T1','Colostomia','Troca de sondas/Ostomias');
INSERT INTO TAB_PROCEDIMENTO VALUES ('T2','Gastro','Troca de sondas/Ostomias');
INSERT INTO TAB_PROCEDIMENTO VALUES ('T3','SNE','Troca de sondas/Ostomias');
INSERT INTO TAB_PROCEDIMENTO VALUES ('T4','SNG','Troca de sondas/Ostomias');
INSERT INTO TAB_PROCEDIMENTO VALUES ('T5','SVA','Troca de sondas/Ostomias');
INSERT INTO TAB_PROCEDIMENTO VALUES ('T6','SVD','Troca de sondas/Ostomias');
INSERT INTO TAB_PROCEDIMENTO VALUES ('T7','Traqueo','Troca de sondas/Ostomias');
INSERT INTO TAB_PROCEDIMENTO VALUES ('T0','Outras trocas','Troca de sondas/Ostomias');

INSERT INTO TAB_PROCEDIMENTO VALUES ('R1','Gastro','Retirada de sondas/Ostomias');
INSERT INTO TAB_PROCEDIMENTO VALUES ('R2','SN3','Retirada de sondas/Ostomias');
INSERT INTO TAB_PROCEDIMENTO VALUES ('R3','SNG','Retirada de sondas/Ostomias');
INSERT INTO TAB_PROCEDIMENTO VALUES ('R4','SVD','Retirada de sondas/Ostomias');
INSERT INTO TAB_PROCEDIMENTO VALUES ('R5','Traqueo','Retirada de sondas/Ostomias');
INSERT INTO TAB_PROCEDIMENTO VALUES ('R0','Outras retiradas','Retirada de sondas/Ostomias');

INSERT INTO TAB_PROCEDIMENTO VALUES ('M1','EV','Medicação');
INSERT INTO TAB_PROCEDIMENTO VALUES ('M2','Hipodermóclise','Medicação');
INSERT INTO TAB_PROCEDIMENTO VALUES ('M3','IM','Medicação');
INSERT INTO TAB_PROCEDIMENTO VALUES ('M4','Inalação','Medicação');
INSERT INTO TAB_PROCEDIMENTO VALUES ('M5','SC','Medicação');
INSERT INTO TAB_PROCEDIMENTO VALUES ('M6','VO','Medicação');
INSERT INTO TAB_PROCEDIMENTO VALUES ('M0','Outras medicações','Medicação');

INSERT INTO TAB_PROCEDIMENTO VALUES ('H1','Corporal','Higiene');
INSERT INTO TAB_PROCEDIMENTO VALUES ('H2','Íntima','Higiene');
INSERT INTO TAB_PROCEDIMENTO VALUES ('H3','Nasal','Higiene');
INSERT INTO TAB_PROCEDIMENTO VALUES ('H4','Ocular','Higiene');
INSERT INTO TAB_PROCEDIMENTO VALUES ('H5','Oral','Higiene');
INSERT INTO TAB_PROCEDIMENTO VALUES ('H6','T Fralda','Higiene');
INSERT INTO TAB_PROCEDIMENTO VALUES ('H0','Outras higienes','Higiene');

INSERT INTO TAB_PROCEDIMENTO VALUES ('O1','Higiene corporal e conforto','Orientação');
INSERT INTO TAB_PROCEDIMENTO VALUES ('O2','Adaptação e preparo de domicílio','Orientação');
INSERT INTO TAB_PROCEDIMENTO VALUES ('O3','Alimentação e hidratação','Orientação');
INSERT INTO TAB_PROCEDIMENTO VALUES ('O4','Uso correto de medicação','Orientação');
INSERT INTO TAB_PROCEDIMENTO VALUES ('O5','Processo saúde-doença','Orientação');
INSERT INTO TAB_PROCEDIMENTO VALUES ('O6','Risco e prevenção de quedas','Orientação');
INSERT INTO TAB_PROCEDIMENTO VALUES ('O7','Risco e prevenção de úlceras por pressão','Orientação');
INSERT INTO TAB_PROCEDIMENTO VALUES ('O8','Curativos','Orientação');
INSERT INTO TAB_PROCEDIMENTO VALUES ('O9','Cuidados com sondas e estomias','Orientação');
INSERT INTO TAB_PROCEDIMENTO VALUES ('O10','Atividade de lazer','Orientação');
INSERT INTO TAB_PROCEDIMENTO VALUES ('O11','Movimentação e transporte','Orientação');
INSERT INTO TAB_PROCEDIMENTO VALUES ('O12','Limpeza dos equipamentos, utensílios e domicílio','Orientação');
INSERT INTO TAB_PROCEDIMENTO VALUES ('O13','Terminalidade e trâmites de óbito','Orientação');
INSERT INTO TAB_PROCEDIMENTO VALUES ('O14','Apoio à família e cuidador','Orientação');
INSERT INTO TAB_PROCEDIMENTO VALUES ('O15','Outros','Orientação');

INSERT INTO TAB_PROCEDIMENTO VALUES ('S1','Colocação uripen','S_grupo');
INSERT INTO TAB_PROCEDIMENTO VALUES ('S2','Enteroclisma','S_grupo');
INSERT INTO TAB_PROCEDIMENTO VALUES ('S3','Glicemia capilar','S_grupo');
INSERT INTO TAB_PROCEDIMENTO VALUES ('S4','Preparo do corpo','S_grupo');
INSERT INTO TAB_PROCEDIMENTO VALUES ('S5','Remoção fecaloma','S_grupo');
INSERT INTO TAB_PROCEDIMENTO VALUES ('S6','Retirada de pontos','S_grupo');
INSERT INTO TAB_PROCEDIMENTO VALUES ('S7','Toque retal','S_grupo');
INSERT INTO TAB_PROCEDIMENTO VALUES ('S0','Outros s_grupo','S_grupo');

INSERT INTO TAB_PROCEDIMENTO VALUES ('FMN1','Neurológica passiva','Fisio Motora');
INSERT INTO TAB_PROCEDIMENTO VALUES ('FMN2','Neuro ativa assistida','Fisio Motora');
INSERT INTO TAB_PROCEDIMENTO VALUES ('FMN3','Neuro ativa livre','Fisio Motora');
INSERT INTO TAB_PROCEDIMENTO VALUES ('FMN4','Neuro ativa resistida','Fisio Motora');
INSERT INTO TAB_PROCEDIMENTO VALUES ('FMO1','Orto passiva','Fisio Motora');
INSERT INTO TAB_PROCEDIMENTO VALUES ('FMN2','Orto ativa assistida','Fisio Motora');
INSERT INTO TAB_PROCEDIMENTO VALUES ('FMN3','Orto ativa livre','Fisio Motora');
INSERT INTO TAB_PROCEDIMENTO VALUES ('FMN4','Orto ativa resistida','Fisio Motora');
INSERT INTO TAB_PROCEDIMENTO VALUES ('ALG','Alongamento','Fisio Motora');
INSERT INTO TAB_PROCEDIMENTO VALUES ('DEA','Deambulação/Treino de marcha','Fisio Motora');
INSERT INTO TAB_PROCEDIMENTO VALUES ('Eq','Treino de equilíbrio','Fisio Motora');
INSERT INTO TAB_PROCEDIMENTO VALUES ('ORT','Ortostatismo','Fisio Motora');
INSERT INTO TAB_PROCEDIMENTO VALUES ('POS','Posicionamento','Fisio Motora');
INSERT INTO TAB_PROCEDIMENTO VALUES ('TR','Transferências (cadeira/leito)','Fisio Motora');

INSERT INTO TAB_PROCEDIMENTO VALUES ('OFMN','Fisio M. Neurológica','Orientação');
INSERT INTO TAB_PROCEDIMENTO VALUES ('OFMO','Fisio M. Ortopédica','Orientação');
INSERT INTO TAB_PROCEDIMENTO VALUES ('OFR','Fisio respiratória','Orientação');
INSERT INTO TAB_PROCEDIMENTO VALUES ('OTR','de Tranferência','Orientação');

INSERT INTO TAB_PROCEDIMENTO VALUES ('ASP','Aspiração','Fisio Respiratória');
INSERT INTO TAB_PROCEDIMENTO VALUES ('ER','Exercícios respiratórios','Fisio Respiratória');
INSERT INTO TAB_PROCEDIMENTO VALUES ('MHB','Manobras de higiene/reexpansão','Fisio Respiratória');
INSERT INTO TAB_PROCEDIMENTO VALUES ('OX','Oxigenoterapia','Fisio Respiratória');
INSERT INTO TAB_PROCEDIMENTO VALUES ('TT','Troca de traqueo','Fisio Respiratória');
INSERT INTO TAB_PROCEDIMENTO VALUES ('VM','Ventilação mecânica','Fisio Respiratória');

INSERT INTO TAB_PROCEDIMENTO VALUES ('Alta','Alta','');
