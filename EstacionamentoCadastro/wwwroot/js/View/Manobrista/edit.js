$(document).ready(function () {
    $('#formManobrista').submit(function () {
        return ValidarSistemaOperacional();
    });
});


function ValidarSistemaOperacional() {
    var valid = true;

    var nome = $("#Nome");
    var idCarro = $("#Id");

    $(".input-validation-error").removeClass("input-validation-error");

    if (!nome.val().trim()) {
        nome.addClass('input-validation-error');
        valid = false;
    }
    if (!idCarro.val().trim()) {
        idCarro.addClass('input-validation-error');
        valid = false;
    }

    return valid;
}
