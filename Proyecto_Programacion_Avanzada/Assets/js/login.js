
$(document).ready(function () {
    $('.login-info-box').fadeOut();
    $('.login-show').addClass('show-log-panel')


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

function ValidarCampo(campoTXT) {
    if (campoTXT == "") {
        swal(
            'Oops...',
            'El campo no puede ser vacio',
            'error'
        )
    }
}
function ValidarCampoId() {
    
    let id = $("#identificacion").val();
    var valoresAceptados = /^[0-9]+$/;
    if (id.length <= 9 && id.match(valoresAceptados)) {
    } else {
        swal(
            'Oops...',
            'El campo de Identificacion no valido',
            'error'
        )
    }
}

function ValidarCampoTel() {
    
    let id = $("#telefono").val();
    var valoresAceptados = /^[0-9]+$/;
    if (id.length <= 8 && id.match(valoresAceptados) && id.length >= 8) {
    } else {
        swal(
            'Oops...',
            'El campo de telefono no valido',
            'error'
        )
    }
}

function ValidarCampoCorreo(campoCorreo) {

    var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    if (campoCorreo.match(mailformat)) {

    } else {
        swal(
            'Oops...',
            'El campo de correo no valido',
            'error'
        )
    }
}

function ValidarCampoContrasena(pass) {

    var lowerCaseLetters = /[a-z]/g;
    var numbers = /[0-9]/g;
    if (/*pass.match(lowerCaseLetters) && */ pass.length >= 6 /*&& pass.match(numbers)*/) {
       
    } else {
        swal(
            'Oops...',
            'El campo de contraseña no valido',
            'error'
        )
    }
}

function ValidarContrasenas(pass) {

    let pass1 = $("#Contrasena1").val();
    if (pass === pass1) {
       
    } else {
        swal(
            'Oops...',
            'El campo de contraseñas no son identicos',
            'error'
        )
    }
}






//var myInput = document.getElementById("psw");
//var letter = document.getElementById("letter");
//var capital = document.getElementById("capital");
//var number = document.getElementById("number");
//var length = document.getElementById("length");

//// When the user clicks on the password field, show the message box
//myInput.onfocus = function () {
//    document.getElementById("message").style.display = "block";
//}

//// When the user clicks outside of the password field, hide the message box
//myInput.onblur = function () {
//    document.getElementById("message").style.display = "none";
//}

//// When the user starts to type something inside the password field
//myInput.onkeyup = function () {
//    // Validate lowercase letters
//    var lowerCaseLetters = /[a-z]/g;
//    if (myInput.value.match(lowerCaseLetters)) {
//        letter.classList.remove("invalid");
//        letter.classList.add("valid");
//    } else {
//        letter.classList.remove("valid");
//        letter.classList.add("invalid");
//    }

//    // Validate capital letters
//    var upperCaseLetters = /[A-Z]/g;
//    if (myInput.value.match(upperCaseLetters)) {
//        capital.classList.remove("invalid");
//        capital.classList.add("valid");
//    } else {
//        capital.classList.remove("valid");
//        capital.classList.add("invalid");
//    }

//    // Validate numbers
//    var numbers = /[0-9]/g;
//    if (myInput.value.match(numbers)) {
//        number.classList.remove("invalid");
//        number.classList.add("valid");
//    } else {
//        number.classList.remove("valid");
//        number.classList.add("invalid");
//    }

//    // Validate length
//    if (myInput.value.length >= 8) {
//        length.classList.remove("invalid");
//        length.classList.add("valid");
//    } else {
//        length.classList.remove("valid");
//        length.classList.add("invalid");
//    }
//}


