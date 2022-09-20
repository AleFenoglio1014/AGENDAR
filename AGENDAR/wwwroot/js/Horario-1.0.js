// Funcion para Completar la Tabla de Horario
function CompletarTablaHorario( ) {
    VaciarFormulario();
   /* let profesionalIDFiltro = $('#ProfesionalIDFiltro').val().trim();*/
    $.ajax({
        type: "POST",
        url: '../../Horarios/BuscarHorarios',
        data: { /*ProfesionalID: profesionalIDFiltro*/ },
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

                let letraDomingo = '<spam class="text-success font-weight-bold">D</spam>';
                if (!horario.domingo) {
                    letraDomingo = '<spam class="text-danger font-weight-bold">D</spam>'
                }
                let letraLunes = '<spam class="text-success font-weight-bold">L</spam>';
                if (!horario.lunes) {
                    letraLunes = '<spam class="text-danger font-weight-bold">L</spam>'
                }
                let letraMartes = '<spam class="text-success font-weight-bold">M</spam>';
                if (!horario.martes) {
                    letraMartes = '<spam class="text-danger font-weight-bold">M</spam>'
                }
                let letraMiercoles = '<spam class="text-success font-weight-bold">M</spam>';
                if (!horario.miercoles) {
                    letraMiercoles = '<spam class="text-danger font-weight-bold">M</spam>'
                }
                let letraJueves = '<spam class="text-success font-weight-bold">J</spam>';
                if (!horario.jueves) {
                    letraJueves = '<spam class="text-danger font-weight-bold">J</spam>'
                }
                let letraViernes = '<spam class="text-success font-weight-bold">V</spam>';
                if (!horario.viernes) {
                    letraViernes = '<spam class="text-danger font-weight-bold">V</spam>'
                }
                let letraSabado = '<spam class="text-success font-weight-bold">S</spam>';
                if (!horario.sabado) {
                    letraSabado = '<spam class="text-danger font-weight-bold">S</spam>'
                }

                $("#tbody-horario").append('<tr class=' + claseEliminado + '>' +
                    '<td class="text-center ">' + horario.horarioCompleto + '</td>' +
                    '<td class="text-center ">' + tiempoMostrar + '</td>' +
                    '<td class="text-center ">' + horario.profesionalNombre + '</td>' +
                    '<td class="text-center ">' + letraDomingo + letraLunes + letraMartes + letraMiercoles + letraJueves + letraViernes + letraSabado + '</td>' +
                    '<td class="text-center ">' +
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
    $("#Error-CamposHorario").text("");
    let horarioID = $('#HorarioID').val();
    let horaInicio = $('#HoraInicio').val().trim();
    let horaFin = $('#HoraFin').val().trim();
    let tiempoTurnos = $('#TiempoTurnos').val();
    let profesionalID = $('#ProfesionalID').val();
    let lunes = $('#Lunes').val().trim();
    let martes = $('#Martes').val().trim();
    let miercoles = $('#Miercoles').val().trim();
    let jueves = $('#Jueves').val().trim();
    let viernes = $('#Viernes').val().trim();
    let sabado = $('#Sabado').val().trim();
    let domingo = $('#Domingo').val().trim();

    let guardarHorario = true;
    if (horaInicio == "" || horaInicio == null) {
        guardarProfesional = false;
        $("#Error-CamposHorario").text("Los campos son OBLIGATORIOS.");
    }
    if (horaFin == "" || horaFin == null) {
        guardarProfesional = false;
        $("#Error-CamposHorario").text("Los campos son OBLIGATORIOS.");
    }
    if (tiempoTurnos == "" || tiempoTurnos == null) {
        guardarProfesional = false;
        $("#Error-CamposHorario").text("Los campos son OBLIGATORIOS.");
    }
    if (profesionalID == "" || profesionalID == null) {
        guardarProfesional = false;
        $("#Error-CamposHorario").text("Los campos son OBLIGATORIOS.");
    }
    if (guardarHorario) {
        $.ajax({
            type: "POST",
            url: '../../Horarios/GuardarHorario',
            data: { HorarioID: horarioID, HoraInicio: horaInicio, HoraFin: horaFin, TiempoTurnos: tiempoTurnos, ProfesionalID: profesionalID, Lunes: lunes, Martes: martes, Miercoles: miercoles, Jueves: jueves, Viernes: viernes, Sabado: sabado, Domingo: domingo },
            success: function (resultado) {
                if (resultado == 0) {
                    $("#exampleModal").modal("hide");
                    CompletarTablaHorario();
                }
                if (resultado == 2) {
                    $("#Error-Hora").text("El horario ingresado Ya Existe. Ingrese un Nuevo horario");
                }
                else if (resultado == 3) {
                    $("#Error-HoraMayor").text("La Hora de Inicio debe ser Menor a la Hora de Fin ");
                }
                else if (resultado == 4) {
                    $("#Error-HoraMenor").text("La diferencia entre la Hora Inicio y Hora Fin debe ser MIN de una hora");
                }
            },
            error: function (data) {
            }
        });
    }
    else {
        $("#Error-CamposHorario").text("Los campos son OBLIGATORIOS.");
    }
}


//Funcion para Vaciar el Formulario

function VaciarFormulario() {
    $("#HorarioID").val(0);
    $("#HoraInicio").val('');
    $("#HoraFin").val('');
    $("#TiempoTurnos").val('');
    $("#DiaTurno").val('');
    $("#ProfesionalID").val(0);
    $("#Lunes").val(false);
    $("#Martes").val(false);
    $("#Miercoles").val(false);
    $("#Jueves").val(false);
    $("#Viernes").val(false);
    $("#Sabado").val(false);
    $("#Domingo").val(false);
    $("#Error-Hora").text("");
    $("#Error-CamposHorario").text("");
    $("#Error-HoraMayor").text("");
    $("#Error-HoraMenor").text("");
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


//FUNCION PARA GUARDAR COMO TRUE SI SELECCIONA EL CASILLERO Y FALSE SI NO SELECCIONA EL CASILLERO
$('#checkbox-value').text($('#Lunes').val());

$("#Lunes").on('change', function () {
    if ($(this).is(':checked')) {
        $(this).attr('value', 'true');
    } else {
        $(this).attr('value', 'false');
    }

    $('#checkbox-value').text($('#Lunes').val());
});




$('#checkbox-value').text($('#Martes').val());

$("#Martes").on('change', function () {
    if ($(this).is(':checked')) {
        $(this).attr('value', 'true');
    } else {
        $(this).attr('value', 'false');
    }

    $('#checkbox-value').text($('#Martes').val());
});

$('#checkbox-value').text($('#Miercoles').val());

$("#Miercoles").on('change', function () {
    if ($(this).is(':checked')) {
        $(this).attr('value', 'true');
    } else {
        $(this).attr('value', 'false');
    }

    $('#checkbox-value').text($('#Miercoles').val());
});

$('#checkbox-value').text($('#Jueves').val());

$("#Jueves").on('change', function () {
    if ($(this).is(':checked')) {
        $(this).attr('value', 'true');
    } else {
        $(this).attr('value', 'false');
    }

    $('#checkbox-value').text($('#Jueves').val());
});

$('#checkbox-value').text($('#Viernes').val());

$("#Viernes").on('change', function () {
    if ($(this).is(':checked')) {
        $(this).attr('value', 'true');
    } else {
        $(this).attr('value', 'false');
    }

    $('#checkbox-value').text($('#Viernes').val());
});

$('#checkbox-value').text($('#Sabado').val());

$("#Sabado").on('change', function () {
    if ($(this).is(':checked')) {
        $(this).attr('value', 'true');
    } else {
        $(this).attr('value', 'false');
    }

    $('#checkbox-value').text($('#Sabado').val());
});


$('#checkbox-value').text($('#Domingo').val());

$("#Domingo").on('change', function () {
    if ($(this).is(':checked')) {
        $(this).attr('value', 'true');
    } else {
        $(this).attr('value', 'false');
    }

    $('#checkbox-value').text($('#Domingo').val());
});

////FUNCION PARA FILTAR LOS PROFESIONALES POR HORARIO

//$("#ProfesionalIDFiltro").change(function () {
//    BuscarHorarios();
//});
//function BuscarHorarios() {
//    //Se limpia el contenido del dropdownlist
//    $("#HorarioID").empty();
//    $.ajax({
//        type: 'POST',
//        //Llamado al metodo en el controlador
//        url: "../../Horarios/ComboHorarioProfesional",
//        dataType: 'json',
//        //Parametros que se envian al metodo del controlador
//        data: { profesionalIDFiltro: $("#ProfesionalIDFiltro").val() },
//        //En caso de resultado exitoso
//        success: function (profesionalFiltro) {
            
//            $.each(profesionalFiltro, function (i, profesional) {
//                $("#HorarioID").append('<option value="' + profesional.value + '">' +
//                    profesional.text + '</option>');
//                });
//            CompletarTablaHorario()
//        },
//        ////Mensaje de error en caso de fallo
//        error: function (ex) {
//        }
//    });
//    return false;
//}