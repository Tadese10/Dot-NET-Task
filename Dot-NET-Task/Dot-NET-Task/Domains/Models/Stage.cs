namespace DotNETTask.Domains.Models
{
    public record Stage
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public VideoInterview? VideoInterview { get; set; }
        public bool Placement { get; set; }
        public bool ShowToCandidate { get; set; }
    }
}
