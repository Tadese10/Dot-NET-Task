using DotNETTask.Domains.Enum;
using DotNETTask.Domains.Models;

namespace DotNETTask.Domains.Dto
{
    public class PersonalInformationDto
    {
        public FieldOption<string> FirstName { get; set; }
        public FieldOption<string> LastName { get; set; }
        public FieldOption<string> Email { get; set; }
        public FieldOption<string> PhoneNumber { get; set; }
        public FieldOption<string> Nationality { get; set; }
        public FieldOption<string> CurrentResidence { get; set; }
        public FieldOption<string> IdNumber { get; set; }
        public FieldOption<GenderEnum> Gender { get; set; }
        public IList<Question<string>> Questions { get; set; }
    }
}
