using GameZone.Models;
using GameZone.Services.Interfaces;
using GameZone.ViewModels.Game;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        private readonly ICategoryServices _categoryServices;
        private readonly IDevicesServices _devicesServices;


        private readonly IGameService _gameService;

        public GamesController(ICategoryServices categoryServices,
            IDevicesServices devicesServices, IGameService gameService)
        {
            _categoryServices = categoryServices;
            _devicesServices = devicesServices;
            _gameService = gameService;
        }

        public async Task<IActionResult> Index()
        {
            var Model = await _gameService.GetAllGamesAsync();
            return View(Model);
        }
        [HttpGet]
        public async Task<IActionResult> Details([FromRoute] int Id)
        {
            var gameDetails = await _gameService.GetGameDetails(Id);
            if (gameDetails == null)
            {
                return NotFound();
            }


            return View(gameDetails);
        }

        [HttpGet]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> Edit(int Id)
        {
            var game = await _gameService.GetGameToEditAsync(Id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int Id, EditGameViwModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoryServices.Categories();
                model.Devices = _devicesServices.Devices();
                return View(model);
            }
            var IsExisted = await _gameService.EditGameAsync(Id, model);
            if (!IsExisted)
                return NotFound();
            TempData["SucessMessage"] = "Edit Successfully";
            return RedirectToAction(nameof(Index));

        }


        [HttpGet]
        [Authorize(Roles = Roles.Admin)]
        public IActionResult Create()
        {
            CreateGameViewModel model = new()
            {
                Categories = _categoryServices.Categories(),

                Devices = _devicesServices.Devices(),

            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGameViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoryServices.Categories();
                model.Devices = _devicesServices.Devices();
                return View(model);
            }
            await _gameService.CreateGameAsync(model);
            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> Delete(int id)
        {
            var game = await _gameService.GetGameByIdAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var IsExisted = await _gameService.DeleteGameAsync(id);
            if (!IsExisted)
                return NotFound();
            TempData["SucessMessage"] = "Delete Successfully";
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> CheckName(string Name)
        {
            var IsExisted = await _gameService.CheckNameAsync(Name);
            return Json(!IsExisted);
        }
    }
}
