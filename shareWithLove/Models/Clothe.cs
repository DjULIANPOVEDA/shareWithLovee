using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shareWithLove.Models;

[Table("Clothe")]
public class Clothe
{
    [Key, Column("id")]
    public string Id { get; set; } = null!;
    [Column("propietario")]
    public string IdUser { get; set; } = null!;
    [Column("nombre")]
    public string Name { get; set; } = null!;
    
    
    public string? AlquiladorId { get; set; }
    public virtual User Us { get; set; }
    public virtual User? Donor { get; set; }
    public virtual User? Donee { get; set; }
}

