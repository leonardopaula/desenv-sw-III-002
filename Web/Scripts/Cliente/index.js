
CadastroCliente = {

    salvar_cliente: function () {
        console.log("Entrou");
        var nomeCliente = $('#Nome').val();
        var emailCliente = $('#Email').val();
        var loginCliente = $('#Login').val();
        var senhaCliente = $('#Senha').val();
        var rgCliente = $('#Rg').val();
        var cpfCliente = $('#Cpf').val();
        $.post(base_url + 'Cliente/Salvar'
              , { nome: nomeCliente, email: emailCliente, login: loginCliente, senha: senhaCliente, rg: rgCliente, cpf: cpfCliente }
              , function (json) {
                  if (json.Situacao) {
                      document.location = base_url + 'Home/Index/';
                  } else {

                      var msg = 'Verifique:\n';
                      $.each(json, function (k, v) {
                          msg += v.Mensagem;
                      });

                      Materialize.toast(msg, 4000);
                  }
              });


    },

    cancelar: function () {
        document.location = base_url + 'Home/Index/';
    }
}