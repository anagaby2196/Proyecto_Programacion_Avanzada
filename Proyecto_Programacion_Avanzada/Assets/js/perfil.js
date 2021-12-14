function ActualizarPerfil() {

    var Model_Nombre = $("#Model_Nombre").val();
    var Model_PrimerApellido = $("#Model_PrimerApellido").val();
    var Model_SegundoApellido = $("#Model_SegundoApellido").val();
    var Model_Telefono = $("#Model_Telefono").val();
    var Model_Correo = $("#Model_Correo").val();
    var Model_Edad = $("#Model_Edad").val();
    var Model_Sexo = $("#Model_Sexo").val();
    var Model_Provincia = $("#Model_Provincia").val();
    var Model_Canton = $("#Model_Canton").val();
    var Model_Distrito = $("#Model_Distrito").val();


    $.ajax({
        type: 'POST',
        url: '/Perfil/ActualizarPerfil',
        data: {
            Nombre: Model_Nombre,
            PrimerApellido: Model_PrimerApellido,
            SegundoApellido: Model_SegundoApellido,
            Telefono: Model_Telefono,
            Correo: Model_Correo,
            Edad: Model_Edad,
            Sexo: Model_Sexo,
            Provincia: Model_Provincia,
            Canton: Model_Canton,
            Distrito: Model_Distrito
        },
        dataType: 'json',
        success: function (respuesta) {
            swal(
                'Se ha procesado...',
                'Sa ha actualizado corrrectamente',
                'success',
            )
            location.reload();
        },
        error: function (respuesta) {
            swal(
                'Oops...',
                'Ha ocurrido un error' + ' ' + respuesta,
                'error'
            )
        }
    });

}


function ActualizarTioUsuario(tipoUsuario,cedula) {
    swal({
        title:"¿Esta seguro que quiere cambiar el tipo de usuario?",
        text: "Una vez realizado el cambio, el usuario se habilitara con ese otro tipo de rol.",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                var Model_TipoUsuario = tipoUsuario;
                var Model_IdUsuario = cedula;
                $.ajax({
                    type: 'POST',
                    url: '/Perfil/ActualizarTipoUsuario',
                    data: {
                        TipoUsuario: Model_TipoUsuario,
                        Identificacion: Model_IdUsuario
                    },
                    dataType: 'json',
                    success: function (respuesta) {
                        location.reload();
                    },
                    error: function (respuesta) {
                        alert("Accion no se pudo completar");
                    }
                })
            }
        });
}