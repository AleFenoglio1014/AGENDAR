﻿// Funcion para Completar la Tabla de Profesionales
function CompletarTablaProfesionales() {
    VaciarFormulario();
    $.ajax({
        type: "POST",
        url: '../../Profesionales/BuscarProfesionales',
        data: {},
        success: function (listadoProfesionalesMostrar) {
            $("#tbody-profesional").empty();
            $.each(listadoProfesionalesMostrar, function (index, profesional) {

                let botones = '<button type="button" onclick="BuscarProfesional(' + profesional.profesionalID + ')" class="btn btn-outline-primary btn-sm" style="margin-right:5px"><i class="fa-regular fa-pen-to-square"></i> </button>' +
                    '<button type="button" onclick="Eliminarprofesional(' + profesional.profesionalID + ')" class="btn btn-outline-danger btn-sm"><i class="fa-solid fa-user-xmark"></i></button>';

                $("#tbody-profesional").append('<tr>' +
                    '<td class="text-center ">' + profesional.profesionalNombreCompleto + '</td>' +
                    
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
    $("#titulo-Modal-Profesional").text("NUEVO PROFESIONAL");
    $("#ProfesionalID").val(0);
    $("#exampleModal").modal("show");
}
//Funcion para Vaciar el Formulario

function VaciarFormulario() {
    $("#ProfesionalID").val(0);
    $("#Nombre").val('');
    $("#Apellido").val('');
    $("#EmpresaID").val(0);
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
   

    let guardarProfesional = true;

    if (nombre == "" || nombre == null) {
        guardarProfesional = false;
        $("#Error-CamposProfesional").text("Los campos son OBLIGATORIOS.");
    }
    if (apellido == "" || apellido == null) {
        guardarProfesional = false;
        $("#Error-CamposProfesional").text("Los campos son OBLIGATORIOS.");
    }
    
   
    if (guardarProfesional) {
        $.ajax({
            type: "POST",
            url: '../../Profesionales/GuardarProfesional',
            data: { ProfesionalID: profesionalID, Nombre: nombre, Apellido: apellido, },
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

function BuscarProfesional(profesionalID,) {
    $("#titulo-Modal-Profesional").text("EDITAR PROFESIONAL");
    $("#ProfesionalID").val(profesionalID);
  

    $.ajax({
        type: "POST",
        url: '../../Profesionales/BuscarProfesional',
        data: { ProfesionalID: profesionalID},
        success: function (profesional) {
            $("#Nombre").val(profesional.nombre);
            $("#Apellido").val(profesional.apellido);
           
            $("#exampleModal").modal("show");
        },
        error: function (data) {
        }
    });
}
//Funcion para eliminar el profesional


function Eliminarprofesional(profesionalID) {
    var mensajeEliminar = "¿Esta seguro que quiere ELIMINAR al Profesional?"
    swal({
        title: mensajeEliminar,
        text: "Se eliminaran sus horarios y el registro de sus turnos.",
        buttons: ["Cancelar", "Aceptar"],
    }).then(
        function (isConfirm) {
            if (isConfirm) {
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
        });
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
