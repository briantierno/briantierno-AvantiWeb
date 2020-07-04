//vailla js
document.addEventListener('DOMContentLoaded', function() {
    M.AutoInit();   
   var elems = document.querySelectorAll('.slider');
    var instances = M.Slider.init(elems);
    var elems = document.querySelectorAll('.dropdown-trigger2');
    var instances = M.Dropdown.init(elems, { coverTrigger: false, constrainWidth: false, closeOnClick: false, });
    var elems = document.querySelectorAll('.dropdown-trigger');
    var instances = M.Dropdown.init(elems, { coverTrigger: false });
  });

$('#menuproductos li a').click(function (e) {
    // Evitamos que se haga el scroll
    e.preventDefault();

    // Capturamos el ancla
    var ancla = $(this).attr('href');

    // Le quitamos el numeral # para solo quedarnos con el nombre de la sección
    ancla = ancla.substring(1);

    // Obtenemos la posición de la sección
    var position = $('#' + ancla).position();

    // Hacemos el efecto scroll y le restamos algunos pixeles, en este caso 180
    $('html, body').animate({ scrollTop: (position.top - 20) }, 0);
});

  // JQuery
  // $(document).ready(function () {  
// M.AutoInit();



// });