ListagemPendentesDeEnvio = {

    enviar: function () {
        var pedidosSelecionados = $('#selecionar');
        var idsPedidos = "";
        for (var i = 0; i < pedidosSelecionados.length; i++) {
            idsPedidos = idsPedidos + "," + pedidosSelecionados[i].value;
        }
        console.log(idsPedidos);

        $.post(base_url + 'Faturamento/Enviar'
              , { pedidos: idsPedidos }
              , function (json) {
                  if (json.Situacao) {
                      document.location = base_url + 'Faturamento/ListagemPendentesEnvio/';
                  } else {

                      var msg = 'Verifique:\n';
                      $.each(json, function (k, v) {
                          msg += v.Mensagem;
                      });

                      Materialize.toast(msg, 4000);
                  }
              });
    }
}