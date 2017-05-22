$(document).ready(function () {
    $('.botao-comprar').click(function () {
        //Chamar ajax para buscar as informações adicionais do produto

        var idProduto = $(this).attr('IdProduto')

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

    $('.btn-detalhe-comprar').click(function () {
        $.ajax({
            url: base_url + 'Venda/ComprarProduto',
            method: 'POST'
        });
    });
});

function fecharModal()
{
    $('#modalDetalheProduto').modal('close');
}