$(document).ready(function () {
    $("#tablaAjustes").show();
});

function MostrarAjustes(ConsecutivoSeleccionado) {

    $.ajax({
        type: 'GET',
        url: '/Consulta/ConsultarAjustes',
        data: { Consecutivo: ConsecutivoSeleccionado },
        dataType: 'json',
        success: function (data) {

            var lista = "";
            $.each(data, function (index, value) {
                lista += '<tr><td>' + value.Ajuste + '</td><td>' + value.AjusteRealizado + '</td></tr>';
            })

            $("#tAjustes").html(lista);
            $("#tablaAjustes").show();

        },
        error: function (data) {

            $("#tAjustes").html('<tr><td colspan="2">Sin Registros</td></tr>');
            $("#tablaAjustes").show();

            //$("#tablaAjustes").hide();
        }
    });

}