using System;

namespace ApiProject.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
