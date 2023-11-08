using System.ComponentModel.DataAnnotations.Schema;
namespace shareWithLove.Models.Response
{
    public class DonacionResponse
    {
        public string Id { get; set; } = null!;
        public string Prenda{ get; set; } = null!;
        public string talla { get; set; } = null!;
        public bool Donado { get; set; }

    }
}
