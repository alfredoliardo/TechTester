using System;

namespace Api.Dtos
{
    public class TestInstance
    {
        public string Name { get; set; }
        public string TestName {get;set;}
        public DateTime TestStartDate {get;set;}
        public DateTime TestExpirationDate {get;set;}
        public DateTime? StartTime {get;set;}
        public DateTime? LastUpdateTime {get;set;}
        public DateTime? Completed{get;set;}
        public bool Damaged { get; internal set; }
        public object Checks { get; internal set; }
        public Guid TestId { get; internal set; }
        public string WorkstationName { get; internal set; }
    }
}