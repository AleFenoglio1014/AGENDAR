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
function AbrirModal() {
    $("#btn-confirmar").removeClass("ocultar");
    $("#btn-estado").removeClass("turnoPasado");
    $("#btn-estado").addClass("botones414");
    $("#modalEstado").modal("show");
}

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
            /*CalendarioTurno();*/
            var ancho = $(window).width();
            var defecto = '';
            var vistas = '';
            if (ancho > 480) {
                defecto = 'dayGridMonth';
                vistas = 'dayGridMonth,dayGridDay'
            }
            else {
                defecto = 'listWeek';
                vistas = 'listWeek';
            }
            document.addEventListener('DOMContentLoaded', function () {
                var calendarEl = document.getElementById('calendar');

                var calendar = new FullCalendar.Calendar(calendarEl, {

                    dayMaxEvents: true,
                    initialView: defecto,
                    headerToolbar: {
                        left: 'prev,next today',
                        center: 'title',
                        right: vistas
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
                        var check = moment(turno.event.start).format('YYYY-MM-DD');
                        var today = moment(new Date()).format('YYYY-MM-DD');
                        if (check < today) {
                            swal({
                                title: "EL TURNO EXPIRÓ",
                                text: "DEBE FINALIZAR O CANCELAR EL TURNO!",
                                icon: "warning",
                                button: "Entendido",
                            }).then(function () {
                                $("#modalEstado").modal("show");
                                $("#TurnoID").val(turno.event.id);
                                $("#btn-confirmar").addClass("ocultar");
                                $("#btn-estado").addClass("turnoPasado");
                                $("#btn-estado").removeClass("botones414");
                            });
                        }
                        else {
                            AbrirModal();
                            $("#TurnoID").val(turno.event.id);
                        }

                    }

                });
               
                calendar.render();
            });
        },
        error: function (data) {
            alert("Error al cargar los turnos.");
        }
    });

}


function EstadoTurno(estado) {
    let turnoID = $("#TurnoID").val();
    $("#btn-estado").addClass("ocultar");
    $("#btn-estado-espere").removeClass("ocultar");
    $.ajax({
        type: "POST",
        url: '../../Turnos/EstadoTurno',
        data: { TurnoID: turnoID, Estado: estado },
        success: function (turno) {
            $("#btn-estado").removeClass("ocultar");
            $("#btn-estado-espere").addClass("ocultar");

            $("#btn-confirmar").removeClass("ocultar");
            $("#btn-estado").removeClass("turnoPasado");
            $("#modalEstado").modal("hide");
            CargaElementos();
        },
        error: function (data) {
        }
    });
}

//FUNCION PARA FILTAR LOS PROFESIONALES POR TURNO

$("#ProfesionalIDFiltro").change(function () {
    CargaElementos();
    //location.reload();
});


