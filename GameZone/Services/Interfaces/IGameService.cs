using GameZone.Models;
using GameZone.ViewModels.Game;

namespace GameZone.Services.Interfaces
{
    public interface IGameService
    {
        public Task<Game?> GetGameByIdAsync(int Id);
        public Task CreateGameAsync(CreateGameViewModel model);
        public Task<List<GetAllGames>> GetAllGamesAsync();
        public Task<GetGameDetails?> GetGameDetails(int Id);
        public Task<EditGameViwModel> GetGameToEditAsync(int Id);
        public Task<bool> EditGameAsync(int Id, EditGameViwModel model);

        public Task<bool> DeleteGameAsync(int Id);

        public bool CheckName(string Name);
    }
}
