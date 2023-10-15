namespace DotNETTask.Domains.Models
{
    public record Experience
    {
        public FieldOption<string> Company { get; set; }
        public FieldOption<string> Title { get; set; }
        public FieldOption<string> Location { get; set; }

        public FieldOption<string> StartDate { get; set; }

        public FieldOption<string>? EndDate { get; set; }

        public FieldOption<bool> CurrentlyStudyHere { get; set; }
    }
}
