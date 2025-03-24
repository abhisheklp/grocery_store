using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryStore.Backend.Business.DTO.AccountDTO
{
    public class SignUpDTO
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNo { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public bool IsAdmin { get; set; }
    }
}
