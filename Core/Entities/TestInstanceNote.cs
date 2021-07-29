using System;

namespace Core.Entities
{
    public class TestInstanceNote
    {
        public Guid TestId {get;set;}
        public string WorkstationName {get;set;}
        public string Text {get;set;}
        public DateTime CreationTime {get;set;}

        public virtual TestInstance TestInstance {get;set;}
    }
}