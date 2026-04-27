namespace GameZone.Models
{
    public class Game : BaseEntity
    {

        public string Description { get; set; } = null!;

        public string Cover { get; set; } = null!;

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public ICollection<Gamedevice> Gamedevices { get; set; } = new List<Gamedevice>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
