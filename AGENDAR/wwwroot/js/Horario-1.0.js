// Funcion para Completar la Tabla de Horario
function CompletarTablaHorario() {
    VaciarFormulario();
    $.ajax({
        type: "POST",
        url: '../../Horarios/BuscarHorarios',
        data: {},
        success: function (listadoHorario) {
            $("#tbody-horario").empty();
            $.each(listadoHorario, function (index, horario) {

                let claseEliminado = '';
                let botones = '<button type="button" onclick="BuscarHorario(' + horario.horarioID + ')" class="btn btn-outline-primary btn-sm" style="margin-right:5px"><i class="bi bi-pencil-square"></i> Editar</button>'
               
                $("#tbody-horario").append('<tr class=' + claseEliminado + '>' +
                    '<td>' + horario.horaIniciostring + '</td>' +
                    '<td>' + horario.horaFinstring + '</td>' +
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
    $("#titulo-Modal-Horario").text("Nuevo Horario");
    $("#HorarioID").val(0);
    $("#HoraInicio").val('00:00');
    $("#HoraFin").val('00:00');
    $("#exampleModal").modal("show");
}
// Funcion para Guardar el Horario

function GuardarHorario() {
    $("#Error-Hora").text("");
    let horarioID = $('#HorarioID').val();
    let horaInicio = $('#HoraInicio').val().trim();
    let horaFin = $('#HoraFin').val().trim();
    if (horaInicio != null && horaFin != null) {
        $.ajax({
            type: "POST",
            url: '../../Horarios/GuardarHorario',
            data: { HorarioID: horarioID, HoraInicio: horaInicio, HoraFin: horaFin },
            success: function (resultado) {
                if (resultado == 0) {
                    $("#exampleModal").modal("hide");
                    CompletarTablaHorario();
                }
                if (resultado == 2) {
                    $("#Error-Hora").text("El horario ingresado Ya Existe. Ingrese un Nuevo horario");
                }
            },
            error: function (data) {
            }
        });
    }
    else {
        $("#Error-Hora").text("Debe ingresar un Horario.");
    }
}
// Funcion para Buscar los Horarios

function BuscarHorario(horarioID) {
    VaciarFormulario();
    $("#titulo-Modal-Horario").text("Editar Horario ");
    $("#HorarioID").val(horarioID);
    $.ajax({
        type: "POST",
        url: '../../Horarios/BuscarHorario',
        data: { HorarioID: horarioID  },
        success: function (horario) {
            $("#HoraInicio").val(horario.horaInicio);
            $("#HoraFin").val(horario.horaFin.horaFinstring);
            $("#exampleModal").modal("show");
        },
        error: function (data) {
        }
    });
}

//Funcion para Vaciar el Formulario

function VaciarFormulario() {
    $("#HorarioID").val(0);
    $("#HoraInicio").val('');
    $("#HoraFin").val('');
    $("#Error-Hora").text("");
}