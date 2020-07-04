class Carrito {

    //Añadir producto al carrito
    comprarProducto(e){
        e.preventDefault();
        //Delegado para agregar al carrito
        if(e.target.classList.contains('agregar-carrito')){
             const producto = e.target.parentElement.parentElement;
             Swal.fire({
                type: 'success',
                title: 'Perfecto!!!',
                text: 'El producto fue agregado al carrito',
                showConfirmButton: false,
                timer: 1000
            });
           // Enviamos el producto seleccionado para tomar sus datos
            this.leerDatosProducto(producto)            
        }
    }

//contar productos
contarproductos(){
                    
        document.getElementById('contador').style.display = 'initial';
        document.getElementById('arrow').style.display = 'initial'; 
        document.getElementById('contador').innerHTML = listaProductos.childNodes.length;  
        if (listaProductos.childNodes.length > 9) {
            document.getElementById('contador').style.padding = '5px 5px 5px 5px'; 
        } else
        {
            document.getElementById('contador').style.padding = ' 4px 8px 4px 8px'
        } ;   
                  
     
    if (listaProductos.childNodes.length == 0) {
        document.getElementById('contador').style.display = 'none'; 
        document.getElementById('arrow').style.display = 'none';        
    }  
    
    }

    //Leer datos del producto
    leerDatosProducto(producto){
        const infoProducto = {
            cantidad: 1,
            imagen : producto.querySelector('img').src,
            titulo: producto.querySelector('p').textContent,
            precio: producto.querySelector('span').textContent,
            id: producto.querySelector('a').getAttribute('data-id'),
           
        }
        let productosLS;
        productosLS = this.obtenerProductosLocalStorage();
        productosLS.forEach(function (productoLS){
            if(productoLS.id === infoProducto.id){
                productosLS = productoLS.id;
            }
        });

        if(productosLS === infoProducto.id){
            Swal.fire({
                type: 'warning',
                title: 'Oops...',
                text: 'El producto ya está agregado',
                showConfirmButton: false,
                timer: 1000
            })
        }
        else {
            this.insertarCarrito(infoProducto);
            this.contarproductos();

        }
        
    }

    //muestra producto seleccionado en carrito
    insertarCarrito(producto){
        const row = document.createElement('tr');
        row.innerHTML = `
        <tr>
        <td><img src="${producto.imagen}" width="40" height="40"</td>
        <td>${producto.titulo}</td>
        <td style="text-align: center; font-weight: 600;"><a id="remove" style="padding: 0px" class="material-icons black-text">remove_circle</a>&nbsp;${producto.cantidad}&nbsp;<a  id="add" style="padding: 0px" class="material-icons  black-text">add_circle</a></td>
        <td>${producto.precio} </td>
        <td><span class="material-icons borrar-producto" data-id="${producto.id}">delete</span></td>
        </tr> 
        `;
        listaProductos.appendChild(row);
        this.guardarProductosLocalStorage(producto);
        this.calcularTotal(); 

    }

    //Eliminar el producto del carrito en el DOM
    eliminarProducto(e){
        e.preventDefault();
        let producto, productoID;
        if(e.target.classList.contains('borrar-producto')){
            e.target.parentElement.parentElement.remove();
            producto = e.target.parentElement.parentElement;
            productoID = producto.querySelector('span').getAttribute('data-id');
        }
        this.eliminarProductoLocalStorage(productoID);
        this.contarproductos();
        this.calcularTotal();
        $('.dropdown-trigger2').dropdown('recalculateDimensions');

    }

    //Elimina todos los productos
    vaciarCarrito(e){
        e.preventDefault();
        while(listaProductos.firstChild){
            listaProductos.removeChild(listaProductos.firstChild);
        }
        this.vaciarLocalStorage();
        document.getElementById('contador').style.display = 'none';
        $('.dropdown-trigger2').dropdown('close');

        return false;
    }

    //Almacenar en el LS
    guardarProductosLocalStorage(producto){
        let productos;
        //Toma valor de un arreglo con datos del LS
        productos = this.obtenerProductosLocalStorage();
        //Agregar el producto al carrito
        productos.push(producto);
        //Agregamos al LS
        localStorage.setItem('productos', JSON.stringify(productos));
    }

    //Comprobar que hay elementos en el LS
    obtenerProductosLocalStorage(){
        let productoLS;

        //Comprobar si hay algo en LS
        if(localStorage.getItem('productos') === null){
            productoLS = [];
        }
        else {
            productoLS = JSON.parse(localStorage.getItem('productos'));
        }
        return productoLS;
    }

    //Mostrar los productos guardados en el LS
    leerLocalStorage(){
        let productosLS;
        productosLS = this.obtenerProductosLocalStorage();
        productosLS.forEach(function (producto){
            //Construir plantilla
            const row = document.createElement('tr');
            row.innerHTML = `
        <tr>
        <td><img src="${producto.imagen}" width="40" height="40"</td>
        <td>${producto.titulo}</td>
        <td style="text-align: center"><a id="remove" style="padding: 0px" class="material-icons black-text">remove_circle</a>${producto.cantidad}<a  id="add" style="padding: 0px" class="material-icons  black-text">add_circle</a></td>
        <td>${producto.precio} </td>
        <td><span class="material-icons borrar-producto" data-id="${producto.id}">delete</span></td>
        </tr> 
            `;
            listaProductos.appendChild(row);
        });
    }

    //Mostrar los productos guardados en el LS en compra.html
    leerLocalStorageCompra(){
        let productosLS;
        productosLS = this.obtenerProductosLocalStorage();
        productosLS.forEach(function (producto){
            const row = document.createElement('tr');
            row.innerHTML = `
            <tr>
            <td><img src="${producto.imagen}" width="40" height="40"</td>
            <td>${producto.titulo}</td>
            <td style="text-align: center"><a id="remove" style="padding: 0px" class="material-icons black-text">remove_circle</a>${producto.cantidad}<a  id="add" style="padding: 0px" class="material-icons  black-text">add_circle</a></td>
            <td>${producto.precio} </td>
            <td><span class="material-icons borrar-producto" data-id="${producto.id}">delete</span></td>
            </tr> 
            `;
            listaCompra.appendChild(row);
        });
    }

    //Eliminar producto por ID del LS
    eliminarProductoLocalStorage(productoID){
        let productosLS;
        //Obtenemos el arreglo de productos
        productosLS = this.obtenerProductosLocalStorage();
        //Comparar el id del producto borrado con LS
        productosLS.forEach(function(productoLS, index){
            if(productoLS.id === productoID){
                productosLS.splice(index, 1);
            }
        });

        //Añadimos el arreglo actual al LS
        localStorage.setItem('productos', JSON.stringify(productosLS));
        
    }

    //Eliminar todos los datos del LS
    vaciarLocalStorage(){
        localStorage.clear();
    }

    //Procesar pedido
    procesarPedido(e){
        e.preventDefault();

        if(this.obtenerProductosLocalStorage().length === 0){
            Swal.fire({
                type: 'error',
                title: 'Oops...',
                text: 'El carrito está vacío, agrega algún producto',
                showConfirmButton: false,
                timer: 2000
            })
        }
        else {
            location.href = "compra.html";
        }
    }

    //Calcular montos
    calcularTotal(){
        let productosLS;
        let total = 0; //igv = 0, subtotal = 0;
        productosLS = this.obtenerProductosLocalStorage();
        for(let i = 0; i < productosLS.length; i++){
            let element = Number(productosLS[i].precio * productosLS[i].cantidad);
          document.querySelector('[data-id="' + productosLS[i].id + '"]').parentNode.previousElementSibling.innerHTML= element;
            total = total + element;
            
        }
        
        // igv = parseFloat(total * 0.18).toFixed(2);
        // subtotal = parseFloat(total-igv).toFixed(2);
        
       // document.getElementById('total').value = "$ " + total;
        document.getElementById('spantotal').innerHTML = total;
    }

    // aumentar la cantidad de cada producto

    modificarcantidad(e){
        e.preventDefault();
        let producto = e.target.parentElement.parentElement;
        let id = producto.querySelector('span').getAttribute('data-id');
        let productosLS = this.obtenerProductosLocalStorage();
        
        if(e.target.id == 'add'){ 
            
            productosLS.forEach(function (productoLS) {
                if (productoLS.id === id) {
                    productoLS.cantidad += 1;                      
                    (e.target.previousSibling.textContent) = productoLS.cantidad;                                        
                }                                             
            });
        };

            if(e.target.id == 'remove'){ 

                productosLS.forEach(function (productoLS) {
                    if (productoLS.id === id) {                                               
                        if (productoLS.cantidad == 1) {
                            Swal.fire({
                                type: 'warning',
                                title: 'Oops...',
                                text: 'No puedes comprar menos de 1 unidad',
                                showConfirmButton: false,
                                timer: 1000})
                        } else {   
                            productoLS.cantidad += -1; 
                            (e.target.nextSibling.textContent) = productoLS.cantidad;
                       }
                    }                                             
                });
    
            };
            
            localStorage.setItem('productos', JSON.stringify(productosLS));
        }

        
            // let producto, productoID;
            // if(e.target.classList.contains('borrar-producto')){
            //     e.target.parentElement.parentElement.remove();
            //     producto = e.target.parentElement.parentElement;
            //     productoID = producto.querySelector('span').getAttribute('data-id');
            // }


    

    


    obtenerEvento(e) {
        e.preventDefault();
        let id, cantidad, producto, productosLS;
        if (e.target.classList.contains('cantidad')) {
            producto = e.target.parentElement.parentElement;
            id = producto.querySelector('a').getAttribute('data-id');
            cantidad = producto.querySelector('input').value;
            let actualizarMontos = document.querySelectorAll('#subtotales');
            productosLS = this.obtenerProductosLocalStorage();
            productosLS.forEach(function (productoLS, index) {
                if (productoLS.id === id) {
                    productoLS.cantidad = cantidad;                    
                    actualizarMontos[index].innerHTML = Number(cantidad * productosLS[index].precio);
                }    
            });
            localStorage.setItem('productos', JSON.stringify(productosLS));
            
        }
        else {
            console.log("click afuera");
        }
    }
    
}
