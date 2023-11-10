using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace shareWithLove.Models.Response
{
    public class UserResponse
    {
        public string Id { get; set; } = null!;
        public string Rol { get; set; } = string.Empty;
        public string Username { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? Token { get; set; }

    }
}
