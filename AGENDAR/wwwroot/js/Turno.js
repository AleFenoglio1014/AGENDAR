﻿////// FUNCION PARA COMPLETAR EL CALENDARIO DE TURNO

////function Completarcalendario() {
////    VaciarFormulario();
////    $.ajax({
////        type: "POST",
////        url: '../../Provincias/BuscarProvincias',
////        data: {},
////        success: function (listadoProvincias) {
////            $("#tbody-provincias").empty();
////            $.each(listadoProvincias, function (index, provincia) {

 
////                let botones = '<button type="button" onclick="BuscarProvincia(' + provincia.provinciaID + ')" class="btn btn-outline-primary btn-sm" style="margin-right:5px"><i class="bi bi-pencil-square"></i> Editar</button>';

                

////                $("#tbody-provincias").append('<tr class=>' +
////                    '<td>' + provincia.descripcion + '</td>' +
////                    '<td class="text-center">' +
////                    botones +
////                    '</td>' +
////                    '</tr>');
////            });
////        },
////        error: function (data) {
////        }
////    });
////}

// FUNCION PARA GUARDAR EL TURNO

//function GuardarProvincia() {
//    $("#Error-ProvinciaNombre").text("");
//    let provinciaID = $('#ProvinciaID').val();
//    let guardarprovincia = $('#ProvinciaNombre').val().trim();
//    if (guardarprovincia != "" && guardarprovincia != null) {
//        $.ajax({
//            type: "POST",
//            url: '../../Provincias/GuardarProvincia',
//            data: { ProvinciaID: provinciaID, Descripcion: guardarprovincia },
//            success: function (resultado) {
//                if (resultado == 0) {
//                    $("#exampleModal").modal("hide");
//                    CompletarTablaProvincias();
//                }
//                if (resultado == 2) {
//                    $("#Error-ProvinciaNombre").text("La Provincia ingresada Ya Existe. Ingrese una Nueva Provincia");
//                }
//            },
//            error: function (data) {
//            }
//        });
//    }
//    else {
//        $("#Error-ProvinciaNombre").text("Debe ingresar un Nombre para la Provincia.");
//    }
//}


//FUNCION PARA BORRAR EL CREATE
function VaciarFormulario() {
    $("#TurnoID").val(0);
    $("#Nombre").val('');
    $("#Apellido").val('');
    $("#Email").val('');
    $("#Telefono").val('');
    $("#Fecha").val('');
    $("#ProvinciaID").val(0);
    $("#LocalidadID").val(0);
    $("#EmpresaID").val(0);
    $("#HorariosID").val(0);
    $("#ProfesionalID").val(0);
    
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
            }
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
            }
        },
        ////Mensaje de error en caso de fallo
        error: function (ex) {
        }
    });
    return false;
}


//FUNCION PARA TRAER LOS PROFESIONALES QUE PERTENECEN A LA EMPRESA SELECCIONADA
$("#EmpresaID").change;(function () {
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
        data: {  id: $("#EmpresaID").val() },
        //En caso de resultado exitoso
        success: function (profesionales) {
            if (profesionales.length == 0) {
                $("#ProfesionalID").append('<option value="' + "0" + '">' + "[NO EXISTEN PROFESIONALES]" + '</option>');
            }
            else {
                $.each(profesionales, function (i, profesional) {
                    $("#ProfesionalID").append('<option value="' + profesional.value + '">' +
                        profesional.text + '</option>');
                });
            }
        },
        ////Mensaje de error en caso de fallo
        error: function (ex) {
        }
    });
    return false;
}

