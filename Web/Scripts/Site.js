var base_url = "http://localhost:62688/";
$(document).ready(function () {
    $(".button-collapse").sideNav();
    $('select').material_select();
    $('.modal-fornecedor').modal({
        ready: function (modal, trigger) {
            $.getJSON(base_url + 'Compra/get_product_info', function (json) {
            });
        }
    });
});

Compra = {
    get_fornecedores : function(p){

    }
}