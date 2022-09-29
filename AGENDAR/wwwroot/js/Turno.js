

// FUNCION PARA GUARDAR EL TURNO

function GuardarTurno() {
   
    let turnoID = $('#TurnoID').val();
    let localidadID = $('#LocalidadID').val();
    let telefono = $('#Telefono').val();
    let provinciaID = $('#ProvinciaID').val();
    let nombre = $('#Nombre').val().trim();
    let apellido = $('#Apellido').val().trim();
    let email = $('#Email').val().trim();
    let empresaID = $('#EmpresaID').val();
    let horarioID = $('#HorarioID').val();
    let fechaTurno = $('#FechaTurno').val().trim();
    let profesionalID = $('#ProfesionalID').val();

    let guardarTurno = true;

    if (nombre == "" || nombre == null) {
        guardarTurno = false;
        $("#Error-CamposTurno").text("Los campos son OBLIGATORIOS.");
    }
    if (apellido == "" || apellido == null) {
        guardarTurno = false;
        $("#Error-CamposTurno").text("Los campos son OBLIGATORIOS.");
    }
    if (email == "" || email == null) {
        guardarTurno = false;
        $("#Error-CamposTurno").text("Los campos son OBLIGATORIOS.");

    }
    if (empresaID == "" || empresaID == null) {
        guardarTurno = false;
        $("#Error-CamposTurno").text("Los campos son OBLIGATORIOS.");
    }
    if (horarioID == "" || horarioID == null) {
        guardarTurno = false;
        $("#Error-CamposTurno").text("Los campos son OBLIGATORIOS.");
    }
    if (fechaTurno == "" || fechaTurno == null) {
        guardarTurno = false;
        $("#Error-CamposTurno").text("Los campos son OBLIGATORIOS.");
    }
    if (profesionalID == "" || profesionalID == null) {
        guardarTurno = false;
        $("#Error-CamposTurno").text("Los campos son OBLIGATORIOS.");
    }
    if (localidadID == "" || localidadID == null) {
        guardarTurno = false;
        $("#Error-CamposTurno").text("Los campos son OBLIGATORIOS.");
    }
    if (telefono == "" || telefono == null) {
        guardarTurno = false;
        $("#Error-CamposTurno").text("Los campos son OBLIGATORIOS.");
    }
    if (provinciaID == "" || provinciaID == null) {
        guardarTurno = false;
        $("#Error-CamposTurno").text("Los campos son OBLIGATORIOS.");
    }


    swal({
        title: "¿Deseas solicitar el turno?",
        text: "Una vez solicitado deberá esperar la confirmación del Profesional para cambiar el turno.",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "¡Claro!",
        cancelButtonText: "No, volver",
        closeOnConfirm: false,
        closeOnCancel: false
    })
        .then(function (isConfirm) {

            if (isConfirm) {
                swal("¡Hecho!",
                    "El turno ha sido solicitado",
                    "success");
            } else {
                swal("¡Proceso Cancelado!",
                    "¡Vuelva cuando quiera!",
                    "error");
            }
        });

    if (guardarTurno) {


                        

       
        //$.ajax({
        //    type: "POST",
        //    url: '../../Turnos/GuardarTurno',
        //    data: { TurnoID: turnoID, Nombre: nombre, Apellido: apellido, Email: email, Telefono: telefono, FechaTurno: fechaTurno, ProvinciaID: provinciaID, LocalidadID: localidadID, EmpresaID: empresaID, ProfesionalID: profesionalID, HorarioID: horarioID },
        //    success: function (resultado) {
        //        if (resultado == 0) {
        //            $("#exampleModal").modal("hide");
        //            VaciarFormulario()
        //            swal({
        //                title: "¡Turno Solicitado!",
        //                text: "Su turno se registró con éxito, espere que sea aceptado por el profesional",
        //                type: "success",
        //                confirmButtonText: "Entendido!",
        //                confirmButtonColor: "#00ff55",
        //            }).then(function () {
        //                window.location.href = '/';
        //            });
                       
        //        }
                
        //    },
        //    error: function (data) {
        //    }
        //});
    }
    else {
        $("#Error-CamposTurno").text("Los campos son OBLIGATORIOS.");
    }
}



//FUNCION PARA TRAER LAS LOCALIDADES QUE PERTENECEN A LA PROVINCIA SELECCIONADA
$("#ProvinciaID").change(function () {
    BuscarLocalidades();
});

function BuscarLocalidades() {
    //Se limpia el contenido del dropdownlist
    $("#LocalidadID").empty();
    $.ajax({
        type: 'POST',
        //Llamado al metodo en el controlador
        url: "../../Localidades/ComboLocalidad",
        dataType: 'json',
        //Parametros que se envian al metodo del controlador
        data: { id: $("#ProvinciaID").val() },
        //En caso de resultado exitoso
        success: function (localidades) {
            if (localidades.length == 0) {
                $("#LocalidadID").append('<option value="' + "0" + '">' + "[NO EXISTEN LOCALIDADES]" + '</option>');
            }
            else {
                $.each(localidades, function (i, localidad) {
                    $("#LocalidadID").append('<option value="' + localidad.value + '">' +
                        localidad.text + '</option>');
                });
            } BuscarEmpresas()
        },
        ////Mensaje de error en caso de fallo
        error: function (ex) {
        }
    });
    return false;
}

//FUNCION PARA TRAER LAS EMPRESAS QUE PERTENECEN A LA LOCALIDAD SELECCIONADA

$("#LocalidadID").change(function () {
    BuscarEmpresas();
});
function BuscarEmpresas() {
    //Se limpia el contenido del dropdownlist
    $("#EmpresaID").empty();
    
    $.ajax({
        type: 'POST',
        //Llamado al metodo en el controlador
        url: "../../Empresas/ComboEmpresa",
        dataType: 'json',
        //Parametros que se envian al metodo del controlador
        data: { id: $("#LocalidadID").val() },
        //En caso de resultado exitoso
        success: function (empresas) {
            if (empresas.length == 0) {
                $("#EmpresaID").append('<option value="' + "0" + '">' + "[NO EXISTEN EMPRESAS]" + '</option>');
            }
            else {
                $.each(empresas, function (i, empresa) {
                    $("#EmpresaID").append('<option value="' + empresa.value + '">' +
                        empresa.text + '</option>');
                });
            } BuscarProfesionales()
        },
        ////Mensaje de error en caso de fallo
        error: function (ex) {
        }
    });
    return false;
}


////FUNCION PARA TRAER LOS PROFESIONALES QUE PERTENECEN A LA EMPRESA SELECCIONADA
$("#EmpresaID").change(function () {
    BuscarProfesionales();
});

function BuscarProfesionales() {
    //Se limpia el contenido del dropdownlist
    $("#ProfesionalID").empty();
    $.ajax({
        type: 'POST',
        //Llamado al metodo en el controlador
        url: "../../Profesionales/ComboProfesional",
        dataType: 'json',
        //Parametros que se envian al metodo del controlador
        data: { id: $("#EmpresaID").val() },
        //En caso de resultado exitoso
        success: function (profesionales) {
            if (profesionales.length == 0) {
                $("#ProfesionalID").append('<option value="' + "0" + '">' + "[NO EXISTEN PROFESIONAL]" + '</option>');
            }
            else {
                $.each(profesionales, function (i, profesional) {
                    $("#ProfesionalID").append('<option value="' + profesional.value + '">' +
                        profesional.text + '</option>');
                });
            } BuscarHorarios()
        },
        ////Mensaje de error en caso de fallo
        error: function (ex) {
        }
    });
    return false;
}



//FUNCION PARA TRAER LOS HORARIOS QUE PERTENECEN AL PROFESIONAL SELECCIONADO
$("#ProfesionalID").change(function () {
    BuscarHorarios();
});
$("#FechaTurno").change(function () {
    BuscarHorarios();
});

function BuscarHorarios() {
    //Se limpia el contenido del dropdownlist
    $("#HorarioID").empty();
    $.ajax({
        type: 'POST',
        //Llamado al metodo en el controlador
        url: "../../Horarios/ComboHorario",
        dataType: 'json',
        //Parametros que se envian al metodo del controlador
        data: { id: $("#ProfesionalID").val(), fecha: $("#FechaTurno").val() },
        //En caso de resultado exitoso
        success: function (horarios) {
            if (horarios.length == 0) {
                $("#HorarioID").append('<option value="' + "0" + '">' + "[NO EXISTEN HORARIOS]" + '</option>');
            }
            else {
                $.each(horarios, function (i, horario) {
                    $("#HorarioID").append('<option value="' + horario.value + '">' +
                        horario.text + '</option>');
                });
            }
        },
        ////Mensaje de error en caso de fallo
        error: function (ex) {
        }
    });
    return false;
}

// Funcion para limitar los caracteres de los input
var input = document.getElementById('Nombre');
input.addEventListener('input', function () {
    if (this.value.length > 30)
        swal("HA SUPERADO EL LIMITE DE CARACTERES PERMITIDO.");
    this.value = this.value.slice(0, 30);

})

var input = document.getElementById('Apellido');
input.addEventListener('input', function () {
    if (this.value.length > 30)
        swal("HA SUPERADO EL LIMITE DE CARACTERES PERMITIDO.");
    this.value = this.value.slice(0, 30);
})
var input = document.getElementById('Email');
input.addEventListener('input', function () {
    if (this.value.length > 49)
        swal("HA SUPERADO EL LIMITE DE CARACTERES PERMITIDO.");
    this.value = this.value.slice(0, 49);
})
var input = document.getElementById('Telefono');
input.addEventListener('input', function () {
    if (this.value.length > 15)
        swal("HA SUPERADO EL LIMITE DE CARACTERES PERMITIDO.");
    this.value = this.value.slice(0, 15);
})

//FUNCION PARA QUE EN EL CALENDARIO MUESTRE LA FECHA ACTUAL Y BLOQUEE LOS DIAS ANTERIORES
window.onload = function () {
    var fecha = new Date(); //Fecha actual
    var mes = fecha.getMonth() + 1; //obteniendo mes
    var dia = fecha.getDate(); //obteniendo dia
    var ano = fecha.getFullYear(); //obteniendo año
    if (dia < 10)
        dia = '0' + dia; //agrega cero si el menor de 10
    if (mes < 10)
        mes = '0' + mes //agrega cero si el menor de 10
    document.getElementById('FechaTurno').value = ano + "-" + mes + "-" + dia;
    var fecha_minimo = ano + '-' + mes + '-' + dia;// Nueva variable 
    document.getElementById("FechaTurno").setAttribute('min', fecha_minimo); FechaTurno.min = new Date().toISOString().split("T")[0];
    $("#HorarioID").append('<option value="' + "0" + '">' + "[SELECCIONE UN HORARIO]" + '</option>');
}

function VaciarFormulario() {
    $("#ProvinciaID").val(0);
    $("#LocalidadID").val(0);
    $("#EmpresaID").val(0);
    $("#HorarioID").val(0);
    $("#ProfesionalID").val(0);
    $("#Nombre").val('');
    $("#Apellido").val('');
    $("#Email").val('');
    $("#Telefono").val('');
    $("#Error-CamposTurno").text("");
}

