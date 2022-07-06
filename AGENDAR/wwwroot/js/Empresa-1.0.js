// Funcion para Completar la Tabla de Empresas
function CompletarTablaEmpresas() {
    VaciarFormulario();
    $.ajax({
        type: "POST",
        url: '../../Empresas/BuscarEmpresas',
        data: {},
        success: function (listadoEmpresasMostrar) {
            $("#tbody-empresa").empty();
            $.each(listadoEmpresasMostrar, function (index, empresa) {
                $("#tbody-empresa").append('<tr>' +
                    '<td class="text-center">' + empresa.razonSocial + '</td>' +
                    '<td class="text-center">' + empresa.cuit + '</td>' +
                    '<td class="text-center">' + empresa.direccion + '</td>' +
                    '<td class="text-center">' + empresa.telefono + '</td>' +
                    '<td class="text-center">' + empresa.localidadNombre + '</td>' +
                    '<td class="text-center">' + empresa.tipoEmpresa + '</td>' +
                    '<td class="text-center">' + '<button type="button" onclick="BuscarEmpresa(' + empresa.empresaID + ',' + empresa.localidadID + ')" class="btn btn-outline-primary btn-sm" style="margin-right:5px"><i class="bi bi-pencil-square"></i></button>'  +
                    '<button type="button" onclick="EliminarEmpresa(' + empresa.empresaID + ',1)" class="btn btn-outline-danger btn-sm"><i class="bi bi-trash-fill"></i></button>' + '</td>' +
                    '</tr>');
            });
        },
        error: function (data) {
        }
    });
}

//Funcion Abrir Modal
function AbrirModal() {
    $("#titulo-Modal-Empresa").text("Registrar una Nueva Empresa");
    $("#EmpresaID").val(0);
    $("#exampleModal").modal("show");
}

// FUncion para Guardar las Empresas
//function GuardarEmpresa() {
//    /*VaciarFormulario();*/
//    $("#Error-RazonSocial").text("");
//    $("#Error-CamposEmpresas").text("");
//    let empresaID = $('#EmpresaID').val();
//    let cuit = $('#Cuit').val();
//    let direccion = $('#Direccion').val();
//    let telefono = $('#Telefono').val();
//    let razonSocial = $('#RazonSocial').val().trim();
//    let localidadID = $('#LocalidadID').val();
//    let clasificacionEmpresaID = $('#ClasificacionEmpresaID').val();

//    let guardarEmpresa = true;

//    if (razonSocial == "" || razonSocial == null) {
//        guardarEmpresa = false;
//        $("#Error-CamposEmpresas").text("Los campos son OBLIGATORIOS.");
//    }
//    if (localidadID == "" || localidadID == null) {
//        guardarEmpresa = false;
//        $("#Error-CamposEmpresas").text("Los campos son OBLIGATORIOS.");
//    }
//    if (clasificacionEmpresaID == "" || clasificacionEmpresaID == null) {
//        guardarEmpresa = false;
//        $("#Error-CamposEmpresas").text("Los campos son OBLIGATORIOS.");
//    }
//    if (cuit == "" || cuit == null) {
//        guardarEmpresa = false;
//        $("#Error-CamposEmpresas").text("Los campos son OBLIGATORIOS.");
//    }
//    if (direccion == "" || direccion == null) {
//            guardarEmpresa = false;
//            $("#Error-CamposEmpresas").text("Los campos son OBLIGATORIOS.");
//    }
//    if (telefono == "" || telefono == null) {
//        guardarEmpresa = false;
//        $("#Error-CamposEmpresas").text("Los campos son OBLIGATORIOS.");
//    }


//    if (guardarEmpresa) {
//        $.ajax({
//            type: "POST",
//            url: '../../Empresas/GuardarEmpresa',
//            data: { EmpresaID: empresaID, RazonSocial: razonSocial, Cuit: cuit, Direccion: direccion, Telefono: telefono, LocalidadID: localidadID, ClasificacionEmpresaID: clasificacionEmpresaID},
//            success: function (resultado) {
//                if (resultado == 0) {
//                    $("#exampleModal").modal("hide");
//                    CompletarTablaEmpresas();
//                }
//                if (resultado == 2) {
//                    $("#Error-RazonSocial").text("La Empresa ingresada Ya Existe. Ingrese una Nueva Empresa");
//                }
//            },
//            error: function (data) {
//            }
//        });
//    }
//    else {
//        $("#Error-CamposEmpresas").text("Los campos son OBLIGATORIOS.");
//    }
//}


 // Funcion para Buscar las Empresas

function BuscarEmpresa(empresaID) {
    
    $("#titulo-Modal-Empresa").text("Editar Empresa");
    $("#EmpresaID").val(empresaID);
 
    $.ajax({
        type: "POST",
        url: '../../Empresas/BuscarEmpresa',
        data: {  EmpresaID: empresaID },
        success: function (empresa) {
            $("#EmpresaID").val(empresa.empresaID);
            $("#RazonSocial").val(empresa.razonSocial);
            $("#LocalidadID").val(empresa.localidadID);
            $("#ClasificacionEmpresaID").val(empresa.clasificacionEmpresaID);
            $("#Telefono").val(empresa.telefono);
            $("#Cuit").val(empresa.cuit);
            $("#Direccion").val(empresa.direccion);
            
    
            $("#exampleModal").modal("show");
        },
        error: function (data) {
        }
    });
}


//Funcion para Vaciar el Formulario

function VaciarFormulario() {
    $("#EmpresaID").val(0);
    $("#RazonSocial").val('');
    $("#ClasificacionEmpresaID").val(0);
    $("#LocalidadID").val(0);
    $("#Cuit").val('');
    $("#Direccion").val('');
    $("#Telefono").val('');
    $("#Archivo").val('');
    $("#Error-RazonSocial").text("");
    $("#Error-CamposEmpresas").text("");
}

//Funcion para eliminar la empresa


function EliminarEmpresa(empresID) {
    var mensajeEliminar = "¿Esta seguro que quiere ELIMINAR la Empresa?"
    if (confirm(mensajeEliminar)) {
    $.ajax({
        type: "POST",
        url: '../../Empresas/EliminarEmpresa',
        data: { EmpresaID: empresID },
        success: function (empresa) {

            CompletarTablaEmpresas();
        },
        error: function (data) {
        }
    });
    }
}
// FUncion para Guardar las Empresas




function GuardarEmpresa() {
 $("#Error-RazonSocial").text("");
 $("#Error-CamposEmpresas").text("");

    let url = "../../Empresas/GuardarEmpresa";
    var parametros = new FormData($("#frmFormulario")[0]);

  
    let cuit = $('#Cuit').val();
    let direccion = $('#Direccion').val();
    let telefono = $('#Telefono').val();
    let razonSocial = $('#RazonSocial').val().trim();
    let localidadID = $('#LocalidadID').val();
    let clasificacionEmpresaID = $('#ClasificacionEmpresaID').val();
    let archivo = $('#Archivo').val();

    let guardarEmpresa = true;

    if (razonSocial == "" || razonSocial == null) {
        guardarEmpresa = false;
        $("#Error-CamposEmpresas").text("Los campos son OBLIGATORIOS.");
    }
    if (localidadID == "" || localidadID == null) {
        guardarEmpresa = false;
        $("#Error-CamposEmpresas").text("Los campos son OBLIGATORIOS.");
    }
    if (clasificacionEmpresaID == "" || clasificacionEmpresaID == null) {
        guardarEmpresa = false;
        $("#Error-CamposEmpresas").text("Los campos son OBLIGATORIOS.");
    }
    if (cuit == "" || cuit == null) {
        guardarEmpresa = false;
        $("#Error-CamposEmpresas").text("Los campos son OBLIGATORIOS.");
    }
    if (direccion == "" || direccion == null) {
        guardarEmpresa = false;
        $("#Error-CamposEmpresas").text("Los campos son OBLIGATORIOS.");
    }
    if (telefono == "" || telefono == null) {
        guardarEmpresa = false;
        $("#Error-CamposEmpresas").text("Los campos son OBLIGATORIOS.");
    }
    if (archivo == "" || archivo == null) {
        guardarEmpresa = false;
        $("#Error-CamposEmpresas").text("Los campos son OBLIGATORIOS.");
    }



    if (guardarEmpresa) {
        //realizamos la petición ajax con la función de jquery
        $.ajax({
            type: "POST",
            url: url,
            data: parametros,
            contentType: false, //importante enviar este parametro en false
            processData: false, //importante enviar este parametro en false
            success: function (resultado) {

                if (resultado == 0) {
                    $("#exampleModal").modal("hide");
                    CompletarTablaEmpresas();
                }
                if (resultado == 2) {
                    $("#Error-RazonSocial").text("La Empresa ingresada Ya Existe. Ingrese una Nueva Empresa");
                }
            },
            error: function (r) {

                alert("Error del servidor");
            }
        });
    }
    else {
        $("#Error-CamposEmpresas").text("Los campos son OBLIGATORIOS.");
    }
}

