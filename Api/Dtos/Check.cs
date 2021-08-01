namespace Api.Dtos
{
    public class Check
    {
        public string Name { get; set; }
        public string Help { get; set; }
        public bool WithThirdOption { get; set; }
        public int DisplayOrder { get; set; }
        public int Id { get; internal set; }
        public bool HasNeutralOption { get; internal set; }
    }
}