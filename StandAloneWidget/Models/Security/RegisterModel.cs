using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StandAloneWidget.Models.Security
{
    public class RegisterModel
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [Index(IsUnique=true)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}