$(document).ready(function () {
    $('form').on('submit', function (e) {
        e.preventDefault();
        ResetPaginacao();
        CarregarLista();
    });

    CarregarLista();
});
function Paginacao() {
    $('ul.pagination a[href]').on('click', function (e) {
        e.preventDefault();

        var pagina = $(this).attr("href");
        $("#Pagina").val(pagina);
        CarregarLista();
    });

    $('a', '#perfis th').on('click', function (e) {
        e.preventDefault();

        var href = $(this).attr("href");
        var valores = [];
        $(href.split('&')).each(function () {
            valores.push(this.split('=')[1]);
        });
        $("#Ordenacao").val(valores[0]);
        $("#OrdenacaoDirecao").val(valores[1]);
        CarregarLista();
    });
}

function ResetPaginacao() {
    $("#Pagina").val('1');
}

function LimparFiltros() {
    ResetPaginacao();
    $('#Nome').val('');
    CarregarLista();
}


function CarregarLista() {
    //var data = getFormData($("form"));
    $('#lista-Manobristas').load('/Manobrista/Listar', function () { Paginacao(); });
}


