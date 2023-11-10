using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shareWithLove.Models;

[Table("usuario")]
public class User
{
    [Key, Column("id")]
    public string Id { get; set; } = null!;
    [Column("rol")]
    public string Rol { get; set; } = null!;
    [Column("username")]
    public string Username { get; set; } = null!;
    [Column("password")]
    public string Password { get; set; } = null!;
    [Column("Phone")]
    public string Phone { get; set; } = null!;
    [Column("Email")]
    public string Email { get; set; } = null!;
    [Column("Address")]
    public string Address { get; set; } = null!;

    public virtual ICollection<Clothe> Clothes { get; set; }

    //public virtual ICollection<Libro> LibrosComprados { get; set; }
    //public virtual ICollection<Libro> LibrosAlquilados { get; set; }
    //public virtual ICollection<Renta> Rentas { get; set; }
}
