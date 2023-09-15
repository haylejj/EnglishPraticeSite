using System.ComponentModel.DataAnnotations;

namespace Core.ViewModels
{
    public class RoleCreateViewModel
    {
        [Required(ErrorMessage = "Rol ismi boş bırakılamaz")]
        [Display(Name = "Role ismi :")]
        public string Name { get; set; } = null!;
    }
}
