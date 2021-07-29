using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class TestInstance
    {
        public Guid TestId { get; set; }
        public string WorkstationName { get; set; }
        public int? GroupId { get; set; }
        public bool Damaged {get;set;} = false;
        public DateTime? LastUpdateTime {get;set;}
        public DateTime? Completed {get;set;}

        public virtual Test Test { get; set; }
        public virtual Group Group {get;set;}
        public virtual IEnumerable<TestCheckResponse> Responses {get;set;}
        public virtual IEnumerable<TestInstanceNote> Notes {get;set;}
        public virtual Workstation Workstation { get; set; }
    }
}