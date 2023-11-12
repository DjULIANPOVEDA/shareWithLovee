
namespace shareWithLove.Models.Response
{
    public class DonationWithUserResponse
    {
        public string Id { get; set; } = string.Empty;
        public string OwnerId { get; set; } = string.Empty;
        public string? DonateId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        public virtual UserResponse User { get; set; }
    }
}
