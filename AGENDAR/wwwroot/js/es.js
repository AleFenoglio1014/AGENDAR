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
                arrayTurnos.push({ title: turno.nombre, start: turno.horarioFecha, id: turno.turnoID });
           
            });
            CalendarioTurno();
        },
        error: function (data) {
            alert("Error al cargar los turnos.");
        }
    });
    
}


function CalendarioTurno() {

    document.addEventListener('DOMContentLoaded', function () {
        var calendarEl = document.getElementById('calendar');

        var calendar = new FullCalendar.Calendar(calendarEl, {
           
            dayMaxEvents: true,
            headerToolbar: {
                left: 'prev,next today',
                center: 'title',
                right: 'dayGridMonth,dayGridDay'
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
                $("#exampleModal").modal("show");
                // $("#TurnoID").val(turno.id);
                //alert(turno.event.id);
            }


        });
       
        calendar.render();
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

//function EstadoTurno(turnoID, estado) {
//    $("#TurnoID").val(turnoID);
//    $("#Estado").val(estado);
//        $.ajax({
//            type: "POST",
//            url: '../../Turnos/EstadoTurno',
//            data: { TurnoID: id, Estado: estado },
//            success: function (turno) {
//                $("#TurnoID").val(turno.id);
//            },
//            error: function (data) {
//            }
//        });
//}
