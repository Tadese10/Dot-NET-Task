namespace DotNETTask.Domains.Models
{
    public record WorkFlow
    {
        public IList<Stage> Stages { get; set; }
    }
}
