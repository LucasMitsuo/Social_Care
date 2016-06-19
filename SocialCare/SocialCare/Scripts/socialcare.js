$(document).ready(function () {

    //Recupera os dados da localStorage de nome lstCID
    var cidRecovery = localStorage.getItem("lstCID");

    //Recupera os dados da localStorage de nome lstProc
    var procRecovery = localStorage.getItem("lstProc");

    //Se o lstCID no localStorage estiver vazio, executa a função GetCids responsável por carregar a lista de CIDs no localStorage.
    if (cidRecovery == null) {
        GetCids();
        cidRecovery = localStorage.getItem("lstCID");
    }

    //Se o lstProc no localStorage estiver vazio, executa a função GetProcs responsável por carregar a lista de Procedimentos no localStorage.
    if (procRecovery == null) {
        GetProcs();
        procRecovery = localStorage.getItem("lstProc");
    }

    //Tranforma a string obtida do localStorage e converte para JSON
    var arrayCid = JSON.parse(cidRecovery);

    //Tranforma a string obtida do localStorage e converte para JSON
    var arrayProc = JSON.parse(procRecovery);

    //Chama funções necessárias no carregamento da página
    cidEngine();
    procedimentoEngine();
    UPClick();
    SelecionaMotivo();

    $("#btnSalvarDados").click(function () {
        EnviarDadosFormulario();
    });

    $("#btnSalvarVisita").click(function () {
        AdicionaVisita();
    });

    $("#btnLimpaCampos").click(function () {
        LimparCampos();
    });

    function EnviarDadosFormulario() {
        console.log("Aeee viado");
    }

    function LimparCampos() {
        $("#periodicidade").val("");
        $("#txtObservacao").val("");
    }

    function AdicionaVisita() {
        var procedimentos = $("#target-input-proc").val();
        var observacao = $("#txtObservacao").val().trim();
        var periodicidade = $("#periodicidade").val();
        var cargo = $("#label-nome-profissional").text();
        var cargoCustom = cargo.substring(15, cargo.length);
        var dataVisita = $("#label-data-visita").text();
        var dataVisitaCustom = dataVisita.substring(17, dataVisita.length);

        $("#novo-registro-visita").find('td.td-data').text(dataVisitaCustom);

        $("#novo-registro-visita").find('td.td-nome').text(cargoCustom);

        $("#novo-registro-visita").find('td.td-periodo').text(periodicidade);

        $("#novo-registro-visita").find('td.td-anotacoes').text(procedimentos + '\n' + observacao)

        $("#novo-registro-visita").removeClass("hidden");

        $("#btnAdicionarVisita").text("Editar Visita");
    }

    function SelecionaMotivo() {
        var cmbMotivo = $("#comboMotivo");
        var panel_alta = $("#saida-alta");
        var panel_obito = $("#saida-obito");

        cmbMotivo.change(function () {
            if (cmbMotivo.val() === "alta")
            {
                panel_alta.removeClass("hidden");
                panel_obito.addClass("hidden")
            }
            else if (cmbMotivo.val() == "obito")
            {
                panel_obito.removeClass("hidden");
                panel_alta.addClass("hidden");
            }
            else
            {
                panel_alta.addClass("hidden");
                panel_obito.addClass("hidden");
            }
        });
    }


    function UPClick() {

        if ($("#rdoSIM").is(":checked")) {          
            $("#rdoPRE").removeProp("disabled");
            $("#rdoPOS").removeProp("disabled");
            $("#comboEstagio").removeProp("disabled");
            $("#txtData").removeProp("disabled");
        }
        else {
            $("#rdoPRE").prop("disabled", true);
            $("#rdoPRE").prop("checked", false);

            $("#rdoPOS").prop("disabled", true);
            $("#rdoPOS").prop("checked", false);

            $("#comboEstagio").prop("disabled", true);
            $("#comboEstagio").val("");

            $("#txtData").prop("disabled", true);
            $("#txtData").val("");
        }

        $("#rdoSIM").change(function () {
            if ($(this).is(":checked")) {
                $("#rdoPRE").removeProp("disabled");
                $("#rdoPOS").removeProp("disabled");
                $("#comboEstagio").removeProp("disabled");
                $("#txtData").removeProp("disabled");
            }
        });

        $("#rdoNAO").change(function () {
            if ($(this).is(":checked")) {
                $("#rdoPRE").prop("disabled", true);
                $("#rdoPRE").prop("checked", false);

                $("#rdoPOS").prop("disabled", true);
                $("#rdoPOS").prop("checked", false);

                $("#comboEstagio").prop("disabled", true);
                $("#comboEstagio").val("");

                $("#txtData").prop("disabled", true);
                $("#txtData").val("");
            }
        });
    };

    //Função que busca todos os CIDS e armazena no localStorage
    function GetCids() {
        $.ajax({
            url: "http://localhost:32110/api/cid10",
            dataType: "json",
            cache: true,
            success: function (data) {
                //Armazena no localStorage todos os CIDS
                localStorage.setItem("lstCID", JSON.stringify(data));
            },
            error: function (xhr, ajaxOptions, thrownError) {
                return "ERRO";
            }
        });
    }

    function GetProcs() {
        $.ajax({
            url: "http://localhost:32110/api/procedimentos",
            dataType: "json",
            cache: true,
            success: function (data) {
                //Armazena no localStorage todos os CIDS
                localStorage.setItem("lstProc", JSON.stringify(data));
            },
            error: function (xhr, ajaxOptions, thrownError) {
                return "ERRO";
            }
        });
    }

    function checkProc(procedimento) {
        var termo = $("#target-insert-proc").val();
        return procedimento.toLowerCase().indexOf(termo.toLowerCase()) >= 0;
    }

    function checkCID(cid) {
        var termo = $("#target-insert").val();
        return cid.toLowerCase().indexOf(termo.toLowerCase()) >= 0;
    }


    function procedimentoEngine() {
        var elem = $("#rp-procedimentos");
                
        if (elem.length > 0) {
            var targetInput = $("#" + elem.attr("data-target-input"));
            var route = elem.attr("data-url");

            if (targetInput.length > 0) {
                var targetInsert = $("#rp-procedimentos input");

                var regex = /[.,\/#!$%\^&\*;:{}=\_`~()+º"!¨§]/ig;

                targetInsert.on({
                    keyup:function (ev) {
                        //termo utilizado para o tratamento de resultado não encontrado
                        var termo = $("#target-insert-proc").val();

                        var txt = this.value.replace(regex, '');
                        var _url = route.replace("{0}", txt);
                        var inpText = this;

                        $(this).autocomplete({
                            messages: {
                                noResults: function () {
                                    var spanError = elem.find("span.no-search");

                                    if (spanError.length == 0) {
                                        $("<span/>", { class: "no-search", text: "Não foram encontrados resultados para '" + termo + "'", insertAfter: targetInsert });
                                    }
                                    else {
                                        spanError.remove();
                                        $("<span/>", { class: "no-search", text: "Não foram encontrados resultados para '" + termo + "'", insertAfter: targetInsert });
                                    }
                                },
                                results: function (count) {
                                    elem.find("span.no-search").remove();
                                }

                            },
                            source: function (request, response) {
                                var result = arrayProc.filter(checkProc); //Obtem os a lista de CIDs já filtrados com o termo
                                response($.map(result.slice(0, 8), function (a) {
                                    return {
                                        word: a
                                    };
                                }));
                            },
                            select: function (event, ui) {
                                elem.append("<p class='tag-item'>" + ui.item.word + "</p>");

                                //Se a lista estiver vazia, coloca somente o valor selecionado
                                //Caso contrário, adiciona um ';' e o valor selecionado
                                var listTags = targetInput.val();

                                if (listTags[listTags.length - 1] == ";") {

                                }

                                if (listTags == "") {
                                    targetInput.val(ui.item.word);
                                }
                                else {
                                    targetInput.val(listTags + ";" + ui.item.word);
                                }
                            },
                            open: function () {
                                $(this).removeClass("ui-corner-all").addClass("ui-corner-top");
                            },
                            close: function () {
                                $(this).removeClass("ui-corner-top").addClass("ui-corner-all");
                            }
                        }).data("ui-autocomplete")._renderItem = function (ul, item) {
                            return $("<li class='extention' role='presentation'>")
                            .append("<a role='menuitem' tabindex='-1'><i class='glyphicon glyphicon-tags'></i>&nbsp;&nbsp;" + item.word + "</a>")
                            .appendTo(ul);
                        };
                        
                    }
                });

                elem.on('click', 'p', function () {
                    $(this).remove();
                    targetInput.val("");
                    targetInsert.val("");

                    elem.find("p.tag-item").each(function () {
                        targetInput.val(targetInput.val() + $(this).html() + ";");
                    });
                });
            }
        }
    }

    function cidEngine() {
        var elem = $("#rp-cids");

        if (elem.length > 0) {

            var targetInput = $("#" + elem.attr("data-target-input"));

            var route = elem.attr("data-url");

            if (targetInput.length > 0) {
                var str_cids = targetInput.val();

                if (str_cids != "") {
                    var array_cids = targetInput.val().split(";");
                    for (var i = 0; i < array_cids.length; i++) {
                        var texto = array_cids[i];
                        if (texto != "" && texto != " ") {
                            elem.append("<p class='tag-item'>" + texto + "</p>");
                        }
                    }
                }

                var targetInsert = $("#rp-cids input");

                var regex = /[.,\/#!$%\^&\*;:{}=\_`~()+º"!¨§]/ig;

                //Controle de evento do targetInsert
                targetInsert.on({
                    //Quando solta uma tecla
                    keyup: function (ev) {
                        //termo utilizado para o tratamento de resultado não encontrado
                        var termo = $("#target-insert").val();

                        var txt = this.value.replace(regex, '');
                        var _url = route.replace("{0}", txt);
                        var inpText = this;

                        $(this).autocomplete({
                            messages: {
                                noResults: function () {
                                    var spanError = elem.find("span.no-search");

                                    if (spanError.length == 0) {
                                        $("<span/>", { class: "no-search", text: "Não foram encontrados resultados para '" + termo + "'", insertAfter: targetInsert });
                                    }
                                    else {
                                        spanError.remove();
                                        $("<span/>", { class: "no-search", text: "Não foram encontrados resultados para '" + termo + "'", insertAfter: targetInsert });
                                    }
                                },
                                results: function (count) {
                                    elem.find("span.no-search").remove();
                                }

                            },
                            source: function (request, response) {
                                var result = arrayCid.filter(checkCID); //Obtem os a lista de CIDs já filtrados com o termo
                                response($.map(result.slice(0, 8), function (a) {
                                    return {
                                        word: a
                                    };
                                }));
                            },
                            select: function (event, ui) {
                                elem.append("<p class='tag-item'>" + ui.item.word + "</p>");

                                //Se a lista estiver vazia, coloca somente o valor selecionado
                                //Caso contrário, adiciona um ';' e o valor selecionado
                                var listTags = targetInput.val();

                                if (listTags == "") {
                                    targetInput.val(ui.item.word);
                                }
                                else {
                                    targetInput.val(listTags + ";" + ui.item.word);
                                }
                            },
                            open: function () {
                                $(this).removeClass("ui-corner-all").addClass("ui-corner-top");
                            },
                            close: function () {
                                $(this).removeClass("ui-corner-top").addClass("ui-corner-all");
                            }
                        }).data("ui-autocomplete")._renderItem = function (ul, item) {
                            return $("<li class='extention' role='presentation'>")
                            .append("<a role='menuitem' tabindex='-1'><i class='glyphicon glyphicon-tags'></i>&nbsp;&nbsp;" + item.word + "</a>")
                            .appendTo(ul);
                        };
                        
                    }
                });

                elem.on('click', 'p', function () {
                    $(this).remove();
                    targetInput.val("");
                    targetInsert.val("");

                    elem.find("p.tag-item").each(function () {
                        targetInput.val(targetInput.val() + $(this).html() + ";");
                    });
                });
            }
        }
    }


});


