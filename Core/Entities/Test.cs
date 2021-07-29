using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Test : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate {get;set;}
        public DateTime ExpirationDate {get;set;}

        public virtual ICollection<TestCheck> TestChecks { get; set; }
        public virtual ICollection<TestInstance> Instances { get; set; }
    }
}