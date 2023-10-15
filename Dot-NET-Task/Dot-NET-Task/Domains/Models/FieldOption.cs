namespace DotNETTask.Domains.Models
{
    public record FieldOption<T>
    {
        public string Name { get; set; }
        public bool Hide { get; set; }
        public bool Internal { get; set; }
        public T Value { get; set; }

    }

    public record FieldOptionTwo<T>
    {
        public string Name { get; set; }
        public bool Hide { get; set; }
        public bool Mandatory { get; set; }
        public T Value { get; set; }
    }
}
