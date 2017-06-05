$(document).ready(function () {
    $('#radCartao, #radBoleto').change(function () {
        $('.dadosCartao').toggleClass('hide');
    });
});

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

$(document).on('click', '#btnCalcularFrete', function () {
    var formaEntrega = $('#formaEntrega').val();
    var cep = $('#cep').val();
    
    if (!validaCamposEndereco())
    {
        Materialize.toast('Preencher os dados de entrega', 3000);
    }
    else
    {
        $.ajax({
            url: base_url + 'Carrinho/CalculaPrazo',
            type: 'POST',
            success: function (data)
            {
                console.log(data);
            }
        })
    }
});


function validaCamposEndereco()
{
    var formaEntrega = $('#formaEntrega').val();
    var cep = $('#cep').val();
    var endereco = $('#endereco').val();
    var numero = $('#numero').val();

    return (formaEntrega && cep && endereco && numero);
}

function removerProdutos(idProduto) {
    $.ajax({
        url: base_url + 'Carrinho/RemoverProdutos',
        type: 'POST',
        data: { idProduto: idProduto },
        success: function () {
            location.reload();
        }
    });
}