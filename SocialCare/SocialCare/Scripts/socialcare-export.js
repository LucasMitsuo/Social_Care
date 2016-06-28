$(document).ready(function () {
    var btnExport = $("#btnExport");

    if (btnExport.length > 0) {
        btnExport.click(function () {
            var dataExport = new Object();

            dataExport.dataInicial = $("#txtDataInicial").val();
            dataExport.dataFinal = $("#txtDataFinal").val();

            var url = "http://localhost:32110/api/visitas/export?param1=" + $("#txtDataInicial").val() + "&param2=" + $("#txtDataFinal").val();

            //window.open(url);


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
        });
    }
});