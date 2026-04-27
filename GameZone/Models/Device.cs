namespace GameZone.Models
{
    public class Device : BaseEntity
    {


        public string Icon { get; set; } = null!;

        public ICollection<Gamedevice> Gamedevices { get; set; } = new List<Gamedevice>();
    }
}
