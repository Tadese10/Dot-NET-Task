using System.ComponentModel.DataAnnotations;
using DotNETTask.Domains.Enum;
using DotNETTask.Infrastructure.Helper;

namespace DotNETTask.Domains.Dto
{
    public record ProgramDetailsDto
    {
        [Required]
        public TypeEnum Type { get; set; }
        
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]// Validate the date format "YYYY-MM-DD"
        public DateTime StartDate { get; set; }
        
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime OpenDate { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DateGreaterThan("StartDate", ErrorMessage = "CloseDate should be greater than or equal to StartDate.")]
        public DateTime CloseDate { get; set; }
        
        [Required]
        public DurationEnum Duration { get; set; }
        [Required]
        public bool FullyRemote { get; set; }

        [Required]
        public int MaximumApplication { get; set; }

        [Required]
        public string Location { get; set; }


    }
}
