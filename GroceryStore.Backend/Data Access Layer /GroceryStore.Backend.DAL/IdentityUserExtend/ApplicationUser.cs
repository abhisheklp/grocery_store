using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace GroceryStore.Backend.DAL.IdentityUserExtend
{
	public class ApplicationUser : IdentityUser
	{
		[Required]
		public string FullName { get; set; }

        [Required]
        public bool IsAdmin { get; set; }
    }
}

