using System.ComponentModel.DataAnnotations;

namespace Cakeryz.Models
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
