using System;
namespace PW.Application.Models.ViewModels.Membership
{
	public class UserUpdateViewModel
	{
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool UpdatePassword { get; set; }
    }
}

