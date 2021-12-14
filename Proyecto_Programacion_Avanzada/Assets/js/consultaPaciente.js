
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
            $("#Model_Edad").val(data.unPaciente.EDAD);
            $("#Model_Sexo").val(data.unPaciente.SEXO);

            var lista = "";
            $.each(data.exp, function (index, value) {
                lista += '<tr><td>' + convertToJavaScriptDate(value.HoraInicio) + '</td><td>' + value.NombreDoctor +
                    '</td><td>' + value.Padecimiento + '</td><td>' + value.Tratamiento + '</td></tr>';
            })

            $("#tabla_expediente").html(lista);

            $("#tablaAjustes").show();

        },
        error: function (data) {

            
            $("#tablaAjustes").hide();

        }
    });

}


function datosPaciente(pIdentificacion) {

    var valoresAceptados = /^[0-9]+$/;
    if (pIdentificacion.length <= 9 && pIdentificacion.match(valoresAceptados)) {

        $.ajax({
            type: 'GET',
            url: '/Paciente/ConsultarDatosCitas',
            data: { identificacion: pIdentificacion },
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
                $("#Model_Edad").val(data.unPaciente.Edad);
                if (data.unPaciente.Edad == 'F') {
                    $("#Model_Sexo").val('Femenino');
                } else if (data.unPaciente.Edad == 'M') {
                    $("#Model_Sexo").val('Masculino');
                } else {
                    $("#Model_Sexo").val('No indica');
                }


                var fecha = convertToJavaScriptDate(data.exp.HoraInicio);
                var codigo;

                $("#Model_Hora").val(fecha);
                $("#Model_codigoCitaProgramadas").val(data.exp.CodigoCitasProgramadas);

            },
            error: function (data) {
                alert("Paciente no encontrado")
            }

        });

} else {
                swal(
                    'Oops...',
                    'El campo de Identificacion no valido',
                    'error'
                )
         }


    

}

function convertToJavaScriptDate(value) {
    var pattern = /Date\(([^)]+)\)/;
    var results = pattern.exec(value);
    var dt = new Date(parseFloat(results[1]));
    return (dt.getMonth() + 1) + "/" + dt.getDate() + "/" + dt.getFullYear();
}


