using System.ComponentModel.DataAnnotations;

namespace Core.ViewModels
{
    public class RegisterViewModel
    {
        public RegisterViewModel()
        {

        }
        public RegisterViewModel(string? userName, string? email, string? password, string? passwordConfirm, string? phone)
        {
            UserName=userName;
            Email=email;
            Password=password;
            PasswordConfirm=passwordConfirm;
            Phone=phone;
        }

        [Required(ErrorMessage = "Kullanıcı Ad alanı boş bırakılamaz")]
        [Display(Name = "Kullanıcı Adı :")]
        public string? UserName { get; set; }
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir email giriniz.")]
        [Required(ErrorMessage = "Email  alanı boş bırakılamaz")]
        [Display(Name = "Email :")]
        public string? Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz")]
        [Display(Name = "Şifre :")]
        public string? Password { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Şifre aynı değildir.")]
        [Required(ErrorMessage = "Şifre tekrar alanı boş bırakılamaz.")]
        [Display(Name = "Şifre Tekrar :")]
        public string? PasswordConfirm { get; set; }
        [Required(ErrorMessage = "Telefon alanı boş bırakılamaz")]
        [Display(Name = "Telefon :")]
        public string? Phone { get; set; }
    }
}
