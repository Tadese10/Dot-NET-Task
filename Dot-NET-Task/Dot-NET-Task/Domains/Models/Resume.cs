namespace DotNETTask.Domains.Models
{
    public record Resume
    {
        public string Path { get; set; }
        public bool Hide { get; set; }
        public bool Mandatory { get; set; }
    }
}
