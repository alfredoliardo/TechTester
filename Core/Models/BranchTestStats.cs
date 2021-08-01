using System;

namespace Core.Models
{
    public enum BranchTestStatsStatus{
        NotStarted,
        Running, 
        Completed
    }
    public class BranchTestStats
    {
        public string GroupName {get;set;}
        public string Bank {get;set;}
        public string OU {get;set;}
        public string Info {get;set;}
        public DateTime? LastUpdateTime {get;set;}
        public int Workstations {get;set;}
        public int NotStarted {get;set;}
        public int Running {get;set;}
        public int Completed {get;set;}
        public int Damaged {get;set;}
        public int WithNegativeResponses { get; set; }
        public BranchTestStatsStatus Status { get; set; } = BranchTestStatsStatus.NotStarted;
    }
}