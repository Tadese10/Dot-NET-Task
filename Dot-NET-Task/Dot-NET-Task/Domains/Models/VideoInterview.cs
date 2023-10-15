namespace DotNETTask.Domains.Models
{
    public record VideoInterview
    {
        public string Question { get; set; }
        public string AdditionalInformation { get; set; }
        public int VideoSubmissionDeadlinInDays { get; set; }
        public int MaxVideoDurationInSecOrMin { get; set; }
    }
}
