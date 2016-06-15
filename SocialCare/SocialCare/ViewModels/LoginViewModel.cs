using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialCare.ViewModels
{
    [MetadataType(typeof(LoginViewModelMetadata))]
    public class LoginViewModel
    {
        public string login { get; set; }
        public string senha { get; set; }
    }

    public class LoginViewModelMetadata
    {
        [Display(Name = "Login")]
        [Required(ErrorMessage = "Informe o login")]
        public string login { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Informe a senha")]
        public string senha { get; set; }
    }
}