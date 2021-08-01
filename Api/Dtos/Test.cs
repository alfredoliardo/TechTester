using System;
using System.Collections.Generic;

namespace Api.Dtos
{
    public class Test
    {
        public IEnumerable<Check> Checks { get; internal set; }
        public DateTime ExpirationDate { get; internal set; }
        public DateTime StartDate { get; internal set; }
        public string Description { get; internal set; }
        public string Name { get; internal set; }
        public Guid Id { get; internal set; }
        public object Instances { get; internal set; }
    }
}