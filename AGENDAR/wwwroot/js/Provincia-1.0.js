// Funcion para CompletarTablasProvincias
function CompletarTablaProvincias() {
    VaciarFormulario();
    $.ajax({
        type: "POST",
        url: '../../Provincias/BuscarProvincias',
        data: {},
        success: function (listadoProvincias) {
            $("#tbody-provincias").empty();
            $.each(listadoProvincias, function (index, provincia) {

               

                $("#tbody-provincias").append('<tr class=>' +
                    '<td>' + provincia.descripcion + '</td>' +
                    
                    
                    '</tr>');
            });
        },
        error: function (data) {
        }
    });
}
//Funcion Abrir Modal

function AbrirModal() {
    $("#titulo-Modal-Provincias").text("REGISTRAR UNA NUEVA PROVINCIA");
    $("#ProvinciaID").val(0);
    $("#exampleModal").modal("show");
}
// Funcion para Guardar la Provincia del Modal

function GuardarProvincia() {
    $("#Error-ProvinciaNombre").text("");
    let provinciaID = $('#ProvinciaID').val();
    let guardarprovincia = $('#ProvinciaNombre').val().trim();
    if (guardarprovincia != "" && guardarprovincia != null) {
        $.ajax({
            type: "POST",
            url: '../../Provincias/GuardarProvincia',
            data: { ProvinciaID: provinciaID, Descripcion: guardarprovincia },
            success: function (resultado) {
                if (resultado == 0) {
                    $("#exampleModal").modal("hide");
                    CompletarTablaProvincias();
                }
                if (resultado == 2) {
                    $("#Error-ProvinciaNombre").text("La Provincia ingresada Ya Existe. Ingrese una Nueva Provincia");
                }
            },
            error: function (data) {
            }
        });
    }
    else {
        $("#Error-ProvinciaNombre").text("Debe ingresar un Nombre para la Provincia.");
    }
}
// Funcion para Buscar las Provincias


//Funcion para Vaciar el Formulario

function VaciarFormulario() {
    $("#ProvinciaID").val(0);
    $("#ProvinciaNombre").val('');
    $("#Error-ProvinciaNombre").text("");
}

// Funcion para limitar los caracteres de los input
var input = document.getElementById('ProvinciaNombre');
input.addEventListener('input', function () {
    if (this.value.length > 35)
        swal("HA SUPERADO EL LIMITE DE CARACTERES PERMITIDO.");
        this.value = this.value.slice(0, 35);

})