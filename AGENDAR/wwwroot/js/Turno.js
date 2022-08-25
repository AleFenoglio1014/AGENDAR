function VaciarFormulario() {
    $("#TurnoID").val(0);
    $("#Nombre").val('');
    $("#Apellido").val('');
    $("#Email").val('');
    $("#Telefono").val('');
    $("#Fecha").val('');
    $("#ProvinciaID").val(0);
    $("#LocalidadID").val(0);
    $("#ClasificacionEmpresaID").val(0);
    $("#EmpresaID").val(0);
    $("#ClasificacionProfesionalID").val(0);
    $("#HorariosID").val(0);
    $("#ProfesionalID").val(0);
    
}
//funcion para traer las localidades que pertenecen a la provincia seleccionada
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

//funcion para traer las empresas que pertenecen a la localidad seleccionada
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

//funcion para traer las empresas que pertenecen a la actividad seleccionada
$("#ClasificacionEmpresaID").change(function () {
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
        data: { id: $("#ClasificacionEmpresaID").val() },
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
//funcion para traer los profesionales que pertenecen a la actividad seleccionada
$("#ClasificacionProfesionalID").change(function () {
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
        data: { id: $("#ClasificacionProfesionalID").val() },
        //En caso de resultado exitoso
        success: function (profesionales) {
            if (profesionales.length == 0) {
                $("#ProfesionalID").append('<option value="' + "0" + '">' + "[NO EXISTEN EMPRESAS]" + '</option>');
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

//funcion para traer los profesionales que pertenecen a la actividad seleccionada
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
                $("#ProfesionalID").append('<option value="' + "0" + '">' + "[NO EXISTEN EMPRESAS]" + '</option>');
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