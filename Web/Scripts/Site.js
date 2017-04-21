var base_url = "http://localhost:62688/";
$(document).ready(function () {
    $(".button-collapse").sideNav();
    $('select').material_select();
    $('.modal-fornecedor').modal({
        ready: function (modal, trigger) {
            idProduto = $(trigger).data('id');
            $.getJSON(base_url + 'Compra/GetProductInfo/?IdProduto=' + idProduto, function (json) {
                $('.modal-fornecedor .modal-content h4').html(json.Nome);
                $('#quantidade').val('');
                $('#fornecedores option').remove();
                $('#inp-produto').val(json.IdProduto);

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
    pre_salva_item: function () {
        var prod = $('#inp-produto').val();
        $('#qtde-' + prod).val($('#quantidade').val());
        $('#forn-' + prod).val($('#fornecedores').val());
        $('#lin-' + prod + ' td:eq(4)').html($('#quantidade').val());

        $('.modal-fornecedor').modal('close');
    }
}