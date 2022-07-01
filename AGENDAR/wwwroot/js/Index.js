
// Funcion para Completar la Tabla de Empresas
function CompletarTablaEmpresas() {
    $('#tituloNoticia').empty();
    $('#bodyNoticia').empty();
    $.ajax({
        type: "POST",
        url: '../../Empresas/BuscarEmpresas',
        data: {},
        success: function (listadoEmpresasMostrar) {
            $.each(listadoEmpresasMostrar, function (index, empresa) {
                $('#razonSocialEmpresa').append(empresa.razonSocial); 
                
                $("#body-empresa").append("<div>" +
                    "<hr class='hrEmpresa'/>" +
                    "<p class='localidadTamaño'>" + 'Ciudad: ' + empresa.localidadNombre + "</p>" +
                    "</div>" 
                );
            });
        },
        error: function (data) {
        }
    });
}

