var base_url = "http://localhost:62688/";
$(document).ready(function () {
    $(".button-collapse").sideNav();
    $('select').material_select();
    $('.modal-fornecedor').modal({
        ready: function (modal, trigger) {
            $.getJSON(base_url + 'Compra/GetProductInfo', function (json) {
                Compra.salva_item();
            });
        }
    });
});

Compra = {
    get_fornecedores : function(p){

    },
    salva_item: function (p) {

    }
}