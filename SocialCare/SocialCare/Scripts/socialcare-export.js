$(document).ready(function () {

    var btnExport = $("#btnExport");

    if (btnExport.length > 0) {
        btnExport.click(function () {

            var dataInicial = $("#txtDataInicial").val();
            var dataFinal = $("#txtDataFinal").val();

            var url = "http://localhost:32110/api/visitas/export?param1=" + dataInicial + "&param2=" + dataFinal;


            dataInicial = new Date(dataInicial);
            dataFinal = new Date(dataFinal);

            console.log(dataInicial);
            console.log(dataFinal);

            //Verifica se a dataFinal é maior que a inicial
            if (dataFinal < dataInicial) {
                alert("Atenção !!\n\nA Data Final deve ser maior que a Data Inicial.");
            }
            else if(dataFinal == "Invalid Date" || dataInicial == "Invalid Date"){
                alert("Atenção !!\n\nA Data Inicial ou a Data Final está em formato incorreto.");
            }
            else {

                $.ajax({
                    url: "http://thaysboschi-001-site1.itempurl.com/api/checknetwork",
                    async: false,
                    type: "GET",
                    datatype: "json",
                    success: function (data) {

                        $.ajax({
                            url: url,
                            type: "GET",
                            success: function (data) {
                                window.open(url);
                                console.log("Relatório exportado com sucesso !");
                            },
                            error: function (xhr, textStatus, errorThrown) {
                                console.log("Erro ao exportar o relatório");
                                alert("Não foram encontradas visitas nesse intervalo de datas.");
                            }
                        });

                    },
                    error: function (xhr, textStatus, errorThrown) {
                        alert("Ops ! Parece que você está sem conexão. Tente novamente mais tarde.");
                    }
                });

            }

            

            




        });
    }
});