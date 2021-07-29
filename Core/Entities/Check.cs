using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Check : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Help { get; set; }
        public bool HasNotRelevantOption {get;set;}

        public virtual IEnumerable<TestCheck> TestChecks {get;set;}
    }
}