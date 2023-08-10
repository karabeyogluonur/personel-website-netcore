using Microsoft.AspNetCore.Mvc;
using PW.Application.Interfaces.Services.Membership;
using PW.Application.Models.ViewModels.Membership;
using PW.Domain.Entities.Membership;

namespace PW.Web.Areas.Admin.Controllers
{
    public class UserController : BaseAdminController
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            return RedirectToAction("List", "User");
        }

        public async Task<IActionResult> List()
        {
            List<User> users = await _userService.GetAllAsync();

            //TODO: Automapper will be added.

            #region Automapper refactoring
            List<UserListViewModel> userListViewModels = new List<UserListViewModel>();
            foreach (var user in users)
            {
                UserListViewModel userListViewModel = new UserListViewModel();
                userListViewModel.Id = user.Id;
                userListViewModel.FirstName = user.FirstName;
                userListViewModel.LastName = user.LastName;
                userListViewModel.Email = user.Email;
                userListViewModel.CreatedAt = user.CreatedAt;               
                userListViewModels.Add(userListViewModel);
            }
            #endregion

            return View(userListViewModels);
        }
    }
}
