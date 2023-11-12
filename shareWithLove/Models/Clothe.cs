using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shareWithLove.Models;

[Table("clothe")]
public class Clothe
{
    [Key, Column("id")]
    public string Id { get; set; } = string.Empty;
    [Column("ownerid")]
    public string OwnerId { get; set; } = string.Empty;
    [Column("donateid")]
    public string? DonateId { get; set; }
    [Column("name")]
    public string Name { get; set; } = string.Empty;
    [Column("size")]
    public string Size { get; set; } = string.Empty;
    //public virtual User Owner { get; set; }
    //public virtual User? Donate { get; set; }
   
}

