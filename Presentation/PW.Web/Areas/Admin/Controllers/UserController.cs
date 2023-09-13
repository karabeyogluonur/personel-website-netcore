using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PW.Application.Interfaces.Services.Membership;
using PW.Application.Models.ViewModels.Membership;
using PW.Application.Utilities.Helpers;
using PW.Domain.Entities.Membership;

namespace PW.Web.Areas.Admin.Controllers
{
    public class UserController : BaseAdminController
    {
        IUserService _userService;
        IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return RedirectToAction("List", "User");
        }

        public async Task<IActionResult> List()
        {
            List<User> users = await _userService.GetAllAsync();

            List<UserListViewModel> userListViewModels = _mapper.Map<List<UserListViewModel>>(users);

            return View(userListViewModels);

        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserCreateViewModel userCreateViewModel)
        {
            //FluentValidation will be added.
            if (!ModelState.IsValid)
                return View(userCreateViewModel);

            User user = _mapper.Map<User>(userCreateViewModel);
            user.PasswordHash = PasswordHashHelper.HashPassword(userCreateViewModel.Password);

            await _userService.InsertAsync(user);

            return RedirectToAction("List","User");
        }
    }
}
