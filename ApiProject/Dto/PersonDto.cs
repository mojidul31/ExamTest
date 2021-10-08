using System;

namespace ApiProject.Dto
{
    public class PersonDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public DateTime? CreateDateTime { get; set; }
    }
}
