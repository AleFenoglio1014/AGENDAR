// Funcion para Completar la Tabla del Tipo de Empresa
function CompletarTablaTipoEmpresas() {
    VaciarFormulario();
    $.ajax({
        type: "POST",
        url: '../../ClasificacionEmpresas/BuscarTipoEmpresas',
        data: {},
        success: function (listadoTipoEmpresa) {
            $("#tbody-tipoEmpresa").empty();
            $.each(listadoTipoEmpresa, function (index, tipoEmpresa) {

                let claseEliminado = '';
                let botones = '<button type="button" onclick="BuscarTipoEmpresa(' + tipoEmpresa.clasificacionEmpresaID + ')" class="btn btn-outline-primary btn-sm" style="margin-right:5px"><i class="bi bi-pencil-square"></i> Editar</button>' +
                    '<button type="button" onclick="DesactivarActividad(' + tipoEmpresa.clasificacionEmpresaID + ',1)" class="btn btn-outline-danger btn-sm"><i class="bi bi-trash-fill"></i> Desactivar</button>';

                if (tipoEmpresa.eliminado) {
                    claseEliminado = 'table-danger';
                    botones = '<button type="button" onclick="DesactivarActividad(' + tipoEmpresa.clasificacionEmpresaID + ',0)" class="btn btn-outline-success btn-sm"><i class="bi bi-folder-symlink"></i> Activar</button>';
                }

                $("#tbody-tipoEmpresa").append('<tr class=' + claseEliminado + '>' +
                    '<td>' + tipoEmpresa.descripcion + '</td>' +
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
    $("#titulo-Modal-TipoEmpresa").text("Registrar Actividad de la Empresa");
    $("#ClasificacionEmpresaID").val(0);
    $("#exampleModal").modal("show");
}
// Funcion para Guardar la Actividad de la Empresa del Modal

function GuardarTipoEmpresa() {
    $("#Error-TipoEmpresaNombre").text("");
    let clasificacionempresaID = $('#ClasificacionEmpresaID').val();
    let guardartipoempresa = $('#TipoEmpresaNombre').val().trim();
    if (guardartipoempresa != "" && guardartipoempresa != null) {
        $.ajax({
            type: "POST",
            url: '../../ClasificacionEmpresas/GuardarTipoEmpresa',
            data: { ClasificacionEmpresaID: clasificacionempresaID, Descripcion: guardartipoempresa },
            success: function (resultado) {
                if (resultado == 0) {
                    $("#exampleModal").modal("hide");
                    CompletarTablaTipoEmpresas();
                }
                if (resultado == 2) {
                    $("#Error-TipoEmpresaNombre").text("La Actividad ingresada Ya Existe. Ingrese una Nueva Actividad");
                }
            },
            error: function (data) {
            }
        });
    }
    else {
        $("#Error-TipoEmpresaNombre").text("Debe ingresar una Actividad para la Empresa.");
    }
}
// Funcion para Buscar las Actividades de la Empresa

function BuscarTipoEmpresa(clasificacionEmpresaID) {
    $("#titulo-Modal-TipoEmpresa").text("Editar Actividad de la Empresa");
    $("#ClasificacionEmpresaID").val(clasificacionEmpresaID);
    $.ajax({
        type: "POST",
        url: '../../ClasificacionEmpresas/BuscarTipoEmpresa',
        data: { ClasificacionEmpresaID: clasificacionEmpresaID },
        success: function (tipoEmpresa) {
            $("#TipoEmpresaNombre").val(tipoEmpresa.descripcion);
            $("#exampleModal").modal("show");
        },
        error: function (data) {
        }
    });
}

//Funcion para Desactivar la Actividad

function DesactivarActividad(clasificacionempresaID, elimina) {
    if (elimina == 1) {
        var mensajeEliminar = "¿Esta seguro que quiere DESACTIVAR la Actividad?"
    } else {
        var mensajeEliminar = "¿Esta seguro que quiere ACTIVAR la Actividad?"
    }
    if (confirm(mensajeEliminar)) {
        $.ajax({
            type: "POST",
            url: '../../ClasificacionEmpresas/DesactivarActividad',
            data: { ClasificacionEmpresaID: clasificacionempresaID, Elimina: elimina },
            success: function (tipoEmpresa) {
                CompletarTablaTipoEmpresas();
            },
            error: function (data) {
            }
        });
    }
}
//Funcion para Vaciar el Formulario

function VaciarFormulario() {
    $("#ClasificacionEmpresaID").val(0);
    $("#TipoEmpresaNombre").val('');
    $("#Error-TipoEmpresaNombre").text("");
}