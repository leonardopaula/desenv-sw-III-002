$(document).ready(function () {
    $(".button-collapse").sideNav();
    $('select').material_select();
    $('.modal').modal();
});

var animacaoRodando = false;

function animacaoCarrinho()
{
    var carrinho = $('.menu-shopping-cart i');

    if (!animacaoRodando)
    {
        animacaoRodando = true;
        var backgroundInterval = setInterval(function () {
            carrinho.toggleClass('yellow-text');
        }, 1500);
    }
}