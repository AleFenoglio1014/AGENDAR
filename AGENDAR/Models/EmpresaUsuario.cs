
using System.ComponentModel.DataAnnotations;


namespace AGENDAR.Models
{
    public class EmpresaUsuario
    {
        [Key]

        public int EmpresaUsuarioID { get; set; }

        public string UsuarioID { get; set; }
        public int EmpresaID { get; set; }

    }
}
