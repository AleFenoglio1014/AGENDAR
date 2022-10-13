FullCalendar.globalLocales.push(function () {
  'use strict';

  var es = {
    code: 'es',
    week: {
      dow: 1, 
      doy: 4, 
    },
    buttonText: {
      prev: 'Ant',
      next: 'Sig',
      today: 'Hoy',
      month: 'Mes',
      week: 'Semana',
      day: 'Día',
      list: 'Agenda',
    },
    buttonHints: {
      prev: '$0 antes',
      next: '$0 siguiente',
      today(buttonText) {
        return (buttonText === 'Día') ? 'Hoy' :
          ((buttonText === 'Semana') ? 'Esta' : 'Este') + ' ' + buttonText.toLocaleLowerCase()
      },
    },
    viewHint(buttonText) {
      return 'Vista ' + (buttonText === 'Semana' ? 'de la' : 'del') + ' ' + buttonText.toLocaleLowerCase()
    },
    weekText: 'Sm',
    weekTextLong: 'Semana',
    allDayText: 'Todo el día',
    moreLinkText: 'más',
    moreLinkHint(eventCnt) {
      return `Mostrar ${eventCnt} eventos más`
    },
    noEventsText: 'No hay eventos para mostrar',
    navLinkHint: 'Ir al $0',
    closeHint: 'Cerrar',
    timeHint: 'La hora',
    eventHint: 'Evento',
  };

  return es;

}());


let arrayTurnos = [];


function CargaElementos() {
    let profesionalIDFiltro = $("#ProfesionalIDFiltro").val();
    $.ajax({
        type: "GET",
        url: '../../Turnos/MostrarTurnosInterno',
        data: { profesionalIDFiltro: profesionalIDFiltro },
        async: false,
        success: function (listadoTurnosCalendario) {

            $.each(listadoTurnosCalendario, function (index, turno) {
                let colorMostrar = '';

                if (turno.estado == 2) {
                    colorMostrar = '#005e11'
                }
                else if (turno.estado == 1) {
                    colorMostrar = '#FFFF00'
                }
                else if (turno.estado == 3) {
                    colorMostrar = '#ff0000'
                }
                arrayTurnos.push({ title: turno.nombre, start: turno.horarioFecha, id: turno.turnoID, color: colorMostrar });
           
            });
            CalendarioTurno();
        },
        error: function (data) {
            alert("Error al cargar los turnos.");
        }
    });
    
}

/*FUNCIÓN PARA SETEAR EL CALENDARIO DE MES A SEMANA CUANDO SE ACHICA LA PANTALLA*/
//import { Calendar } from '@fullcalendar/core';
//import listPlugin from '@fullcalendar/list';

//let calendar = new Calendar(calendarEl, {
//    plugins: [listPlugin],
//    initialView: 'listWeek'
//});


function CalendarioTurno() {

    document.addEventListener('DOMContentLoaded', function () {
        var calendarEl = document.getElementById('calendar');

        var calendar = new FullCalendar.Calendar(calendarEl, {
           
            dayMaxEvents: true,
            headerToolbar: {
                left: 'prev,next today',
                center: 'title',
                right: 'dayGridMonth,dayGridWeek,dayGridDay'
            },

            initialDate: new Date(),
            navLinks: true, 
           
            locale: 'es',
            events: arrayTurnos,
            eventTimeFormat: {
                hour: '2-digit',
                minute: '2-digit',
            },
            selectable: true,
            eventClick: function (turno) {
                $("#modalEstado").modal("show");
                $("#TurnoID").val(turno.event.id);
                
            }


        });

        calendar.render();
    });
}

function EstadoTurno(estado, turnoID) {

    $.ajax({
        type: "POST",
        url: '../../Turnos/EstadoTurno',
        data: { TurnoID: turnoID, Estado: estado },
        success: function (turno) {

            $("#modalEstado").modal("hide");
            CargaElementos();
        },
        error: function (data) {
        }
    });
}
//FUNCION PARA FILTAR LOS PROFESIONALES POR HORARIO

$("#ProfesionalIDFiltro").change(function () {
    CargaElementos();
});
function MostrarTurnosInterno() {
    //Se limpia el contenido del dropdownlist
    $("#TurnoID").empty();
    $.ajax({
        type: 'POST',
        //Llamado al metodo en el controlador
        url: "../../Turnos/MostrarTurnosInterno",
        dataType: 'json',
        //Parametros que se envian al metodo del controlador
        data: { profesionalIDFiltro: $("#ProfesionalIDFiltro").val() },
        //En caso de resultado exitoso
        success: function (turnosCalendario) {

            $.each(turnosCalendario, function (i, profesional) {
                $("#TurnoID").append('<option value="' + profesional.value + '">' +
                    profesional.text + '</option>');
            });
            CargaElementos()
        },
        ////Mensaje de error en caso de fallo
        error: function (ex) {
        }
    });
    return false;
}

