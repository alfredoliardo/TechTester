using System;
using System.Linq;
using System.Linq.Expressions;
using Core.Entities;
using Core.Models;

namespace Core.Specifications
{
    public class BranchesStatsSpecification : BaseSpecification<TestInstance>
    {
        public BranchesStatsSpecification(Guid testId) : base(test => test.TestId == testId)
        {
            AddInclude(test => test.Responses);
            ApplyGroupBy(entity => new {entity.GroupId, entity.Workstation.Branch.Bank, entity.Workstation.Branch.OU});
        }
    }
}