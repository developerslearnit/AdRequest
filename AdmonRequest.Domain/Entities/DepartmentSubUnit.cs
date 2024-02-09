using System;

namespace AdmonRequest.Domain.Entities
{
    public partial class DepartmentSubUnit
    {
        public Guid DepartmentSubUnitId { get; set; }
        public string SubUnitName { get; set; }
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
