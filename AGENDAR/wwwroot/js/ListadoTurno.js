// Funcion para CompletarTablaTurnos
function CompletarTablaTurnos() {
    let profesionalIDFiltro = $("#ProfesionalIDFiltro").val();
    $.ajax({
        type: "POST",
        url: '../../Turnos/MostrarTurnosInterno',
        data: { profesionalIDFiltro: profesionalIDFiltro },
        success: function (listadoTurnosCalendario) {
            $("#tbody-turnos").empty();
            $.each(listadoTurnosCalendario, function (index, turno) {

                let estadoTurno = "";

                if (turno.estado == 1) {
                    estadoTurno = '<spam class="text-warning font-weight-bold">Pendiente</spam>';
                }
                if (turno.estado == 2) {
                    estadoTurno = '<spam class="text-success font-weight-bold">Confirmado</spam>';
                }
                if (turno.estado == 3) {
                    estadoTurno = '<spam class="text-danger font-weight-bold">Finalizado</spam>';
                }
               


                $("#tbody-turnos").append('<tr class=>' +
                    '<td class="ocultar767">' + turno.profesionalNombre + '</td>' +
                    '<td>' + turno.fechaTurnostring + '</td>' +
                    '<td>' + turno.horarioCompleto + '</td>' +
                    '<td>' + estadoTurno + '</td>' +
                    '<td>' + turno.nombre + '</td>' +


                    '</tr>');
            });
        },
        error: function (data) {
        }
    });
}

//FUNCION PARA FILTAR LOS PROFESIONALES POR TURNO

$("#ProfesionalIDFiltro").change(function () {
    CompletarTablaTurnos();
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
            CompletarTablaTurnos()
        },
        ////Mensaje de error en caso de fallo
        error: function (ex) {
        }
    });
    return false;
}

