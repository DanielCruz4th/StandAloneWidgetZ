using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace StandAloneWidget.Models.Security
{
    public class LogInModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [HiddenInput(DisplayValue=false)]
        public string ReturnUrl { get; set; }
    }
}