function ActualizarExpediente(Model_Padecimiento,Model_codigoCitaProgramadas,Model_Tratamiento) {


    var Model_Padecimiento = $("#Model_Padecimiento").val();
    var Model_Tratamiento = $("#Model_Tratamiento").val();
    var Model_codigoCitaProgramadas = $("Model_codigoCitaProgramadas").val();

    $.ajax({

        type: 'POST',
        url: 'Expediente/ActualizaExpediente',
        data: {
            Padecimiento: Model_Padecimiento,
            Tratamiento: Model_Tratamiento,
            CodigoCitaProgramadas: Model_codigoCitaProgramadas,
        },
        datatype: 'json',
        success: function(respuesta) {
            location.replace('Index');
        },
        error: function (respuesta) {
            alert("Error")
        }
    });
}