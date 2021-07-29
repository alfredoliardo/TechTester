using System.Collections.Generic;

namespace Core.Entities
{
    public class Branch
    {
        public string Bank { get; set; }
        public string OU { get; set; }
        public string Info { get; set; }

        public virtual ICollection<Workstation> Workstations { get; set; }
    }
}