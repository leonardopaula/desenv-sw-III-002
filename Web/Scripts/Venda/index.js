$(document).ready(function () {
    $('.botao-comprar').click(function () {
        //Chamar ajax para buscar as informações adicionais do produto
        $('#modalDetalheProduto').modal('open');
    });

    $('.btn-detalhe-comprar').click(function () {
        $.ajax({
            url: base_url + 'Venda/ComprarProduto',
            method: 'POST'
        });
    });
});