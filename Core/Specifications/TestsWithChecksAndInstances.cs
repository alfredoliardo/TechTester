using Core.Entities;

namespace Core.Specifications
{
    public class TestsWithChecksAndInstances : BaseSpecification<Test>
    {
        public TestsWithChecksAndInstances()
        {
            IncludeStrings.Add("TestChecks.Check");
            AddInclude(test => test.Instances);
        }
    }
}