using System;

namespace ApiProject.Models
{
    public class PersonHistory
    {
        public int Id { get; set; }
        public int RefId { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string OperationType { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
    }
}
