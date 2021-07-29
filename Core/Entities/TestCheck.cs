using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class TestCheck
    {
        public Guid TestId {get;set;}
        public int CheckId {get;set;}
        public int DisplayOrder {get;set;}

        public virtual Test Test {get;set;}
        public virtual Check Check {get;set;}
        public virtual IEnumerable<TestCheckResponse> Responses {get;set;}
    }
}