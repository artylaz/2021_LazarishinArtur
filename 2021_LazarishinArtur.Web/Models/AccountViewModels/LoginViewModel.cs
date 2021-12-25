using System.ComponentModel.DataAnnotations;

namespace _2021_LazarishinArtur.Web.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Введите Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Введите пароль")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

    }
}
