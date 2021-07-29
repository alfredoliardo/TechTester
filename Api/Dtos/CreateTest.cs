using System.Collections.Generic;

namespace Api.Dtos
{
    public class CreateTest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Check> Checks { get; set; }
        public List<TestInstance> Workstations { get; set; }
    }
}