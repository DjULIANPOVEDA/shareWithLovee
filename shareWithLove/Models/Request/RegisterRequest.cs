using System.ComponentModel.DataAnnotations.Schema;

namespace shareWithLove.Models.Request

{
    public class RegisterRequest
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Direccion { get; set; } = null!;
    }
}
