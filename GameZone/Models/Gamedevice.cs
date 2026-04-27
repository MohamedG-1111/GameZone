namespace GameZone.Models
{
    public class Gamedevice
    {
        public int GameId { get; set; }
        public Game Game { get; set; } = null!;

        public Device Device { get; set; } = null!;
        public int DeviceId { get; set; }

    }
}
