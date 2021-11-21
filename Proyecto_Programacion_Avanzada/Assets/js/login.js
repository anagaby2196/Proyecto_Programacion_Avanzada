
$(document).ready(function () {
    $('.login-info-box').fadeOut();
    $('.login-show').addClass('show-log-panel')

    //$("#registrar").submit(function (e) {
        
    //    $.ajax({
    //        type: "POST",
    //        url: '/Login/Registrar',
    //        data: { nombre: data.nombre, papellido: data.papellido, sapellido: data.sapellido, indentificacion: data.indentificacion, telefono: data.telefono, correo: data.correo, contrasena: data.contrasena },
    //        dataType: 'json',
    //        success: function (data) {
    //            if (data.status) {
    //                alert("success");
    //            }
    //        },
    //        error: function () {
    //            alert('Failed');
    //        }
    //    });
    //})
    

    //$("#LoginForm").submit(function (e) {
        
    //    $.ajax({
    //        type: "POST",
    //        url: '/Login/Login',
    //        data: { correoLogin: data.correoLogin, contrasenaLogin: data.contrasenaLogin },
    //        dataType: 'json',
    //        success: function (data) {
    //            if (data.status) {
    //                alert("success");
    //            }
    //        },
    //        error: function () {
    //            alert('Failed');
    //        }
    //    })
    //});
    


});


$('.login-reg-panel input[type="radio"]').on('change', function() {
    if($('#log-login-show').is(':checked')) {
        $('.register-info-box').fadeOut(); 
        $('.login-info-box').fadeIn();
        
        $('.white-panel').addClass('right-log');
        $('.register-show').addClass('show-log-panel');
        $('.login-show').removeClass('show-log-panel');
        
    }
    else if($('#log-reg-show').is(':checked')) {
        $('.register-info-box').fadeIn();
        $('.login-info-box').fadeOut();
        
        $('.white-panel').removeClass('right-log');
        
        $('.login-show').addClass('show-log-panel');
        $('.register-show').removeClass('show-log-panel');
    }
});

