using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
