﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(4, ErrorMessage="Минимальная длинна - 4 символа")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(6,ErrorMessage="Минимальная длинна - 6 символа")]
        
        public string Password { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
        public int RoleId { get; set; }


    }
}
