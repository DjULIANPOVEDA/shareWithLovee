
namespace shareWithLove.Models.Response
{
    public class DonationWithUserResponse
    {
        public string Id { get; set; } = null!;
        public string Clothe{ get; set; } = null!;
        public string Size { get; set; } = null!;
        public string State { get; set; } = null!;
        public virtual UserResponse User { get; set; }
    }
}
