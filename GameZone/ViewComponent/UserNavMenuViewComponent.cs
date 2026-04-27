using GameZone.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

public class UserNavMenuViewComponent : ViewComponent
{
    private readonly ICurrentUserServices _currentUser;

    public UserNavMenuViewComponent(ICurrentUserServices currentUser)
    {
        _currentUser = currentUser;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var user = await _currentUser.GetCurrentUserAsync();
        return View(user);
    }
}