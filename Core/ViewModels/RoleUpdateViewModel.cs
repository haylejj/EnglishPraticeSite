using System.ComponentModel.DataAnnotations;

namespace Core.ViewModels
{
    public class RoleUpdateViewModel
    {
        public string Id { get; set; } = null!;

        [Required(ErrorMessage = "Rol isim boş bırakılamaz")]
        [Display(Name = "Role ismi :")]
        public string Name { get; set; } = null!;
    }
}
