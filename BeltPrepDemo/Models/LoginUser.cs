using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeltPrepDemo.Models
{
    public class LoginUser
    {
        [Required(ErrorMessage="Must input an email address")]
        [EmailAddress(ErrorMessage="Invalid email address")]
        public string LoginEmail { get; set; }
        
        [Required(ErrorMessage="Must input a password")]
        public string LoginPassword { get; set; }

    }
}