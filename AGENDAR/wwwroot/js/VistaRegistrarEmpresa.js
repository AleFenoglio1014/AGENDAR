////function VistaEmpresa() {
////    VaciarFormulario();
////    $.ajax({
////        type: "POST",
////        url: '../../Empresas/',
////        data: {},
////        success: function (listadoEmpresasMostrar) {
////            $("#tbody-empresa").empty();
////            $.each(listadoEmpresasMostrar, function (index, empresa) {

////                let claseEliminado = '';
////                let botones = '<button type="button" onclick="BuscarEmpresa(' + empresa.empresaID + ')" class="btn btn-outline-primary btn-sm" style="margin-right:5px"><i class="bi bi-pencil-square"></i></button>' +
////                    '<button type="button" onclick="DesactivarEmpresa(' + empresa.empresaID + ',1)" class="btn btn-outline-danger btn-sm"><i class="bi bi-trash-fill"></i></button>';

////                if (empresa.eliminado) {
////                    claseEliminado = 'table-danger';
////                    botones = '<button type="button" onclick="DesactivarEmpresa(' + empresa.empresaID + ',0)" class="btn btn-outline-success btn-sm"><i class="bi bi-folder-symlink"></i></button>';
////                }

////                $("#tbody-empresa").append('<tr class=>' + claseEliminado + '>' +
////                    '<td class="text-center">' + empresa.razonSocial + '</td>' +
////                    '<td class="text-center">' + empresa.cuit + '</td>' +
////                    '<td class="text-center">' + empresa.direccion + '</td>' +
////                    '<td class="text-center">' + empresa.telefono + '</td>' +
////                    '<td class="text-center">' + empresa.localidadNombre + '</td>' +
////                    '<td class="text-center">' + empresa.tipoEmpresa + '</td>' +
////                    '<td>' + "<img class=' card-tamaño' src='data:img/jpeg;base64," + empresa.imagenEmpresaString + "' />" + '</td >' +
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