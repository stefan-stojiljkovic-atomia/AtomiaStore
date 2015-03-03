﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Atomia.Store.AspNetMvc.Models
{
    public class TermsOfServiceModel
    {
        [Required]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Terms { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage="You must confirm the Terms of Service.")]
        public bool Confirm { get; set; }
    }
}