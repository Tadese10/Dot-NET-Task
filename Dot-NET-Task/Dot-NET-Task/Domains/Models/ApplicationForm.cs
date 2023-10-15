using Org.BouncyCastle.Asn1.X509.SigI;

namespace DotNETTask.Domains.Models
{
    public record ApplicationForm
    {
        public string CoverImagePath { get; set; }
        public PersonalInformation PersonalInformation { get; set; }
        public ProfileModel Profile { get; set; }
        public IList<Question<string>> AdditionalQuestions { get; set; }

    }
}
