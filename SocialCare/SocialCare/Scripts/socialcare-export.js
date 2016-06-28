$(document).ready(function () {
    var btnExport = $("#btnExport");

    if (btnExport.length > 0) {
        btnExport.click(function () {
            var dataExport = new Object();

            dataExport.dataInicial = $("#txtDataInicial").val();
            dataExport.dataFinal = $("#txtDataFinal").val();

            var url = "http://localhost:32110/api/visitas/export?param1=" + $("#txtDataInicial").val() + "&param2=" + $("#txtDataFinal").val();

            window.open(url);


            //$.ajax({
            //    url: "http://localhost:32110/api/visitas/export?para1=ghsdfh&param2=wdgdfg",
            //    type: "POST",
            //    //dataType: "json",
            //    data: dataExport,
            //    success: function (data) {
                    
            //        console.log("DEU CERTO");
            //    },
            //    error: function (xhr, textStatus, errorThrown) {
            //        console.log(xhr);
            //        console.log(textStatus);
            //        console.log(errorThrown);
            //        console.log("DEU ERRO");
            //    }
            //});
        });
    }
});