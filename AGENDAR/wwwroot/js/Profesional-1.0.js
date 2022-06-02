// Funcion para Completar la Tabla de Profesionales
function CompletarTablaProfesionales() {
    VaciarFormulario();
    $.ajax({
        type: "POST",
        url: '../../Profesionales/BuscarProfesionales',
        data: {},
        success: function (listadoProfesionalesMostrar) {
            $("#tbody-profesional").empty();
            $.each(listadoProfesionalesMostrar, function (index, profesional) {

                let claseEliminado = '';
                let botones = '<button type="button" onclick="BuscarProfesional(' + profesional.profesionalID + ',' + profesional.empresaID + ')" class="btn btn-outline-primary btn-sm" style="margin-right:5px"><i class="bi bi-pencil-square"></i> Editar</button>' +
                    '<button type="button" onclick="DesactivarProfesional(' + profesional.profesionalID + ',1)" class="btn btn-outline-danger btn-sm"><i class="bi bi-trash-fill"></i> Desacctivar</button>';

                if (profesional.eliminado) {
                    claseEliminado = 'table-danger';
                    botones = '<button type="button" onclick="DesactivarProfesional(' + profesional.profesionalID + ',0)" class="btn btn-outline-success btn-sm"><i class="bi bi-folder-symlink"></i> Activar</button>';
                }

                $("#tbody-profesional").append('<tr class=' + claseEliminado + '>' +
                    '<td>' + profesional.profesionalNombreCompleto + '</td>' +
                    '<td>' + profesional.empresaNombre + '</td>' +
                    '<td>' + profesional.tipoProfesional + '</td>' +
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
    $("#titulo-Modal-Profesional").text("Registrar un Nuevo Profesional");
    $("#ProfesionalID").val(0);
    $("#exampleModal").modal("show");
}
//Funcion para Vaciar el Formulario

function VaciarFormulario() {
    $("#ProfesionalID").val(0);
    $("#Error-Nombre").text("");
}

// FUncion para Guardar los Profesionales
function GuardarProfesional() {
    $("#Error-Nombre").text("");
    let profesionalID = $('#ProfesionalID').val();
    let nombre = $('#Nombre').val();
    let apellido = $('#Apellido').val();
    let empresaID = $('#EmpresaID').val();
    let clasificacionProfesionalID = $('#ClasificacionProfesionalID').val();
    if (nombre != "" && nombre != null) {
        $.ajax({
            type: "POST",
            url: '../../Profesionales/GuardarProfesional',
            data: { ProfesionalID: profesionalID, Nombre: nombre, Apellido: apellido, EmpresaID: empresaID, ClasificacionProfesionalID: clasificacionProfesionalID },
            success: function (resultado) {
                if (resultado == 0) {
                    $("#exampleModal").modal("hide");
                    CompletarTablaProfesionales();
                }
                if (resultado == 2) {
                    $("#Error-Nombre").text("El Profesional ingresada Ya Existe. Ingrese un nuevo Profesional");
                }
            },
            error: function (data) {
            }
        });
    }
    else {
        $("#Error-Nombre").text("Debe ingresar un Nombre para el  Profesional.");
    }
}