using System.Collections.Generic;

namespace Core.Entities
{
    public class Workstation
    {
        public string Name { get; set; }
        public string Bank { get; set; }
        public string OU { get; set; }

        public virtual Branch Branch {get;set;}
        public virtual ICollection<TestInstance> TestInstances { get; set; }
    }
}