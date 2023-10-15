using DotNETTask.Domains.Enum;

namespace DotNETTask.Domains.Models
{
    public record Question<T>
    {
        public QuestionTypesEnum Type { get; set; }
        public string QuestionText { get; set; }
        public T Answer { get; set; }
    }
}
