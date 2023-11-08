using System.ComponentModel.DataAnnotations.Schema;

namespace shareWithLove.Models.Request
{
    public class DonacionRequest
    {
        public string prenda{ get; set; } = null!;
        public string talla { get; set; } = null!;
        public string Estado { get; set; } = null!;

    }
}
