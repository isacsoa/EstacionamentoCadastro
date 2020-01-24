$(function () {
    var to = false;

    var id = $('#Parent').val();
    var url = '';
    var ContainerId = $('#IdContainer').val();
    var path = window.location.pathname.split("/")[1];

    if (id) {
        url = "/" + path + '/ObterContainerTreeview/?id=' + id;
    } else {
        url = "/" + path + '/ObterContainerTreeview';
    }

    $('#search').on("keyup", function () {
        if (to) {
            clearTimeout(to);
        }
        to = setTimeout(function () {
            var v = $('#search').val();
            $('#containterTree').jstree(true).search(v);
        }, 250);
    });
    var validarSelecaoContainer = function (idsValidar, idContainer) {
        for (var i = 0; i < idsValidar.length; i++) {
            if (idsValidar[i] == idContainer) return false;
        }

        return true;
    };

    $('#containterTree').on('changed.jstree loaded.jstree', function (e, data) {
        if (data && data.selected) {
            var i, j, r = [];
            for (i = 0, j = data.selected.length; i < j; i++) {
                r.push(data.instance.get_node(data.selected[i]).text);
                var ParentSelect = data.selected[i].replace('container', '');

                var idsProibidos = ['container' + ContainerId];
                idsProibidos = idsProibidos.concat(data.instance.get_node('container' + ContainerId).children_d);

                if (validarSelecaoContainer(idsProibidos, data.instance.get_node(data.selected[i]).id)) {
                    $('#Parent').val(data.selected[i].replace('container', ''));
                    $('#containerSelect').val(data.instance.get_path(data.selected[i]).join(' > '));
                    $('#containerModal').modal('hide');
                } else {
                    alert("Não é possível selecionar este container, por favor selecione um container válido.")
                }

            }
        }
    }).jstree({
        'core': {
            'data': function (obj, cb) {
                $.get(url, function (data) {
                    cb.call(this, JSON.parse(data));
                });
            }
        },
        "search": {
            show_only_matches: true
        },
        "plugins": ['search']
    });


    $('#btnLimparSelecao').on("click", function () {
        $('#Parent').val('');
        $('#containerSelect').val('');
        $('#containerModal').modal('hide');
        $("#containterTree").jstree("deselect_all");
    });

});
