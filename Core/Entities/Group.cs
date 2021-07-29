using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Group : BaseEntity<int>
    {
        public string Name {get;set;}
        public string Description {get;set;}
        public virtual IEnumerable<TestInstance> TestInstances {get;set;}
    }
}