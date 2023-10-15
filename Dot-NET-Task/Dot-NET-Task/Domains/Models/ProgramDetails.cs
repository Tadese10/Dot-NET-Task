using DotNETTask.Domains.Enum;

namespace DotNETTask.Domains.Models
{
    public record ProgramDetails
    {
        public TypeEnum Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public DurationEnum Duration { get; set; }
        public bool FullyRemote { get; set; }
        public int MaximumApplication { get; set; }
        public string Location { get; set; }

    }
}
