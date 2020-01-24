
$(document).ready(function () {

    $('#formManobrista').submit(function () {
       var valid = ValidarPerfil(0);

        
        return valid;
    });

    gotoPage(1);
    //PreventSubmitOnEnter();    
});



function gotoPage(page) {
    $('.page1').hide();
    //$('.page2').hide();
    $('.page' + page).show();
}

function ValidarPerfil(pageTo) {
    var valid = true;

    var nome = $("#Nome");

    $(".input-validation-error").removeClass("input-validation-error");

    if (pageTo == 2 || pageTo == 0) {
        if (!nome.val().trim()) {
            nome.addClass('input-validation-error');
            valid = false;
        }
    }

    if (valid) {
        gotoPage(pageTo);
    }

    return valid;
}

