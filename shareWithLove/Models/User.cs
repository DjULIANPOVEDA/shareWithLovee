using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shareWithLove.Models;

[Table("appuser")]
public class User
{
    [Key, Column("id")]
    public string Id { get; set; } = string.Empty;
    [Column("username")]
    public string UserName { get; set; } = string.Empty;
    [Column("password")]
    public string Password { get; set; } = string.Empty;
    [Column("phone")]
    public string Phone { get; set; } = string.Empty;
    [Column("email")]
    public string Email { get; set; } = string.Empty;
    [Column("address")]
    public string Address { get; set; } = string.Empty;

    public virtual ICollection<Clothe> OwnerClothes { get; set; }
    public virtual ICollection<Clothe> DonatedClothes { get; set; }
}
