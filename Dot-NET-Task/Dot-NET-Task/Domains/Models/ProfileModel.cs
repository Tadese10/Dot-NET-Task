namespace DotNETTask.Domains.Models
{
    public record ProfileModel
    {
        public FieldOptionTwo<IList<Education>> Educations { get; set; }
        public FieldOptionTwo<IList<Experience>> Experience { get; set; }
        public Resume Resume { get; set; }
        public IList<Question<string>> Questions { get; set; }

    }
}
