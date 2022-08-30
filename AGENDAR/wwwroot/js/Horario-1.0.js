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
                let botones = '<button type="button" onclick="DesactivarHorario(' + horario.horarioID + ',1)" class="btn btn-outline-danger btn-sm"><i class="bi bi-trash-fill"></i> Desactivar</button>';

                if (horario.eliminado) {
                    claseEliminado = 'table-danger';
                    botones = '<button type="button" onclick="DesactivarHorario(' + horario.horarioID + ',0)" class="btn btn-outline-success btn-sm"><i class="bi bi-folder-symlink"></i> Activar</button>';
                }
                let tiempoMostrar = "15 Minutos";
                
                if(horario.tiempoTurnos == 30) {
                    tiempoMostrar = "30 Minutos"
                }
                if (horario.tiempoTurnos == 45) {
                    tiempoMostrar = "45 Minutos"
                }
                if (horario.tiempoTurnos == 60) {
                    tiempoMostrar = "60 Minutos"
                }

                $("#tbody-horario").append('<tr class=' + claseEliminado + '>' +
                    '<td>' + horario.horarioCompleto + '</td>' +
                    '<td>' + tiempoMostrar + '</td>' +
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
    $("#titulo-Modal-Horario").text("NUEVO HORARIO");
    $("#HorarioID").val(0);
    $("#HoraInicio").val('00:00');
    $("#HoraFin").val('00:00');
    $("#TiempoTurnos").val('');
    $("#ProfesionalID").val(0);
    $("#exampleModal").modal("show");
}
// Funcion para Guardar el Horario

function GuardarHorario() {
    $("#Error-Hora").text("");
    let horarioID = $('#HorarioID').val();
    let horaInicio = $('#HoraInicio').val().trim();
    let horaFin = $('#HoraFin').val().trim();
    let tiempoTurnos = $('#TiempoTurnos').val();
    let profesionalID = $('#ProfesionalID').val();
    if (horaInicio != null && horaFin != null) {
        $.ajax({
            type: "POST",
            url: '../../Horarios/GuardarHorario',
            data: { HorarioID: horarioID, HoraInicio: horaInicio, HoraFin: horaFin, TiempoTurnos: tiempoTurnos, ProfesionalID: profesionalID },
            async: false,
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


//Funcion para Vaciar el Formulario

function VaciarFormulario() {
    $("#HorarioID").val(0);
    $("#HoraInicio").val('');
    $("#HoraFin").val('');
    $("#TiempoTurnos").val('');
    $("#ProfesionalID").val(0);
    $("#Error-Hora").text("");
}

function DesactivarHorario(horarioID, elimina) {

    if (elimina == 1) {
        var mensajeEliminar = "¿Esta seguro que quiere DESACTIVAR el Horario?"
    } else {
        var mensajeEliminar = "¿Esta seguro que quiere ACTIVAR el Horario?"
    }

    if (confirm(mensajeEliminar)) {
        $.ajax({
            type: "POST",
            url: '../../Horarios/DesactivarHorario',
            data: { HorarioID: horarioID, Elimina: elimina },
            success: function (horario) {
                CompletarTablaHorario();
            },
            error: function (data) {
            }
        });
    }
}

