$(document).ready(function () {
    $(".button-collapse").sideNav();
    $('select').material_select();
    $('.modal').modal();
});



function animacaoCarrinho()
{
    var carrinho = $('.menu-shopping-cart i');
    var backgroundInterval = setInterval(function () {
        carrinho.toggleClass('yellow-text');
    }, 1500)

}