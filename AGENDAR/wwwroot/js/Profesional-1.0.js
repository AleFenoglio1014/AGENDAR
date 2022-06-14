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
                $("#tbody-profesional").append('<tr>' +
                    '<td>' + profesional.profesionalNombreCompleto + '</td>' +
                    '<td>' + profesional.empresaNombre + '</td>' +
                    '<td>' + profesional.tipoProfesional + '</td>' +
                    '<td>' +  '<button type="button" onclick="BuscarProfesional(' + profesional.profesionalID + ',' + profesional.empresaID + ')" class="btn btn-outline-primary btn-sm" style="margin-right:5px"><i class="bi bi-pencil-square"></i> Editar</button>' +
                    '<button type="button" onclick="Eliminarprofesional(' + profesional.profesionalID + ',1)" class="btn btn-outline-danger btn-sm"><i class="bi bi-trash-fill"></i> Eliminar</button>' + '</td>' +

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
    $("#Nombre").val('');
    $("#Apellido").val('');
    $("#EmpresaID").val(0);
    $("#ClasificacionProfesionalID").val(0);
    $("#Error-Nombre").text("");
    $("#Error-CamposProfesional").text("");
}

// FUncion para Guardar los Profesionales
function GuardarProfesional() {
    $("#Error-Nombre").text("");
    $("#Error-CamposProfesional").text("");
    let profesionalID = $('#ProfesionalID').val();
    let nombre = $('#Nombre').val().trim();
    let apellido = $('#Apellido').val().trim();
    let empresaID = $('#EmpresaID').val();
    let clasificacionProfesionalID = $('#ClasificacionProfesionalID').val();

    let guardarProfesional = true;

    if (nombre == "" || nombre == null) {
        guardarProfesional = false;
        $("#Error-CamposProfesional").text("Los campos son OBLIGATORIOS.");
    }
    if (apellido == "" || apellido == null) {
        guardarProfesional = false;
        $("#Error-CamposProfesional").text("Los campos son OBLIGATORIOS.");
    }
    if (clasificacionProfesionalID == "" || clasificacionProfesionalID == null) {
        guardarProfesional = false;
        $("#Error-CamposProfesional").text("Los campos son OBLIGATORIOS.");
    }
    if (empresaID == "" || empresaID == null) {
        guardarProfesional = false;
        $("#Error-CamposProfesional").text("Los campos son OBLIGATORIOS.");
    }
   
    if (guardarProfesional) {
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
                    $("#Error-Nombre").text("El Profesional ingresado Ya Existe. Ingrese un nuevo Profesional");
                }
            },
            error: function (data) {
            }
        });
    }
    else {
        $("#Error-CamposProfesional").text("Los campos son OBLIGATORIOS.");
    }
}

// Funcion para Buscar el Profesional

function BuscarProfesional(profesionalID, nombre, apellido, empresaID,clasificacionProfesionalID) {
    $("#titulo-Modal-Profesional").text("Editar Profesional");
    $("#ProfesionalID").val(profesionalID);
    $("#Nombre").val(nombre);
    $("#Apellido").val(apellido);
    $("#EmpresaID").val(empresaID);
    $("#ClasificacionProfesionalID").val(clasificacionProfesionalID);
    $.ajax({
        type: "POST",
        url: '../../Profesionales/BuscarProfesional',
        data: { ProfesionalID: profesionalID, Nombre: nombre, Apellido: apellido, EmpresaID: empresaID, ClasificacionProfesionalID: clasificacionProfesionalID },
        success: function (profesional) {
            $("#Nombre").val(profesional.nombre);
            $("#Apellido").val(profesional.apellido);
            $("#EmpresaID").val(profesional.empresaID);
            $("#ClasificacionProfesionalID").val(profesional.clasificacionProfesionalID);
            $("#exampleModal").modal("show");
        },
        error: function (data) {
        }
    });
}
//Funcion para eliminar el profesional


function Eliminarprofesional(profesionalID) {
    var mensajeEliminar = "¿Esta seguro que quiere ELIMINAR al Profesional?"
    if (confirm(mensajeEliminar)) {
    $.ajax({
        type: "POST",
        url: '../../Profesionales/Eliminarprofesional',
        data: { ProfesionalID: profesionalID },
        success: function (profesional) {
            CompletarTablaProfesionales();
        },
        error: function (data) {
        }
    });
    }
}