
using System.Collections.Generic;
using System.Text.Json;
using DotNETTask.Domains.Models;

namespace DotNETTask.Domains.Models
{
    public record ProgramEntity : BaseEntity
    {
        public string Title { get; set; }
        public string SummaryHtmlString { get; set; }
        public string DescriptionHtmlString { get; set; }
        public string CriteriaHtmlString { get; set; }
        public IList<Skill> Skills { get; set; }
        public string BenefitsHtmlString { get; set; }
        public ProgramDetails? AdditionalInformation { get; set; }
        public ApplicationForm? ApplicationForm { get; set; }
        public WorkFlow? WorkFLow { get; set; }
        public bool Deprecated { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }

}
