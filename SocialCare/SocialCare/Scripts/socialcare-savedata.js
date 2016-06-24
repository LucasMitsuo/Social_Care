$(document).ready(function () {
    var btnNovoProntuario = $("#btnSalvarNovoProntuario");

    if (btnNovoProntuario.length > 0)
    {
        btnNovoProntuario.click(function ()
        {
            var elem = $("#novo-prontuario");
            if (elem.length > 0) {

                var dadosProntuario = new Object();

                var idPaciente = elem.attr("data-idPaciente");
                idPaciente = $(idPaciente).val();

                var idProfissional = elem.attr("data-idProfissional");
                idProfissional = $(idProfissional).val();

                //Captura o valor da lista de CID10
                var lstCID10 = elem.attr("data-target-input-cids");
                dadosProntuario.lstCID10 = $(lstCID10).val();

                //Captura os elementos data relacionados aos materiais
                var chkMatCama = elem.attr("data-chkmatCama");
                var chkMatCadRodas = elem.attr("data-chkmatCadRodas");
                var chkMatCadBanho = elem.attr("data-chkmatCadBanho");
                var chkMatAspirador = elem.attr("data-chkmatAspirador");
                var chkMatInalador = elem.attr("data-chkmatInalador");
                var chkMatColchao = elem.attr("data-chkmatColchao");
                var chkMatConc02 = elem.attr("data-chkmatConc02");
                var chkMatTorpTransp = elem.attr("data-chkmatTorpTransp");
                var chkMatOximetro = elem.attr("data-chkmatOximetro");
                var chkMatCpap = elem.attr("data-chkmatCpap");

                var chkProcGastro = elem.attr("data-chkprocGastro");
                var chkProcPOD = elem.attr("data-chkprocPOD");
                var chkProcNasoEnteral = elem.attr("data-chkprocNasoEnteral");
                var chkProcVesicalDemora = elem.attr("data-chkprocVesicalDemora");
                var chkProcVesicalInterm = elem.attr("data-chkprocVesicalInterm");
                var chkProcTraqueostomia = elem.attr("data-chkprocTraqueostomia");
                var grauCE = elem.attr("data-grau-CE");

                dadosProntuario.grauCE = $(grauCE).val();

                //Define os valores das CheckBoxes

                // ============== MATERIAIS ==============
                if ($(chkMatCama).is(":checked")) {
                    dadosProntuario.mat_cama = true;
                }
                else
                {
                    dadosProntuario.mat_cama = false;
                }

                if ($(chkMatCadRodas).is(":checked")) {
                    dadosProntuario.mat_cadRodas = true;
                }
                else {
                    dadosProntuario.mat_cadRodas = false;
                }

                if ($(chkMatCadBanho).is(":checked")) {
                    dadosProntuario.mat_cadBanho = true;
                }
                else {
                    dadosProntuario.mat_cadBanho = false;
                }

                if ($(chkMatAspirador).is(":checked")) {
                    dadosProntuario.mat_Aspirador = true;
                }
                else {
                    dadosProntuario.mat_Aspirador = false;
                }

                if ($(chkMatInalador).is(":checked")) {
                    dadosProntuario.mat_Inalador = true;
                }
                else {
                    dadosProntuario.mat_Inalador = false;
                }

                if ($(chkMatColchao).is(":checked")) {
                    dadosProntuario.mat_Colchao = true;
                }
                else {
                    dadosProntuario.mat_Colchao = false;
                }

                if ($(chkMatConc02).is(":checked")) {
                    dadosProntuario.mat_Conc02 = true;
                }
                else {
                    dadosProntuario.mat_Conc02 = false;
                }

                if ($(chkMatTorpTransp).is(":checked")) {
                    dadosProntuario.mat_torpTransp = true;
                }
                else {
                    dadosProntuario.mat_torpTransp = false;
                }

                if ($(chkMatOximetro).is(":checked")) {
                    dadosProntuario.mat_Oximetro = true;
                }
                else {
                    dadosProntuario.mat_Oximetro = false;
                }

                if ($(chkMatCpap).is(":checked")) {
                    dadosProntuario.mat_CPAP = true;
                }
                else {
                    dadosProntuario.mat_CPAP = false;
                }

                // ============== PROC ENFERMEIRA ==============
                
                if ($(chkProcGastro).is(":checked")) {
                    dadosProntuario.proc_Gastro = true;
                }
                else {
                    dadosProntuario.proc_Gastro = false;
                }

                if ($(chkProcPOD).is(":checked")) {
                    dadosProntuario.proc_POD = true;
                }
                else {
                    dadosProntuario.proc_POD = false;
                }

                if ($(chkProcNasoEnteral).is(":checked")) {
                    dadosProntuario.proc_SNasoEnteral = true;
                }
                else {
                    dadosProntuario.proc_SNasoEnteral = false;
                }

                if ($(chkProcVesicalDemora).is(":checked")) {
                    dadosProntuario.proc_SVesicalDemora = true;
                }
                else {
                    dadosProntuario.proc_SVesicalDemora = false;
                }

                if ($(chkProcVesicalInterm).is(":checked")) {
                    dadosProntuario.proc_SVesicalInterm = true;
                }
                else {
                    dadosProntuario.proc_SVesicalInterm = false;
                }

                if ($(chkProcTraqueostomia).is(":checked")) {
                    dadosProntuario.proc_Traqueostomia = true;
                }
                else {
                    dadosProntuario.proc_Traqueostomia = false;
                }

                //Captura os elementos referente a UP
                var UP = elem.attr("data-rdoSIM");
                
                //Verifica se o paciente tem UP
                if ($(UP).is(":checked")) {
                    dadosProntuario.UP = true;

                    //Verifica se o momento é PRÉ ou PÓS
                    var momento = elem.attr("data-rdoPRE");
                    if ($(momento).is(":checked")) {
                        dadosProntuario.momento_UP = "PRÉ";
                    }
                    else {
                        dadosProntuario.momento_UP = "PÓS";
                    }

                    var estagio = elem.attr("data-comboEstagio");
                    var dataUP = elem.attr("data-txtData");

                    dadosProntuario.estagio_UP = $(estagio).val();
                    dadosProntuario.data_UP = $(dataUP).val();

                }
                
                
                $.ajax({
                    url: "http://localhost:32110/api/pacientes/" + idPaciente + "/prontuario",
                    type: "POST",
                    dataType: "json",
                    data: dadosProntuario,
                    success: function (data) {
                        //Se os dados forem salvos com sucesso, redireciona para a lista de visitas
                        var url = "http://localhost:32110/profissionais/" + idProfissional + "/visitas";
                        $.get(url, null, function (response) {
                            $("#body-site").html(response);
                        });
                    },
                    error: function (xhr, textStatus, errorThrown) {
                        alert("Oops !! Parece que ocorreu um erro interno ou sua conexão com a internet caiu.\nOs dados do formulário foram salvos e serão atualizados quando a conexão se reestabelecer.");

                        localStorage.setItem("dadosNovoProntuario", JSON.stringify(dadosProntuario));

                        //REALIZAR ESSE CÓDIGO ABAIXO ONDE FOR RECUPERAR OS DADOS DO LOCALSTORAGE
                        //var objeto = localStorage.getItem("dadosNovoProntuario");
                        //console.log(JSON.parse(objeto));

                    }
                });
            }
        });        
    }
});