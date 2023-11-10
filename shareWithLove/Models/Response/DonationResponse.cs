using System.ComponentModel.DataAnnotations.Schema;
namespace shareWithLove.Models.Response
{
    public class DonationResponse
    {
        public string Id { get; set; } = null!;
        public string Clothe{ get; set; } = null!;
        public string Size { get; set; } = null!;
        public bool Donated { get; set; }

    }
}
