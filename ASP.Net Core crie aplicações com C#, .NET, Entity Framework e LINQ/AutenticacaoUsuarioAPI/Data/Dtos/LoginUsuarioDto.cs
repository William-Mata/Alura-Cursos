using System.ComponentModel.DataAnnotations;

namespace AutenticacaoUsuarioAPI.Data.Dtos
{
    public class LoginUsuarioDto
    {

        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}