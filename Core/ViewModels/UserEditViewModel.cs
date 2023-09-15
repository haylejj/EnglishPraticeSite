using Core.Entity;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Core.ViewModels
{
    public class UserEditViewModel
    {
        [Required(ErrorMessage = "Kullanıcı Ad alanı boş bırakılamaz")]
        [Display(Name = "Kullanıcı Adı :")]
        public string? UserName { get; set; }


        [EmailAddress(ErrorMessage = "Lütfen geçerli bir email giriniz.")]
        [Required(ErrorMessage = "Email  alanı boş bırakılamaz")]
        [Display(Name = "Email :")]
        public string? Email { get; set; }



        [Required(ErrorMessage = "Telefon alanı boş bırakılamaz")]
        [Display(Name = "Telefon :")]
        public string? Phone { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Doğum Tarihi :")]
        public DateTime? BirthDate { get; set; }



        [Display(Name = "Şehir :")]
        public string? City { get; set; }


        [Display(Name = "Profil Resmi :")]
        public IFormFile? Picture { get; set; }

        [Required(ErrorMessage = "Cinsiyet alanı boş bırakılamaz")]
        [Display(Name = "Cinsiyet:")]
        public Gender? Gender { get; set; }
    }
}
