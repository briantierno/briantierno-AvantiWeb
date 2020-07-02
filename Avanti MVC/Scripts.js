//vailla js
document.addEventListener('DOMContentLoaded', function() {
    M.AutoInit();   
   var elems = document.querySelectorAll('.slider');
    var instances = M.Slider.init(elems);
    var elems = document.querySelectorAll('.dropdown-trigger2');
    var instances = M.Dropdown.init(elems, {coverTrigger: false, constrainWidth: false, closeOnClick: false, });



  });
  

  // JQuery
  // $(document).ready(function () {  
// M.AutoInit();



// });