using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW.Application.Models.ViewModels.Membership
{
    public class UserListViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName {
            get
            {
                return String.Concat(FirstName, " ", LastName);
            }
        }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
