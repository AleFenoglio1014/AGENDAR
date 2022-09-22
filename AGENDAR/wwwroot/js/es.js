//FullCalendar.globalLocales.push(function () {
//  'use strict';

//  var es = {
//    code: 'es',
//    week: {
//      dow: 1, // Monday is the first day of the week.
//      doy: 4, // The week that contains Jan 4th is the first week of the year.
//    },
//    buttonText: {
//      prev: 'Ant',
//      next: 'Sig',
//      today: 'Hoy',
//      month: 'Mes',
//      week: 'Semana',
//      day: 'Día',
//      list: 'Agenda',
//    },
//    buttonHints: {
//      prev: '$0 antes',
//      next: '$0 siguiente',
//      today(buttonText) {
//        return (buttonText === 'Día') ? 'Hoy' :
//          ((buttonText === 'Semana') ? 'Esta' : 'Este') + ' ' + buttonText.toLocaleLowerCase()
//      },
//    },
//    viewHint(buttonText) {
//      return 'Vista ' + (buttonText === 'Semana' ? 'de la' : 'del') + ' ' + buttonText.toLocaleLowerCase()
//    },
//    weekText: 'Sm',
//    weekTextLong: 'Semana',
//    allDayText: 'Todo el día',
//    moreLinkText: 'más',
//    moreLinkHint(eventCnt) {
//      return `Mostrar ${eventCnt} eventos más`
//    },
//    noEventsText: 'No hay eventos para mostrar',
//    navLinkHint: 'Ir al $0',
//    closeHint: 'Cerrar',
//    timeHint: 'La hora',
//    eventHint: 'Evento',
//  };

//  return es;

//}());


let arrayTurnos = [];


function CargaElementos() {

    $.ajax({
        type: "GET",
        url: '../../Turnos/MostrarTurnosInterno',
        data: {},
        async: false,
        success: function (listadoTurnos) {

            $.each(listadoTurnos, function (index, turno) {
                arrayTurnos.push({ title: turno.nombre, start: turno.horarioFecha });
            });

            CalendarioTorneo();
        },
        error: function (data) {
            alert("Error al cargar los torneos.");
        }
    });
    //CalendarioTorneo();
}


function CalendarioTorneo() {

    document.addEventListener('DOMContentLoaded', function () {
        var calendarEl = document.getElementById('calendar');

        var calendar = new FullCalendar.Calendar(calendarEl, {
            headerToolbar: {
                left: 'prev,next today',
                center: 'title',
                right: 'dayGridMonth,dayGridDay'
            },
            initialDate: DateTime.Now,
            navLinks: true, // can click day/week names to navigate views
            editable: true,
            locale: 'es',
            events: arrayTurnos,
            //events: [
            //    {
            //        title: 'Lunch',
            //        start: '2022-09-12T12:00:00'
            //    },

            //]

        });

        calendar.render();
    });
}