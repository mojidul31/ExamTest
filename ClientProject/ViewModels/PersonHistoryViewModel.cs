using System;

namespace ClientProject.ViewModels
{
    public class PersonHistoryViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string OperationType { get; set; }
        public DateTime? CreateDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}
