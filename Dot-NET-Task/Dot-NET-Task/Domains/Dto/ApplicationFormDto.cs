using System.ComponentModel.DataAnnotations;
using DotNETTask.Domains.Models;

namespace DotNETTask.Domains.Dto
{
    public class ApplicationFormDto
    {
        [Required]
        public IFormFile ImageFile { get; set; }

        [Required]
        public PersonalInformationDto PersonalInformation { get; set; }
        [Required]
        public ProfileModelDto Profile { get; set; }
        [Required]
        public IList<Question<string>> AdditionalQuestions { get; set; }
    }
}
