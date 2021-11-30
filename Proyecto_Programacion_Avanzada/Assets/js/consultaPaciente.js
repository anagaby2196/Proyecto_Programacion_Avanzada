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
            $("#Model_Identificacion").val(data.unPaciente.Identificacion);
            $("#Model_Nombre").val(data.unPaciente.Nombre);
            $("#Model_PrimerApellido").val(data.unPaciente.PrimerApellido);
            $("#Model_SegundoApellido").val(data.unPaciente.SegundoApellido);
            $("#Model_Telefono").val(data.unPaciente.Telefono);
            $("#Model_Correo").val(data.unPaciente.Correo);
            $("#Model_Provincia").val(data.unPaciente.Provincia);
            $("#Model_Canton").val(data.unPaciente.Canton);
            $("#Model_Distrito").val(data.unPaciente.Distrito);

            //var lista = data.exp;
            //$.each(data, function (index, value) {
            //    lista += '<tr><td>' + value.cpETL.HoraInicio + '</td><td>' + value.doctorETL.Nombre +
            //        '</td><td>' + value.cpETL.Padecimiento + '</td><td>' + value.cpETL.Tratamiento + '</td></tr>';
            //})

            //$("#tabla_expediente").html(lista);

            $("#tablaAjustes").show();

        },
        error: function (data) {

            
            $("#tablaAjustes").hide();

            //$("#tablaAjustes").hide();
        }
    });

}