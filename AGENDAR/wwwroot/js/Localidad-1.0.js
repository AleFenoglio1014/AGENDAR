// Funcion para Completar la Tabla de Localidades
function CompletarTablaLocalidades() {
    VaciarFormulario();
    $.ajax({
        type: "POST",
        url: '../../Localidades/BuscarLocalidades',
        data: {},
        success: function (listadoLocalidadesMostrar) {
            $("#tbody-localidades").empty();
            $.each(listadoLocalidadesMostrar, function (index, localidad) {

                let claseEliminado = '';
                let botones = '<button type="button" onclick="BuscarLocalidad(' + localidad.localidadID + ',' + localidad.provinciaID + ')" class="btn btn-outline-primary btn-sm" style="margin-right:5px"><i class="bi bi-pencil-square"></i> Editar</button>' +
                    '<button type="button" onclick="DesactivarLocalidad(' + localidad.localidadID + ',1)" class="btn btn-outline-danger btn-sm"><i class="bi bi-trash-fill"></i> Desacctivar</button>';

                if (localidad.eliminado) {
                    claseEliminado = 'table-danger';
                    botones = '<button type="button" onclick="DesactivarLocalidad(' + localidad.localidadID + ',0)" class="btn btn-outline-success btn-sm"><i class="bi bi-folder-symlink"></i> Activar</button>';
                }

                $("#tbody-localidades").append('<tr class=' + claseEliminado + '>' +
                    '<td>' + localidad.descripcion + '</td>' +
                    '<td>' + localidad.provinciaNombre + '</td>' +
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
    $("#titulo-Modal-Localidades").text("Registrar una Nueva Localidad");
    $("#LocalidadID").val(0);
    $("#exampleModal").modal("show");
}
// FUncion para Guardar las Localidades
function GuardarLocalidad() {
    $("#Error-LocalidadNombre").text("");
    let localidadID = $('#LocalidadID').val();
    let guardarlocalidad = $('#LocalidadNombre').val().trim();
    let provinciaID = $('#ProvinciaID').val();
    if (guardarlocalidad != "" && guardarlocalidad != null) {
        $.ajax({
            type: "POST",
            url: '../../Localidades/GuardarLocalidad',
            data: { LocalidadID: localidadID, Descripcion: guardarlocalidad, ProvinciaID: provinciaID },
            success: function (resultado) {
                if (resultado == 0) {
                    $("#exampleModal").modal("hide");
                    CompletarTablaLocalidades();
                }
                if (resultado == 2) {
                    $("#Error-LocalidadNombre").text("La Localidad ingresada Ya Existe. Ingrese una Nueva Localidad");
                }
            },
            error: function (data) {
            }
        });
    }
    else {
        $("#Error-LocalidadNombre").text("Debe ingresar un Nombre para la Localidad.");
    }
}
// Funcion para Buscar las Localidades

function BuscarLocalidad(localidadID, provinciaID) {
    $("#titulo-Modal-Localidades").text("Editar Localidad");
    $("#LocalidadID").val(localidadID);
    $("#ProvinciaID").val(provinciaID);
    $.ajax({
        type: "POST",
        url: '../../Localidades/BuscarLocalidad',
        data: { LocalidadID: localidadID },
        success: function (localidad) {
            $("#LocalidadNombre").val(localidad.descripcion);
            $("#exampleModal").modal("show");
        },
        error: function (data) {
        }
    });
}

//Funcion para Vaciar el Formulario

function VaciarFormulario() {
    $("#LocalidadID").val(0);
    $("#ProvinciaID").val(0);
    $("#LocalidadNombre").val('');
    $("#Error-LocalidadNombre").text("");
}
//Funcion para Desactivar la Localidad

function DesactivarLocalidad(localidadID, elimina) {
    if (elimina == 1) {
        var mensajeEliminar = "¿Esta seguro que quiere DESACTIVAR la Localidad?"
    } else {
        var mensajeEliminar = "¿Esta seguro que quiere ACTIVAR la Localidad?"
    }
    if (confirm(mensajeEliminar)) {
        $.ajax({
            type: "POST",
            url: '../../Localidades/DesactivarLocalidad',
            data: { LocalidadID: localidadID, Elimina: elimina },
            success: function (localidad) {
                CompletarTablaLocalidades();
            },
            error: function (data) {
            }
        });
    }
}