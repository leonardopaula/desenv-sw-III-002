﻿$(document).ready(function () {
    console.log("ta ok");
    $('#modal-informar-divergencia').modal({
        ready: function (modal, trigger) {
            console.log("chamou a funcao");
            idCompra = $(trigger).data('id');
            $.getJSON(base_url + 'Compra/GetProdutosDaCompra/?idCompra=' + idCompra, function (json) {
                $('#produtos option').remove();
                $('#inp-compra').val(idCompra);

                var options = '<option>Selecione</option>';
                $.each(json.produtos, function (i, o) {
                    options += '<option value="' + o.IdProduto + '">' + o.Nome + '</option>';
                });

                $('#produtos').html(options).material_select(); 
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
    },

    informar_divergencia: function () {
        var idCompra = $('#inp-compra').val();
        var qtdAguardada = $('#quantidadeAguardada').val();
        var qtdRecebida = $('#quantidadeRecebida').val();
        var produtoSelecionado = $('#produtos option[value="' + $('#produtos').val() + '"]').html();
        $.post(base_url + 'Compra/InformarDivergencia'
              , {idCompra: idCompra, produto: produtoSelecionado, quantidadeEsperada: qtdAguardada, quantidadeRecebida: qtdRecebida}
              , function (json) {
                  if (json.IdCompra != undefined) {
                      document.location = base_url + 'Compra/ListagemNaoRecebidas/';
                  } else {

                      var msg = 'Verifique:\n';
                      $.each(json, function (k, v) {
                          msg += v.Referencia + ': ' + v.Mensagem;
                      });

                      Materialize.toast(msg, 4000);
                      $('#modal-informar-divergencia').modal('close');
                  }
              });
    }
    //GetProdutosDaCompra
}