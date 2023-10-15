using System.ComponentModel.DataAnnotations;
using DotNETTask.Domains.Models;

namespace DotNETTask.Domains.Dto
{
    public class WorkFlowDto
    {
        [Required]
        [MinLength(1, ErrorMessage = "Invalid request. Please add at least one stage to the list.")]
        public IList<Stage> Stages { get; set; }
    }
}
