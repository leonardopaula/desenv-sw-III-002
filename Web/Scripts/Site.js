var base_url = "http://localhost:62688/";
$(document).ready(function () {
    $(".button-collapse").sideNav();
    $('select').material_select();
    $('.modal-fornecedor').modal({
        ready: function (modal, trigger) {
            idProduto = $(trigger).data('id');
            $.getJSON(base_url + 'Compra/GetProductInfo/?IdProduto=' + idProduto, function (json) {
                $('.modal-fornecedor .modal-content h4').html(json.Nome);
                $('#fornecedores option').remove();
                var options = '<option>Selecione</option>';
                $.each(json.Fornecedores, function (i, o) {
                    options += '<option value="' + o.IdFornecedor + '">' + o.Nome + '</option>';
                });

                $('#fornecedores').html(options).material_select();
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