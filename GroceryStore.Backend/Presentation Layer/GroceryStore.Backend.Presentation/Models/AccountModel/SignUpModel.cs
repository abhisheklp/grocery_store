using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Backend.Presentation.Models.AccountModel
{
    public class SignUpModel
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNo { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public bool IsAdmin { get; set; }
    }
}
