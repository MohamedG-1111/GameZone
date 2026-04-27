namespace GameZone.ViewModels.Game
{
    public class GetAllGames
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;



        public string Cover { get; set; } = null!;

        public string CategoryName { get; set; } = null!;

        public List<string> DeviceNames { get; set; } = new List<string>();

    }
}
