$(document).ready(function () {
    $('#modal-relatorio').modal({
        ready: function (modal, trigger) {
            Compra.relatorio();
        }
    });
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

ListagemNaoRecebidas = {

    receber_notafiscal: function (idCompra) {
        document.location = base_url + 'Compra/ReceberNotaFiscal/?IdCompra=' + idCompra;
    },

    confirmar_recebimento: function (idCompra) {
        document.location = base_url + 'Compra/ConfirmarRecebimento/?IdCompra=' + idCompra;
    }
}