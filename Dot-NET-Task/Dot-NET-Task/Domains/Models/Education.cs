namespace DotNETTask.Domains.Models
{
    public record Education
    {
        public FieldOption<string> SchoolName { get; set; }
        public FieldOption<string> Degree { get; set; }
        public FieldOption<string> CourseName { get; set; }
        public FieldOption<string> LocationOfStudy { get; set; }

        public FieldOption<DateTime> StartDate { get; set; }

        public FieldOption<DateTime> EndDate { get; set; }

    }
}
