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

$("#ProvinciaID").change(function () {
    BuscarLocalidades();
});

//function BuscarLocalidades() {
//    //Se limpia el contenido del dropdownlist
//    $("#LocalidadID").empty();
//    $.ajax({
//        type: 'POST',
//        //Llamado al metodo en el controlador
//        url: "../../Localidades/ComboLocalidad",
//        dataType: 'json',
//        //Parametros que se envian al metodo del controlador
//        data: { id: $("#ProvinciaID").val() },
//        //En caso de resultado exitoso
//        success: function (localidades) {
//            if (localidades.length == 0) {
//                $("#LocalidadID").append('<option value="' + "0" + '">' + "[NO EXISTEN LOCALIDADES]" + '</option>');
//            }
//            else {
//                $.each(localidades, function (i, localidad) {
//                    $("#LocalidadID").append('<option value="' + localidad.value + '">' +
//                        localidad.text + '</option>');
//                });
//            }
//        },
//        ////Mensaje de error en caso de fallo
//        error: function (ex) {
//        }
//    });
//    return false;
//}