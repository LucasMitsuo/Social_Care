$(document).ready(function () {
    EnviaDadosNovoProntuario();
    EnviaDadosEditaProntuario();

    function EnviaDadosNovoProntuario() {

        var appAddress = $("#body-site").attr("data-appAddress");

        var restoreData = localStorage.getItem("dadosNovoProntuario");
        console.log(restoreData);
        var idPaciente = localStorage.getItem("idPaciente");
        console.log(idPaciente);
        //Verifica se há dados armazenados no localStorage
        if (restoreData != null && restoreData != "null") {
            console.log("NOVO PRONTUÁRIO: TEM DADOS A SEREM ATUALIZADOS");
            console.log(JSON.parse(restoreData));

            //Verifica se tem internet
            $.ajax({
                url: "http://thaysboschi-001-site1.itempurl.com/api/checknetwork",
                async: false,
                type: "GET",
                datatype: "json",
                success: function (data) {

                    $.ajax({
                        url:  appAddress+"api/pacientes/" + idPaciente + "/prontuario",
                        type: "POST",
                        dataType: "json",
                        data: JSON.parse(restoreData),
                        success: function (data) {
                            console.log("Dados do novo prontuario sincronizados com sucesso !");
                            //Limpa o localStorage
                            localStorage.setItem("dadosNovoProntuario", null);
                            localStorage.setItem("idPaciente", null);
                        },
                        error: function (xhr, textStatus, errorThrown) {
                            //Não faz nada ....
                            console.log("Parece que ainda não há internet. Os dados continuarão salvos.")
                        }
                    });
                },
                error: function (xhr, textStatus, errorThrown) {
                   //Não faz nada ....
                }
            });

        }
        else {
            console.log("NOVO PRONTUÁRIO: NÃO TEM DADOS A SEREM ATUALIZADOS");
        }
    }

    function EnviaDadosEditaProntuario() {
        var appAddress = $("#body-site").attr("data-appAddress");

        var restoreData = localStorage.getItem("dadosProntuario");
        console.log(restoreData);
        var idPaciente = localStorage.getItem("idPaciente");
        console.log(idPaciente);
        //Verifica se há dados armazenados no localStorage
        if (restoreData != null && restoreData != "null") {
            console.log("PRONTUÁRIO: TEM DADOS A SEREM ATUALIZADOS");
            console.log(JSON.parse(restoreData));


            //Verifica se tem internet
            $.ajax({
                url: "http://thaysboschi-001-site1.itempurl.com/api/checknetwork",
                async: false,
                type: "GET",
                datatype: "json",
                success: function (data) {

                    $.ajax({
                        url: appAddress+"api/pacientes/" + idPaciente + "/prontuario",
                        type: "PUT",
                        dataType: "json",
                        data: JSON.parse(restoreData),
                        success: function (data) {
                            console.log("Dados do prontuario sincronizados com sucesso !");
                            //Limpa o localStorage
                            localStorage.setItem("dadosProntuario", null);
                            localStorage.setItem("idPaciente", null);
                        },
                        error: function (xhr, textStatus, errorThrown) {
                            //Não faz nada ....
                            console.log("Parece que ainda não há internet. Os dados continuarão salvos.")
                        }
                    });
                },
                error: function (xhr, textStatus, errorThrown) {
                    //Não faz nada ....
                }
            });


        }
        else {
            console.log("PRONTUÁRIO: NÃO TEM DADOS A SEREM ATUALIZADOS");
        }
    }

    // ================================== BOTÃO PARA CRIAR UM NOVO PRONTUÁRIO ========================
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
                var chkMatConcO2 = elem.attr("data-chkmatConcO2");
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

                if ($(chkMatConcO2).is(":checked")) {
                    dadosProntuario.mat_ConcO2 = true;
                }
                else {
                    dadosProntuario.mat_ConcO2 = false;
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

                //Envia um request para a rota IsConnected para verificar se há conexão com a internet
                $.ajax({
                    url: "http://thaysboschi-001-site1.itempurl.com/api/checknetwork",
                    async: false,
                    type: "GET",
                    datatype: "json",
                    success: function (data) {
                        var appAddress = $("#body-site").attr("data-appAddress");
                        $.ajax({
                            url: appAddress+"api/pacientes/" + idPaciente + "/prontuario",
                            type: "POST",
                            dataType: "json",
                            data: dadosProntuario,
                            success: function (data) {
                                //Se os dados forem salvos com sucesso, redireciona para a lista de visitas
                                var url = appAddress+"profissionais/" + idProfissional + "/visitas";
                                $.get(url, null, function (response) {
                                    $("#body-site").html(response);
                                });

                                alert("O prontuário foi criado com sucesso !!");
                            },
                            error: function (xhr, textStatus, errorThrown) {
                                alert("Oops !! Parece que ocorreu um erro interno ou sua conexão com a internet caiu.\nOs dados do formulário foram salvos e serão atualizados quando a conexão se reestabelecer.");

                                localStorage.setItem("dadosNovoProntuario", JSON.stringify(dadosProntuario));
                                localStorage.setItem("idPaciente", idPaciente);

                            }
                        });

                    },
                    //Se não houver conexão com a internet, salva os dados no LocalStorage
                    error: function (xhr, textStatus, errorThrown) {

                        alert("Oops !! Parece que ocorreu um erro interno ou sua conexão com a internet caiu.\nOs dados do formulário foram salvos e serão atualizados quando a conexão se reestabelecer.");

                        localStorage.setItem("dadosNovoProntuario", JSON.stringify(dadosProntuario));
                        localStorage.setItem("idPaciente", idPaciente);


                        console.log("ERRO");
                    }
                });

            }
        });        
    }

    // ================================== BOTÃO PARA SALVAR OS DADOS DO PRONTUÁRIO ========================

    var btnSalvarDados = $("#btnSalvarDados");
    if (btnSalvarDados.length > 0) {
        btnSalvarDados.click(function () {
            var elem = $("#salvar-prontuario");
            if (elem.length > 0) {

                var dadosProntuario = new Object();

                var idPaciente = elem.attr("data-idPaciente");
                idPaciente = $(idPaciente).val();

                var idProfissional = elem.attr("data-idProfissional");
                idProfissional = $(idProfissional).val();
                dadosProntuario.idProfissional = idProfissional;

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
                var chkMatConcO2 = elem.attr("data-chkmatConcO2");
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
                else {
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

                if ($(chkMatConcO2).is(":checked")) {
                    dadosProntuario.mat_ConcO2 = true;
                }
                else {
                    dadosProntuario.mat_ConcO2 = false;
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

                //Dados relacionados à visita
                var procedimentos = elem.attr("data-txtProcedimentos");
                var periodicidade = elem.attr("data-txtPeriodicidade");
                var observacao = elem.attr("data-txtObs");

                dadosProntuario.periodicidade = $(periodicidade).val();
                dadosProntuario.lstProcedimento = $(procedimentos).val();
                dadosProntuario.txtObs = $(observacao).val();

                //Dados relacionados a saída
                var dataSaida = elem.attr("data-saidaData");
                var motivoSaida = elem.attr("data-comboMotivo");

                dadosProntuario.saidaData = $(dataSaida).val();
                dadosProntuario.saidaMotivo = $(motivoSaida).val();

                console.log($(dataSaida).val());
                console.log($(motivoSaida).val());

                if (dadosProntuario.saidaData != "" && dadosProntuario.saidaMotivo != "") {
                    dadosProntuario.saida = true;
                }

                $("input:radio[name=saidaDescricao]").each(function () {
                    if ($(this).is(":checked")) {
                        dadosProntuario.saidaDescricao = $(this).val();
                    }
                });

                if (dadosProntuario.saidaDescricao == null) {
                    if (dadosProntuario.saidaMotivo == "1") {
                        dadosProntuario.saidaDescricao = $("#txtNovoMotivo").val();
                    }
                    else {
                        dadosProntuario.saidaDescricao = $("#txtNovoLocal").val();
                    }
                }

                //Envia um request para a rota IsConnected para verificar se há conexão com a internet
                $.ajax({
                    url: "http://thaysboschi-001-site1.itempurl.com/api/checknetwork",
                    async: false,
                    type: "GET",
                    dataType: "json",
                    success: function (data) {
                        var appAddress = $("#body-site").attr("data-appAddress");
                        $.ajax({
                            url: appAddress +"api/pacientes/" + idPaciente + "/prontuario",
                            type: "PUT",
                            dataType: "json",
                            data: dadosProntuario,
                            success: function (data) {
                                console.log("Deu certo");
                                //Se os dados forem salvos com sucesso, redireciona para a lista de visitas
                                var url = appAddress+"profissionais/" + idProfissional + "/visitas";
                                $.get(url, null, function (response) {
                                    $("#body-site").html(response);
                                });

                                alert("O prontuário foi atualizado com sucesso !!");
                            },
                            error: function (xhr, textStatus, errorThrown) {
                                alert("Oops !! Parece que ocorreu um erro interno ou sua conexão com a internet caiu.\nOs dados do formulário foram salvos e serão atualizados quando a conexão se reestabelecer.");

                                localStorage.setItem("dadosProntuario", JSON.stringify(dadosProntuario));
                                localStorage.setItem("idPaciente", idPaciente);

                            }
                        });


                    },
                    //Se não houver conexão com a internet, salva os dados no LocalStorage
                    error: function (xhr, textStatus, errorThrown) {
                        alert("Oops !! Parece que ocorreu um erro interno ou sua conexão com a internet caiu.\nOs dados do formulário foram salvos e serão atualizados quando a conexão se reestabelecer.");

                        localStorage.setItem("dadosProntuario", JSON.stringify(dadosProntuario));
                        localStorage.setItem("idPaciente", idPaciente);
                        console.log("Ocorreu um erro na hora de salvar os dados");
                    }
                });

                






            }
        });
    }
});