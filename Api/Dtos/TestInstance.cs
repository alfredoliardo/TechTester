using System;

namespace Api.Dtos
{
    public class TestInstance
    {
        public string Name { get; set; }
        public string Bank { get; set; }
        public string OU { get; set; }
        public string Info { get; set; }
        public Guid? Group { get; set; }
    }
}