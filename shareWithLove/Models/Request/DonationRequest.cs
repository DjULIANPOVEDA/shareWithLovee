using System.ComponentModel.DataAnnotations.Schema;

namespace shareWithLove.Models.Request
{
    public class DonationRequest
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;

    }
}
