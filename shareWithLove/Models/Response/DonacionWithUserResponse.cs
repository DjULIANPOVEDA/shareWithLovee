
namespace shareWithLove.Models.Response
{
    public class DonacionWithUserResponse
    {
        public string Id { get; set; } = null!;
        public string prenda { get; set; } = null!;
        public string talla { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public virtual UsuarioResponse Usuario { get; set; }
    }
}
