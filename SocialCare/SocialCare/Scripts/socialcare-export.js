$(document).ready(function () {
    var btnExport = $("#btnExport");

    if (btnExport.length > 0) {
        btnExport.click(function () {
            var dataExport = new Object();

            dataExport.dataInicial = $("#txtDataInicial").val();
            dataExport.dataFinal = $("#txtDataFinal").val();

            $.ajax({
                url: "http://localhost:32110/api/visitas/export",
                type: "POST",
                dataType: "json",
                data: dataExport,
                success: function (data) {
                    console.log("DEU CERTO");
                },
                error: function (xhr, textStatus, errorThrown) {
                    console.log(xhr);
                    console.log(textStatus);
                    console.log(errorThrown);
                    console.log("DEU ERRO");
                }
            });
        });
    }
});