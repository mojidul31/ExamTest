﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClientProject.ViewModels
{
    public class PersonViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Phone No")]
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public DateTime? CreateDateTime { get; set; }
    }
}
