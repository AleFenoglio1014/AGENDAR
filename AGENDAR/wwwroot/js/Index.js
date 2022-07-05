
// Funcion para Completar la Tabla de Empresas
function BuscarUltimasEmpresas() {
   
    $.ajax({
        type: "POST",
        url: '../../Empresas/BuscarUltimasEmpresas',
        data: {},
        success: function (listadoUltimasEmpresa) {
            $.each(listadoUltimasEmpresa, function (i, empresa) {
                $('#empresa').append("<div class='col mb-4'>" +
                    "<div class='card h-100'>" +
                    "<img class='card-img-top card-alto' src='data:image/jpeg;base64," + empresa.ImagenEmpresaString + "' />" +
                    "<div class='card-body'>" +
                    "<h3 class='card-title'>" + empresa.razonSocial + "</h5>" +
                    "</div>" +
                    "<div class='card-footer'>" +
                    
                    "<small class='text-muted text-uppercase'>" + 'Ciudad: '  + empresa.localidadNombre + "</small>" +
                    "</div>" +
                    "</div>" +
                    "</div>"
                );
            });
        },
        error: function (result) {
            alert("error success de carga de empresa principal.");
        }
    });
}

