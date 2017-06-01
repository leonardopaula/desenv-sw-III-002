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

$(document).on('click', '.botao-login', function () {
    var login = $('#login').val();
    var senha = $('#senha').val();

    if (login && senha)
    {
        $.ajax({
            url: base_url + 'Cliente/Login',
            type: 'POST',
            data: { login: login, senha: senha },
            success: function (data) {
                debugger;
                if (data && data == 'True')
                {
                    location.reload();
                }
                else
                {
                    Materialize.toast('Login ou Senha incorreta', 4000);
                }
            }
        });
    } else {
        Materialize.toast('Preencher os dados de login', 3000);
    }
});