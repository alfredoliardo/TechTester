using System;

namespace Core.Entities
{
    public enum ResponseValue
    {
        Positive,
        Negative,
        Neutral
    }
    public class TestCheckResponse
    {
        public Guid TestId {get;set;}
        public string WorkstationName {get;set;}
        public int CheckId {get;set;}
        public ResponseValue? Value {get;set;}


        public virtual TestCheck TestCheck {get;set;}
        public virtual TestInstance TestInstance {get;set;}
    }
}