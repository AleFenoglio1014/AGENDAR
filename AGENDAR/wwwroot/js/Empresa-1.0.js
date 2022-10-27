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

                let claseEliminado = '';

                let botones = '<button type="button" onclick="BuscarEmpresa(' + empresa.empresaID + ')" class="btn btn-outline-primary btn-sm" style="margin-right:5px"><i class="bi bi-pencil-square"></i></button>' +
                              '<button type="button" onclick="ActivarEmpresa(' + empresa.empresaID + ',1)" class="btn btn-outline-danger btn-sm"> <i class="bi bi-x-lg"></i> </button>';


                if (empresa.eliminado) {
                    claseEliminado = 'table-danger';
                    botones =  '<button type="button" onclick="ActivarEmpresa(' + empresa.empresaID + ',0)" class="btn btn-outline-success btn-sm"><i class="bi bi-check-circle"></i></button>';

                }

                $("#tbody-empresa").append('<tr class=' + claseEliminado + '>' +
                    '<td class="text-center">' + empresa.razonSocial + '</td>' +
                    '<td class="text-center">' + empresa.localidadNombre + '</td>' +
                    '<td class="text-center">' + empresa.direccion + '</td>' +
                    '<td class="text-center ocultar767">' + empresa.telefono + '</td>' +
                    '<td class="text-center ocultar767">' + empresa.cuit + '</td>' +
                    '<td class="text-center ocultar767">' + "<img class=' card-tamaño ' src='data:img/jpeg;base64," + empresa.imagenEmpresaString + "' />" + '</td >' +
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

 // Funcion para Buscar las Empresas

function BuscarEmpresa(empresaID) {
    
    $("#titulo-Modal-Empresa").text("EDITAR EMPRESA");
    $("#EmpresaID").val(empresaID);

 
    $.ajax({
        type: "POST",
        url: '../../Empresas/BuscarEmpresa',
        data: {  EmpresaID: empresaID },
        success: function (empresa) {
            $("#EmpresaID").val(empresa.empresaID);
            $("#RazonSocial").val(empresa.razonSocial);
            $("#LocalidadID").val(empresa.localidadID);
            $("#Telefono").val(empresa.telefono);
            $("#Cuit").val(empresa.cuit);
            $("#Direccion").val(empresa.direccion);
            $("#div-imagenActual").empty();
            $("#div-imagenActual").append('<img src="data:' + empresa.imagenEmpresaString + ';base64, ' + empresa.imagenBase64 + '" class="tamañoImagen ">');

            
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
    $("#LocalidadID").val(0);
    $("#Cuit").val('');
    $("#Direccion").val('');
    $("#Telefono").val('');
    $("#Error-RazonSocial").text("");
    $("#Error-CamposEmpresas").text("");
}

//Funcion para eliminar la empresa

function ActivarEmpresa(empresaID, elimina) {
    if (elimina == 1) {
        var mensajeEliminar = "¿Esta seguro que quiere DESACTIVAR la Empresa?"
    } else {
        var mensajeEliminar = "¿Esta seguro que quiere ACTIVAR la Empresa?"

    }
    if (confirm(mensajeEliminar)) {
        $.ajax({
            type: "POST",
            url: '../../Empresas/ActivarEmpresa',
            data: { EmpresaID: empresaID, Elimina: elimina },
            success: function (empresa) {

                CompletarTablaEmpresas();
            },
            error: function (data) {
            }
        });
    }
}
function VerImagen() {
    $("#imagen-ver").addClass("ocultar");
    $("#blah").removeClass("ocultar");
    $("#imagen-ocultar").removeClass("ocultar");
}

function OcultarImagen() {
    $("#imagen-ver").removeClass("ocultar");
    $("#blah").addClass("ocultar");
    $("#imagen-ocultar").addClass("ocultar");
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
    let archivo = $('#Archivo').val();

    let guardarEmpresa = true;

    if (razonSocial == "" || razonSocial == null) {
        guardarEmpresa = false;
        $("#Error-CamposEmpresas").text("Los campos son OBLIGATORIOS.");
    }
    if (localidadID == 0) {
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
        $("#btn-guardar").addClass("ocultar");
        $("#btn-guardar-espere").removeClass("ocultar");
        //realizamos la petición ajax con la función de jquery
        $.ajax({
            type: "POST",
            url: url,
            data: parametros,
            contentType: false, //importante enviar este parametro en false
            processData: false, //importante enviar este parametro en false
            success: function (resultado) {
             
                if (resultado == 0) {
                    $("#btn-guardar").removeClass("ocultar");
                    $("#btn-guardar-espere").addClass("ocultar");
                    CompletarTablaEmpresas();
                    VaciarFormulario();
                    swal({
                        title: "¡ESPERE A QUE SU EMPRESA SEA ACTIVADA...!",
                        text: "Mientas tanto cree sus Profesionales y sus Horarios",
                        icon: "success",
                        button: "¡Entendido!",
                    }).then(function () {
                        window.location.href = '/Profesionales';
                    });
                  
                }
              
               else  if (resultado == 2) {
                    $("#Error-RazonSocial").text("La Empresa ingresada Ya Existe. Ingrese una Nueva Empresa");
                }
                else if (resultado == 3) {
                    CompletarTablaEmpresas();
                    VaciarFormulario();
                    $("#exampleModal").modal("hide");

                   

                }
            },
            error: function (r) {

                swal("Error del servidor");
            }
        });
    }
    else {
        $("#Error-CamposEmpresas").text("Los campos son OBLIGATORIOS.");
    }
}
// Funcion para limitar los caracteres de los input
var input = document.getElementById('RazonSocial');
input.addEventListener('input', function () {
    if (this.value.length > 40)
        swal("HA SUPERADO EL LIMITE DE CARACTERES PERMITIDO.");
        this.value = this.value.slice(0, 40)
})

var input = document.getElementById('Telefono');
input.addEventListener('input', function () {
    if (this.value.length > 15)
        swal("HA SUPERADO EL LIMITE DE CARACTERES PERMITIDO.");
        this.value = this.value.slice(0, 15);
})
var input = document.getElementById('Cuit');
input.addEventListener('input', function () {
    if (this.value.length > 11)
        swal("HA SUPERADO EL LIMITE DE CARACTERES PERMITIDO.");
        this.value = this.value.slice(0, 11);
})
var input = document.getElementById('Direccion');
input.addEventListener('input', function () {
    if (this.value.length > 30)
        swal("HA SUPERADO EL LIMITE DE CARACTERES PERMITIDO.");
        this.value = this.value.slice(0, 30);
})


//Funcion para renderizar la imagen 
function readImage(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#blah').attr('src', e.target.result); // Renderizamos la imagen
        }
        reader.readAsDataURL(input.files[0]);
    }
}

$("#Archivo").change(function () {
    // Código a ejecutar cuando se detecta un cambio de archivO
    readImage(this);
});