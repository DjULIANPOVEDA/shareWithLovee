using System.ComponentModel.DataAnnotations.Schema;

namespace shareWithLove.Models.Request
{
    public class DonationRequest
    {
        public string Id { get; set; } = null!;
        public string Clothe{ get; set; } = null!;
        public string Size { get; set; } = null!;
        public string State { get; set; } = null!;

    }
}
