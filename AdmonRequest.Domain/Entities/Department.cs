using System;

namespace AdmonRequest.Domain.Entities
{
    public partial class Department 
    {
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public bool ActiveStatus { get; set; }
    }
}
