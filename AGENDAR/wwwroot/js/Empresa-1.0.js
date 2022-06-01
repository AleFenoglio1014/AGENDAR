// Funcion para Completar la Tabla de Empresas
function CompletarTablaEmpresas() {
    VaciarFormulario();
    $.ajax({
        type: "POST",
        url: '../../Empresas/BuscarEmpresa',
        data: {},
        success: function (listadoEmpresasMostrar) {
            $("#tbody-empresa").empty();
            $.each(listadoLocalidadesMostrar, function (index, empresa) {

                let claseEliminado = '';
                let botones = '<button type="button" onclick="BuscarEmpresa(' + empresa.empresaID + ',' + empresa.localidadID + ')" class="btn btn-outline-primary btn-sm" style="margin-right:5px"><i class="bi bi-pencil-square"></i> Editar</button>' +
                    '<button type="button" onclick="DesactivarEmpresa(' + empresa.empresaID + ',1)" class="btn btn-outline-danger btn-sm"><i class="bi bi-trash-fill"></i> Desacctivar</button>';

                if (empresa.eliminado) {
                    claseEliminado = 'table-danger';
                    botones = '<button type="button" onclick="DesactivarEmpresa(' + empresa.empresaID + ',0)" class="btn btn-outline-success btn-sm"><i class="bi bi-folder-symlink"></i> Activar</button>';
                }

                $("#tbody-empresa").append('<tr class=' + claseEliminado + '>' +
                    '<td>' + empresa.descripcion + '</td>' +
                    '<td>' + empresa.localidadID + '</td>' +
                    '<td>' + empresa.clasificacionEmpresaID + '</td>' +
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
    $("#titulo-Modal-Empresa").text("Registrar una Nueva Empresa");
    $("#EmpresaID").val(0);
    $("#exampleModal").modal("show");
}

// FUncion para Guardar las Empresas
function GuardarEmpresas() {
    $("#Error-LocalidadNombre").text("");
    let localidadID = $('#LocalidadID').val();
    let guardarlocalidad = $('#LocalidadNombre').val().trim();
    let provinciaID = $('#ProvinciaID').val();
    if (guardarlocalidad != "" && guardarlocalidad != null) {
        $.ajax({
            type: "POST",
            url: '../../Localidades/GuardarLocalidad',
            data: { LocalidadID: localidadID, Descripcion: guardarlocalidad, ProvinciaID: provinciaID },
            success: function (resultado) {
                if (resultado == 0) {
                    $("#exampleModal").modal("hide");
                    CompletarTablaLocalidades();
                }
                if (resultado == 2) {
                    $("#Error-LocalidadNombre").text("La Localidad ingresada Ya Existe. Ingrese una Nueva Localidad");
                }
            },
            error: function (data) {
            }
        });
    }
    else {
        $("#Error-LocalidadNombre").text("Debe ingresar un Nombre para la Localidad.");
    }
}

 // Funcion para Buscar las Empresas

function BuscarEmpresas(empresaID, localidadID, provinciaID) {
    $("#titulo-Modal-Empresas").text("Editar Empresa");
    $("#EmpresaID").val(empresaID);
    $("#LocalidadID").val(localidadID);
    $("#ProvinciaID").val(provinciaID);
    $.ajax({
        type: "POST",
        url: '../../Empresas/BuscarEmpresas',
        data: { EmpresaID: empresaID, LocalidadID: localidadID, ProvinciaID: provinciaID },
        success: function (empresa) {
            $("#EmpresaNombre").val(empresa.descripcion);
            $("#LocalidadNombre").val(empresa.localidadID);
            $("#ProvinciaNombre").val(empresa.provinciaID);
            $("#exampleModal").modal("show");
        },
        error: function (data) {
        }
    });
}