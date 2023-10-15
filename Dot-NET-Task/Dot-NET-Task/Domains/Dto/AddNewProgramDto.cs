using DotNETTask.Domains.Models;

namespace DotNETTask.Domains.Dto
{
    public class AddNewProgramDto
    {
        public string Title { get; set; }
        public string SummaryHtmlString { get; set; }
        public string DescriptionHtmlString { get; set; }
        public string CriteriaHtmlString { get; set; }
        public IList<Skill> Skills { get; set; }
        public string BenefitsHtmlString { get; set; }
        public ProgramDetails AdditionalInformation { get; set; }
    }
}
