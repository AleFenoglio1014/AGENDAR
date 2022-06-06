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
                    '<td>' + empresa.razonSocial + '</td>' +
                    '<td>' + empresa.cuit + '</td>' +
                    '<td>' + empresa.direccion + '</td>' +
                    '<td>' + empresa.telefono + '</td>' +
                    '<td>' + empresa.localidadNombre + '</td>' +
                    '<td>' + empresa.tipoEmpresa + '</td>' +
                    '<td>' + '<button type="button" onclick="BuscarEmpresa(' + empresa.empresaID + ',' + empresa.localidadID + ')" class="btn btn-outline-primary btn-sm" style="margin-right:5px"><i class="bi bi-pencil-square"></i> Editar</button>'  +
                    '<button type="button" onclick="EliminarEmpresa(' + empresa.empresaID + ',1)" class="btn btn-outline-danger btn-sm"><i class="bi bi-trash-fill"></i> Eliminar</button>' + '</td>' +
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
function GuardarEmpresa() {
    $("#Error-RazonSocial").text("");
    let empresaID = $('#EmpresaID').val();
    let cuit = $('#CUIT').val();
    let direccion = $('#Direccion').val();
    let telefono = $('#Telefono').val();
    let guardarempresa = $('#RazonSocial').val().trim();
    let localidadID = $('#LocalidadID').val();
    let clasificacionEmpresaID = $('#ClasificacionEmpresaID').val();
    if (guardarempresa != "" && guardarempresa != null) {
        $.ajax({
            type: "POST",
            url: '../../Empresas/GuardarEmpresa',
            data: { EmpresaID: empresaID, RazonSocial: guardarempresa, CUIT: cuit, Direccion: direccion, Telefono: telefono, LocalidadID: localidadID, ClasificacionEmpresaID: clasificacionEmpresaID},
            success: function (resultado) {
                if (resultado == 0) {
                    $("#exampleModal").modal("hide");
                    CompletarTablaEmpresas();
                }
                if (resultado == 2) {
                    $("#Error-RazonSocial").text("La Empresa ingresada Ya Existe. Ingrese una Nueva Empresa");
                }
            },
            error: function (data) {
            }
        });
    }
    else {
        $("#Error-RazonSocial").text("Debe ingresar una RazonSocial para la Empresa.");
    }
}


 // Funcion para Buscar las Empresas

function BuscarEmpresa(empresaID,razonSocial, localidadID, clasificacionEmpresaID) {
    $("#titulo-Modal-Empresa").text("Editar Empresa");
    $("#EmpresaID").val(empresaID);
    $("#RazonSocial").val(razonSocial);
    $("#LocalidadID").val(localidadID);
    $("#ClasificacionEmpresaID").val(clasificacionEmpresaID);
    $.ajax({
        type: "POST",
        url: '../../Empresas/BuscarEmpresa',
        data: { RazonSocial: razonSocial, EmpresaID: empresaID, LocalidadID: localidadID, ClasificacionEmpresaID: clasificacionEmpresaID },
        success: function (empresa) {
            $("#RazonSocial").val(empresa.razonSocial);
            $("#LocalidadID").val(empresa.localidadID);
            $("#ClasificacionEmpresaID").val(empresa.clasificacionEmpresaID);
            $("#exampleModal").modal("show");
        },
        error: function (data) {
        }
    });
}


//Funcion para Vaciar el Formulario

function VaciarFormulario() {
    $("#EmpresaID").val(0);
    $("#ClasificacionEmpresaID").val(0);
    $("#LocalidadID").val(0);
    $("#CUIT").val('');
    $("#Direccion").val('');
    $("#Telefono").val('');
    $("#Error-RazonSocial").text("");
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
