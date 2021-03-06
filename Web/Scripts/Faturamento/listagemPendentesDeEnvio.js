﻿ListagemPendentesDeEnvio = {

    enviar: function () {
        var pedidosSelecionados = $('#selecionar');
        var idsPedidos = "";
        for (var i = 0; i < pedidosSelecionados.length; i++) {
            idsPedidos = idsPedidos + "," + pedidosSelecionados[i].value;
        }
        
        $.post(base_url + 'Faturamento/Enviar'
              , { pedidos: idsPedidos }
              , function (json) {
                  if (json.Situacao) {
                      document.location = base_url + 'Faturamento/ListagemEmissaoDocTransporte/';
                  } else {

                      var msg = 'Verifique:\n ' + json.Mensagem;
                     
                      Materialize.toast(msg, 4000);
                  }
              });
    }
}