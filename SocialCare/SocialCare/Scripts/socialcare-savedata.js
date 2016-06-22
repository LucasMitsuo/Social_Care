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

                //Captura o valor da lista de CID10
                var lstCID10 = elem.attr("data-target-input-cids");
                dadosProntuario.lstCID10 = $(lstCID10).val();

                //Captura os elementos data
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

                //Define os valores das CheckBoxes

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

                $.ajax({
                    url: "http://localhost:32110/api/pacientes/" + idPaciente + "/prontuario",
                    type: "POST",
                    dataType: "json",
                    data: dadosProntuario,
                    success: function (data) {

                    },
                    error: function (xhr, textStatus, errorThrown) {

                    }
                })
            }
        });        
    }
});