using DotNETTask.Domains.Models;

namespace DotNETTask.Domains.Dto
{
    public class ProfileModelDto
    {
        public FieldOptionTwo<IList<Education>> Educations { get; set; }
        public FieldOptionTwo<IList<Experience>> Experience { get; set; }
        public Resume Resume { get; set; }
        public IList<Question<string>> Questions { get; set; }
    }
}
