// Funcion para Completar la Tabla del Tipo de Profesional
function CompletarTablaTipoProfesionales() {
    VaciarFormulario();
    $.ajax({
        type: "POST",
        url: '../../ClasificacionProfesionales/BuscarTipoProfesionales',
        data: {},
        success: function (listadoTipoProfesional) {
            $("#tbody-tipoProfesional").empty();
            $.each(listadoTipoProfesional, function (index, tipoProfesional) {

                let claseEliminado = '';
                let botones = '<button type="button" onclick="BuscarTipoProfesional(' + tipoProfesional.clasificacionProfesionalID + ')" class="btn btn-outline-primary btn-sm" style="margin-right:5px"><i class="bi bi-pencil-square"></i> Editar</button>' 
                //    '<button type="button" onclick="DesactivarActividad(' + tipoProfesional.clasificacionProfesionalID + ',1)" class="btn btn-outline-danger btn-sm"><i class="bi bi-trash-fill"></i> Desactivar</button>';

                //if (tipoProfesional.eliminado) {
                //    claseEliminado = 'table-danger';
                //    botones = '<button type="button" onclick="DesactivarActividad(' + tipoProfesional.clasificacionProfesionalID + ',0)" class="btn btn-outline-success btn-sm"><i class="bi bi-folder-symlink"></i> Activar</button>';
                //}

                $("#tbody-tipoProfesional").append('<tr class=' + claseEliminado + '>' +
                    '<td>' + tipoProfesional.descripcion + '</td>' +
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
    $("#titulo-Modal-TipoProfesional").text("Registrar Actividad del Profesional");
    $("#ClasificacionProfesionalID").val(0);
    $("#exampleModal").modal("show");
}
// Funcion para Guardar la Actividad del Profesional del Modal

function GuardarTipoProfesional() {
    $("#Error-TipoProfesionalNombre").text("");
    let clasificacionProfesionalID = $('#ClasificacionProfesionalID').val();
    let guardartipoprofesional = $('#TipoProfesionalNombre').val().trim();
    if (guardartipoprofesional != "" && guardartipoprofesional != null) {
        $.ajax({
            type: "POST",
            url: '../../ClasificacionProfesionales/GuardarTipoProfesional',
            data: { ClasificacionProfesionalID: clasificacionProfesionalID, Descripcion: guardartipoprofesional },
            success: function (resultado) {
                if (resultado == 0) {
                    $("#exampleModal").modal("hide");
                    CompletarTablaTipoProfesionales();
                }
                if (resultado == 2) {
                    $("#Error-TipoProfesionalNombre").text("La Actividad ingresada Ya Existe. Ingrese una Nueva Actividad");
                }
            },
            error: function (data) {
            }
        });
    }
    else {
        $("#Error-TipoProfesionalNombre").text("Debe ingresar una Actividad para el Profesional.");
    }
}
// Funcion para Buscar las Actividades del Profesional

function BuscarTipoProfesional(clasificacionProfesionalID) {
    $("#titulo-Modal-TipoProfesional").text("Editar Actividad del Profesional");
    $("#ClasificacionProfesionalID").val(clasificacionProfesionalID);
    $.ajax({
        type: "POST",
        url: '../../ClasificacionProfesionales/BuscarTipoProfesional',
        data: { ClasificacionProfesionalID: clasificacionProfesionalID },
        success: function (tipoProfesional) {
            $("#TipoProfesionalNombre").val(tipoProfesional.descripcion);
            $("#exampleModal").modal("show");
        },
        error: function (data) {
        }
    });
}

////Funcion para Desactivar la Actividad

//function DesactivarActividad(clasificacionProfesionalID, elimina) {
//    if (elimina == 1) {
//        var mensajeEliminar = "¿Esta seguro que quiere DESACTIVAR la Actividad?"
//    } else {
//        var mensajeEliminar = "¿Esta seguro que quiere ACTIVAR la Actividad?"
//    }
//    if (confirm(mensajeEliminar)) {
//        $.ajax({
//            type: "POST",
//            url: '../../ClasificacionProfesionales/DesactivarActividad',
//            data: { ClasificacionProfesionalID: clasificacionProfesionalID, Elimina: elimina },
//            success: function (tipoEmpresa) {
//                CompletarTablaTipoProfesionales();
//            },
//            error: function (data) {
//            }
//        });
//    }
//}
//Funcion para Vaciar el Formulario

function VaciarFormulario() {
    $("#ClasificacionProfesionalID").val(0);
    $("#TipoProfesionalNombre").val('');
    $("#Error-TipoProfesionalNombre").text("");
}