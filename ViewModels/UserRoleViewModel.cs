using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Garderie.ViewModels
{
    public class UserRoleViewModel
    {
        [Required]
        public int UserId { get; set; }

        public string UserName { get; set; }

        public IEnumerable<string> Roles { get; set; }
    }
}
