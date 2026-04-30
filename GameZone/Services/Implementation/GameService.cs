using GameZone.Data.Repositories.Interfaces;
using GameZone.Models;
using GameZone.Services.Interfaces;
using GameZone.ViewModels.Game;
using GameZone.ViewModels.Review;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Services.Implementation
{
    public class GameService : IGameService
    {
        private readonly IAttachmentService attachmentService;
        private readonly ICategoryServices _categoryServices;
        private readonly IDevicesServices _devicesServices;
        private readonly IReviewServices reviewServic;
        private readonly ICurrentUserServices currentUserService;
        private readonly IUnitOfWork _unitOfWork;

        public GameService(IUnitOfWork unitOfWork, IAttachmentService attachmentService,
            ICategoryServices categoryServices,
            IDevicesServices devicesServices,
            IReviewServices reviewServic,
            ICurrentUserServices currentUserService)
        {
            _unitOfWork = unitOfWork;
            this.attachmentService = attachmentService;
            _categoryServices = categoryServices;
            _devicesServices = devicesServices;
            this.reviewServic = reviewServic;
            this.currentUserService = currentUserService;
        }
        public async Task<List<GetAllGames>> GetAllGamesAsync()
        {
            return await _unitOfWork.Repository<Game>().GetAsQuery()
                .Select(g => new GetAllGames
                {
                    Id = g.Id,
                    Name = g.Name,
                    Cover = g.Cover,
                    CategoryName = g.Category.Name,
                    DeviceNames = g.Gamedevices.Select(gd => gd.Device.Icon).ToList()
                })
                .ToListAsync();
        }
        public async Task<GetGameDetails?> GetGameDetails(int Id)
        {


            var game = await _unitOfWork.Repository<Game>().GetAsQuery()
          .Where(g => g.Id == Id)
          .Select(g => new GetGameDetails
          {
              GameId = g.Id,
              Name = g.Name,
              Description = g.Description,
              Cover = g.Cover,
              CategoryName = g.Category.Name,
              DeviceNames = g.Gamedevices.Select(gd => gd.Device.Icon).ToList(),
              AverageRating = g.Reviews.Any()
            ? g.Reviews.Average(r => r.Rating)
            : 0,

              AverageCount = g.Reviews.Count()

          })
          .FirstOrDefaultAsync();
            if (game != null && !string.IsNullOrEmpty(currentUserService.UserId))
            {
                game.UserReview = await reviewServic.GetMyReviewForGame(Id);
                if (game.UserReview == null)
                {
                    game.UserReview = new ReviewViewModel
                    {
                        GameId = Id
                    };
                }
            }
            return game;


        }


        public async Task CreateGameAsync(CreateGameViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var Game = new Game
            {
                Name = model.Name,
                Description = model.Description,
                CategoryId = model.CategoryId,
                Cover = model.Cover != null
                ? await attachmentService.UploadAttachmentAsync(model.Cover)
                   : null,
                Gamedevices = model.SelectedDevices?.Select(d => new Gamedevice { DeviceId = d }).ToList()!
            };
            var repo = _unitOfWork.Repository<Game>();
            await repo.AddAsync(Game);
            await _unitOfWork.SaveChangesAsync();
        }


        public async Task<EditGameViwModel> GetGameToEditAsync(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentException("Invalid game ID.", nameof(Id));
            }
            return await _unitOfWork.Repository<Game>().GetAsQuery()
                .Where(g => g.Id == Id)
                .Select(g => new EditGameViwModel
                {
                    Name = g.Name,
                    Description = g.Description,
                    CategoryId = g.CategoryId,
                    ExistingCover = g.Cover,
                    SelectedDevices = g.Gamedevices.Select(gd => gd.DeviceId).ToList(),
                    Categories = _categoryServices.Categories(),
                    Devices = _devicesServices.Devices(),
                })
                .FirstOrDefaultAsync();

        }
        public async Task<bool> EditGameAsync(int Id, EditGameViwModel model)
        {
            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var Game = await _unitOfWork.Repository<Game>().GetAsQuery()
               .Include(g => g.Gamedevices)
                .FirstOrDefaultAsync(g => g.Id == Id);
                if (Game == null) return false;
                Game.Name = model.Name;
                Game.Description = model.Description;
                Game.CategoryId = model.CategoryId;
                if (model.Cover != null)
                {
                    await attachmentService.DeleteAttachmentAsync(Game.Cover);
                    Game.Cover = await attachmentService.UploadAttachmentAsync(model.Cover);
                }
                Game.Gamedevices = model.SelectedDevices.Select(d => new Gamedevice { DeviceId = d }).ToList();


                await _unitOfWork.SaveChangesAsync();
                await transaction.CommitAsync();

                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                return false;
            }


        }

        public async Task<bool> DeleteGameAsync(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentException("Invalid game ID.", nameof(Id));
            }
            var repo = _unitOfWork.Repository<Game>();
            var Game = await repo.FindAsync(Id);
            if (Game == null) return false;
            repo.Delete(Game);
            var IsDeleted = await _unitOfWork.SaveChangesAsync();
            if (IsDeleted > 0)
                await attachmentService.DeleteAttachmentAsync(Game.Cover);
            return IsDeleted > 0;
        }

        public Task<Game?> GetGameByIdAsync(int Id)
        {
            return _unitOfWork.Repository<Game>().GetAsQuery().FirstOrDefaultAsync(g => g.Id == Id);
        }

        public async Task<bool> CheckNameAsync(string Name)
        {
            var IsExisted = await _unitOfWork.Repository<Game>().AnyAsync(g => g.Name.ToLower() == Name.ToLower());
            return IsExisted;
        }
    }
}