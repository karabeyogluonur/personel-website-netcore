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

        public async Task<IActionResult> Update(int id)
        {
            User user = await _userService.GetByIdAsync(id);
            UserUpdateViewModel userUpdateViewModel = _mapper.Map<UserUpdateViewModel>(user);
            return View(userUpdateViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateViewModel userUpdateViewModel)
        {
            //FluentValidation will be added.
            if (!ModelState.IsValid)
                return View(userUpdateViewModel);

            User user = await _userService.GetByIdAsync(userUpdateViewModel.Id);
            user = _mapper.Map(userUpdateViewModel,user);

            if (userUpdateViewModel.UpdatePassword)
                user.PasswordHash = PasswordHashHelper.HashPassword(userUpdateViewModel.Password);

            _userService.Update(user);

            return RedirectToAction("List", "User");
        }

        public async Task<IActionResult> Delete(int id)
        {
            User user = await _userService.GetByIdAsync(id);
            _userService.Delete(user);

            return RedirectToAction("List", "User");
        }
    }
}
