$(document).ready(function () {
    $('.botao-comprar').click(function () {
        //Chamar ajax para buscar as informações adicionais do produto

        var idProduto = $(this).attr('IdProduto');

        $.ajax({
            url: base_url + 'Venda/CarregarInfoProduto',
            method: 'GET',
            data: { idProduto: idProduto },
            success: function (data) {
                $('#modalDetalheProduto').html(data);
            }
        });

        $('#modalDetalheProduto').modal('open');
    });
});

$(document).on('click', '.btn-detalhe-comprar', function () {
    var idProduto = $(this).attr('IdProduto');

    $.ajax({
        url: base_url + 'Venda/ComprarProduto',
        method: 'POST',
        data: { idProduto: idProduto },
        success: function (data) {
            fecharModal();
            Materialize.toast(data.Message, 6000);
            animacaoCarrinho();
        }
    });
});

function fecharModal()
{
    $('#modalDetalheProduto').modal('close');
}