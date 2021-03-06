using System;
using System.ComponentModel.DataAnnotations;

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
