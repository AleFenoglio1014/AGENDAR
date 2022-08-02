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

 
                let botones = '<button type="button" onclick="BuscarProvincia(' + provincia.provinciaID + ')" class="btn btn-outline-primary btn-sm" style="margin-right:5px"><i class="bi bi-pencil-square"></i> Editar</button>';

                

                $("#tbody-provincias").append('<tr class=>' +
                    '<td>' + provincia.descripcion + '</td>' +
                    '<td class="text-center">' +
                    botones +
                    '</td>' +
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

function BuscarProvincia(provinciaID) {
    $("#titulo-Modal-Provincias").text("EDITAR PROVINCIA");
    $("#ProvinciaID").val(provinciaID);
    $.ajax({
        type: "POST",
        url: '../../Provincias/BuscarProvincia',
        data: { ProvinciaID: provinciaID },
        success: function (provincia) {
            $("#ProvinciaNombre").val(provincia.descripcion);
            $("#exampleModal").modal("show");
        },
        error: function (data) {
        }
    });
}
//Funcion para Vaciar el Formulario

function VaciarFormulario() {
    $("#ProvinciaID").val(0);
    $("#ProvinciaNombre").val('');
    $("#Error-ProvinciaNombre").text("");
}