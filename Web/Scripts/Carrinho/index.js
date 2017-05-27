function removerProdutos(idProduto)
{
    $.ajax({
        url: base_url + 'Carrinho/RemoverProdutos',
        type: 'POST',
        data: { idProduto: idProduto },
        success: function () {
            location.reload();
        }
    });
}