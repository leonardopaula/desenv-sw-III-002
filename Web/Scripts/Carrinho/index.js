$(document).ready(function () {
    $('#radCartao, #radBoleto').change(function () {
        $('.dadosCartao').toggleClass('hide');
    });
});

$(document).on('click', '.botao-login', function () {
    var login = $('#login').val();
    var senha = $('#senha').val();

    if (login && senha) {
        $.ajax({
            url: base_url + 'Cliente/Login',
            type: 'POST',
            data: { login: login, senha: senha },
            success: function (data) {
                debugger;
                if (data && data == 'True') {
                    location.reload();
                }
                else {
                    Materialize.toast('Login ou Senha incorreta', 4000);
                }
            }
        });
    } else {
        Materialize.toast('Preencher os dados de login', 3000);
    }
});

$('#login, #senha').keypress(function (e) {
    var code = e.keyCode || e.which;
    if (code == 13) {
        $('.botao-login').click();
    }
});

$('#cidade').keyup(function () {
    var prefix = $(this).val();

    var arrayCidades = {};

    if (prefix.length >= 3) {
        $.ajax({
            url: base_url + 'Carrinho/BuscaCidades',
            type: 'GET',
            data: { prefix: prefix },
            async: false,
            success: function (data) {
                if (data) {
                    for (var i = 0; i < data.length; i++) {
                        arrayCidades[data[i].Nome] = null;
                    }
                }
            }
        })
    }

    $('#cidade').autocomplete({
        data: arrayCidades,
        limit: 10
    });
});

$(document).on('click', '#btnCalcularFrete', function () {
    var formaEntrega = $('#formaEntrega').val();
    var cep = $('#cep').val();
    
    if (!validaCamposEndereco()) {
        Materialize.toast('Preencher os dados de entrega', 3000);
    }
    else {
        $.ajax({
            url: base_url + 'Carrinho/CalculaPrazo',
            type: 'POST',
            data: { cdServico: formaEntrega, cepDestino: cep },
            success: function (data) {
                if (data[0]) {
                    $('#valorFrete').val(data[0].preco);
                    $('#precoPrazo').html('O prazo de entrega é de ' + data[0].prazo + ' dia(s) úteis. <br />O valor do frete é de R$ ' + data[0].preco + '.');
                }
            }
        });
    }
});

$(document).on('click', '#btnFinalizarCompra', function (e) {
    e.preventDefault();

    $('#btnFinalizarCompra').attr('disabled', 'disabled');
    $('#btnFinalizarCompra').addClass('disabled');
    
    if (!validaCamposEndereco()) {
        Materialize.toast('Preencher os dados de entrega', 3000);
    } else if (!validaCamposPagamento()) {
        Materialize.toast('Preencher os dados de pagamento', 3000);
    } else if (!validaFrete()) {
        Materialize.toast('Calcule o frete antes de continuar', 3000);
    } else {
        var formaEntrega = $('#formaEntrega').val();
        var cep = $('#cep').val();
        var endereco = $('#endereco').val();
        var numero = $('#numero').val();
        var meioPagamento = $('input[name=MeioPagamento]:checked').val();
        var numeroCartao = $('#numeroCartao').val();
        var mesValidade = $('#mesValidade').val();
        var anoValidade = $('#anoValidade').val();
        var codSeguranca = $('#codSeguranca').val();
        var valorFrete = $('#valorFrete').val();
        var complemento = $('#complemento').val();
        var bairro = $('#bairro').val();
        var Cidade = $('#cidade').val();

        $.ajax({
            url: base_url + 'Carrinho/FinalizarPedido',
            type: 'POST',
            data: {
                FormaEntrega: formaEntrega,
                CEP: cep,
                Endereco: endereco,
                Numero: numero,
                Complemento: complemento,
                Cidade: Cidade,
                Bairro: bairro,
                MeioPagamento: meioPagamento,
                NumeroCartao: numeroCartao,
                MesValidade: mesValidade,
                AnoValidade: anoValidade,
                CodSeguranca: codSeguranca,
                ValorFrete: valorFrete
            },
            success: function (data) {
                if (data.CodRetorno == 'sucesso') {
                    Materialize.toast(data.Mensagem, 4000, '', function () { window.location.href = base_url + 'Carrinho/Resumo'; });
                }
                else if (data.CodRetorno == 'aviso')
                {
                    $('#btnFinalizarCompra').removeAttr('disabled');
                    $('#btnFinalizarCompra').removeClass('disabled');
                    Materialize.toast(data.Mensagem, 4000);
                }
                else
                {
                    Materialize.toast(data.Mensagem, 4000, '', function () { window.location.href = base_url; });
                }
            }
        });
    }
});

$(document).on('click', '#btnConfirmaCompra', function () {

    $('#btnConfirmaCompra').attr('disabled', 'disabled');
    $('#btnConfirmaCompra').addClass('disabled');

    $.ajax({
        url: base_url + 'Carrinho/ConfirmarCompra',
        type: 'POST',
        success: function (data) {
            console.log(data);
            if (data == 'True')
            {
                Materialize.toast('Compra efetuada com sucesso', 4000, '', function () { window.location.href = base_url; });
            }
            else
            {
                Materialize.toast('Um erro fatal ocorreu durante a compra', 4000, '', function () { window.location.href = base_url; });
            }
        }
    });
});

function validaCamposEndereco() {
    var formaEntrega = $('#formaEntrega').val();
    var cep = $('#cep').val();
    var endereco = $('#endereco').val();
    var numero = $('#numero').val();
    var bairro = $('#bairro').val();
    var Cidade = $('#cidade').val();

    return (formaEntrega && cep && endereco && numero && bairro && Cidade);
}

function validaCamposPagamento() {
    var meioPagamento = $('input[name=MeioPagamento]:checked').val();

    if (meioPagamento == '2') {
        var numeroCartao = $('#numeroCartao').val();
        var mesValidade = $('#mesValidade').val();
        var anoValidade = $('#anoValidade').val();
        var codSeguranca = $('#codSeguranca').val();

        return (numeroCartao && mesValidade && anoValidade && codSeguranca);
    }
    
    return true;
}

function validaFrete() {
    var valorFrete = $('#valorFrete').val();

    return valorFrete;
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