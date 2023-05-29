using Domain.Abstractions;

namespace Domain.ValueObjects
{
    public class ContentType: IValueObject
    {
        [Obsolete("For reflection", true)]
        public ContentType() { }

        protected internal ContentType(DateTime dateTimeUtc, string name)
        {
            if (name.Length <= 0)
                throw new ArgumentOutOfRangeException(nameof(name));
            DateTimeUtc = dateTimeUtc;
            if (Id <= 0)
                throw new ArgumentNullException(nameof(Id));
        }
        public ContentType(long id, DateTime dateTimeUtc, string name)
            : this(dateTimeUtc, name)
        {
            Id = id;
        }
        public long Id { get; }
        public DateTime DateTimeUtc { get; init; }
        public string Name { get; init; }
    }
}
