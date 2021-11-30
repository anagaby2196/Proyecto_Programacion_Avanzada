$(document).ready(function () {
    $("#tablaAjustes").hide();
});

function MostrarDatos(identificacionSeleccionada) {

    $.ajax({
        type: 'GET',
        url: '/Paciente/ConsultarPaciente',
        data: { identificacion: identificacionSeleccionada},
        dataType: 'json',
        success: function (data) {
            $("#Model_Identificacion").val(data.Identificacion);
            $("#Model_Nombre").val(data.Nombre);
            $("#Model_PrimerApellido").val(data.PrimerApellido);
            $("#Model_SegundoApellido").val(data.SegundoApellido);
            $("#Model_Telefono").val(data.Telefono);
            $("#Model_Correo").val(data.Correo);
            $("#Model_Provincia").val(data.Provincia);
            $("#Model_Canton").val(data.Canton);
            $("#Model_Distrito").val(data.Distrito);
            $("#tablaAjustes").show();

        },
        error: function (data) {

            
            $("#tablaAjustes").hide();

            //$("#tablaAjustes").hide();
        }
    });

}