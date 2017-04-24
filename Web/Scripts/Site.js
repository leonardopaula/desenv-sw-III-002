var base_url = "http://localhost:62688/";
$(document).ready(function () {
    $(".button-collapse").sideNav();
    $('select').material_select();
    $('#modal-relatorio').modal({
        ready: function (modal, trigger) {
            Compra.relatorio();
        }
    });
    $('.modal-fornecedor').modal({
        ready: function (modal, trigger) {
            idProduto = $(trigger).data('id');
            $.getJSON(base_url + 'Compra/GetProductInfo/?IdProduto=' + idProduto, function (json) {
                $('.modal-fornecedor .modal-content h4').html(json.Nome);
                $('#quantidade').val('');
                $('#fornecedores option').remove();
                $('#inp-produto').val(json.IdProduto);

                var options = '<option>Selecione</option>';
                $.each(json.Fornecedores, function (i, o) {
                    options += '<option value="' + o.IdFornecedor + '">' + o.Nome + '</option>';
                });

                $('#fornecedores').html(options).material_select();
            });
        }
    });
});

Compra = {
    pre_salva_item: function () {
        var prod = $('#inp-produto').val();
        $('#qtde-' + prod).val($('#quantidade').val());
        $('#forn-' + prod).val($('#fornecedores').val());
        $('#lin-' + prod + ' td:eq(4)').html($('#quantidade').val());
        $('#fnome-' + prod).val($('#fornecedores option[value="' + $('#fornecedores').val() + '"]').html());

        $('.modal-fornecedor').modal('close');
    },

    relatorio: function () {
        tbl = '';
        $('table:eq(0) tbody tr').each(function (k, v) {
            console.log($(v));
            id = $(v).attr('id').replace('lin-', '');
            if ($('#forn-' + id).val() != "")
            {
                tbl += '<tr>';
                tbl += '<td>' + $('#lin-' + id + ' td:eq(2)').html() + '</td>';
                tbl += '<td>' + $('#qtde-' + id).val() + '</td>';
                tbl += '<td>' + $('#fnome-' + id).val() + '</td>';
                tbl += '</tr>';
            }
        });
        $('#modal-relatorio table tbody').html(tbl);
    },

    salva_pedido: function () {
        $.post(base_url + 'Compra/Salva'
              , $('form:eq(0)').serialize()
              , function (json) {
                  if (json.IdCompra != undefined)
                  {
                      document.location = base_url + 'Compra/Relatorio/?IdCompra=' + json.IdCompra;
                  } else {

                      var msg = 'Verifique:\n';
                      $.each(json, function (k, v) {
                          msg += v.Referencia + ': ' + v.Mensagem;
                      });

                      alert(msg);
                      $('#modal-relatorio').modal('close');
                  }
              });
    }
}