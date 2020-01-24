$(document).ready(function () {
    RemoveAutoComplete();
    $(".bootstrap-switch").bootstrapSwitch({
        onText: "Ativo",
        offText: "Inativo",
        offColor: "danger",
    });
    $(".bootstrap-switch-sim-nao").bootstrapSwitch({
        onText: "Sim",
        offText: "Não",
        offColor: "danger",
    });
    $(".bootstrap-switch-ip").bootstrapSwitch({
        onText: "Dinâmico",
        onColor: "primary",
        offText: "Fixo",
        offColor: "success"
    });
    CriaDateTime();
    $('[data-toggle="tooltip"]').tooltip();

    $.fn.select2.defaults.set('language', 'pt-BR');

    $('.select2, .select2-multiple').select2({
        "placeholder": $(this).data('placeholder'),
        "language": "pt-BR"
    });

});

function RemoveAutoComplete() {
    $("input:text,form").attr("autocomplete", "off");
    $(".login-content input").attr("autocomplete", "on");
}

function isValidEmailAddress(emailAddress) {
    var pattern = /^([a-z\d!#$%&'*+\-\/=?^_`{|}~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]+(\.[a-z\d!#$%&'*+\-\/=?^_`{|}~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]+)*|"((([ \t]*\r\n)?[ \t]+)?([\x01-\x08\x0b\x0c\x0e-\x1f\x7f\x21\x23-\x5b\x5d-\x7e\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|\\[\x01-\x09\x0b\x0c\x0d-\x7f\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))*(([ \t]*\r\n)?[ \t]+)?")@(([a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|[a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF][a-z\d\-._~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]*[a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])\.)+([a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|[a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF][a-z\d\-._~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]*[a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])\.?$/i;
    return pattern.test(emailAddress);
};

function isValidPhone(telefone) {
    return telefone.replace(".", "").replace("(", "").replace(")", "").replace(" ", "").replace("-", "")
}

function CriarMultiploDropDown(field, label, limite, filtro, todos, dropup, maxheight) {
    field = "#" + field;
    $(field).multiselect({
        buttonWidth: '100%',
        buttonClass: 'btn btn-success m-r-5 m-b-5',
        buttonText: function (options, select) {
            if (options.length === 0) {
                return 'Nenhum ' + label + ' selecionado';
            }
            else if (options.length > limite) {
                if (label.endsWith('ão'))
                    return options.length + ' ' + label.substring(0, label.lastIndexOf('ão')) + 'ões selecionados';
                else
                    return options.length + ' ' + label + 's selecionados';
            }
            else {
                var labels = [];
                options.each(function () {
                    if ($(this).attr('label') !== undefined) {
                        labels.push($(this).attr('label'));
                    }
                    else {
                        labels.push($(this).html());
                    }
                });
                return labels.join('; ') + '';
            }
        },
        dropUp: dropup,
        enableFiltering: filtro,
        filterPlaceholder: 'Pesquisar',
        includeSelectAllOption: todos,
        maxHeight: maxheight,
        enableCaseInsensitiveFiltering: true,
        selectAllText: 'Selecionar todos!',
    });
}

function CriaDateTime() {

    $(".dateTimePicker").datetimepicker({
        locale: "pt-br",
        toolbarPlacement: "top",
        sideBySide: false,
        showClose: true,
        showClear: true,
        format: "DD/MM/YYYY HH:mm"

    });
    $(".DatePicker").datetimepicker({
        locale: "pt-br",
        //toolbarPlacement: "top",
        //showClose: true,
        //showClear: true,
        format: "L",
    });
    $('.MonthPicker').datetimepicker({
        locale: "pt-br",
        toolbarPlacement: "top",
        showClose: true,
        showClear: true,
        viewMode: 'years',
        format: 'MM/YYYY'
    });
}

function cleanArray(actual) {
    var newArray = new Array();
    for (var i = 0; i < actual.length; i++) {
        if (actual[i]) {
            newArray.push(actual[i]);
        }
    }
    return newArray;
}

$.fn.AddLoading = function () {
    $(this).addClass("panel-loading");
    $(this).append($("<span class='spinner-small'></span>"));
    $(this).find("table").hide();
}

$.fn.RemoveLoading = function () {
    $(this).removeClass("panel-loading");
    $(this).find("span").removeClass("spinner-small");
    $(this).find("table").show();
}

function getFormData($form) {
    var unindexed_array = $form.serializeArray();
    var indexed_array = {};

    $.map(unindexed_array, function (n, i) {
        indexed_array[n['name']] = n['value'];
    });

    return indexed_array;
}

function PreventSubmitOnEnter() {
    $(window).keydown(function (event) {
        if (event.keyCode == 13) {
            event.preventDefault();
            return false;
        }
    });
}

