using Domain.Abstractions;

namespace Domain.Entitiyes
{
    public class Content : IEntity, IHasName
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public User Owner { get; init; }
        public long TypeId { get; init; }
        public DateTime DatetimeUTC { get; init; }

        protected internal Content(string name, User owner, long typeId)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(String.Format("Val cannot be null or whitespace. {0}: {1}", nameof(name), name));

            if (owner == null)
                throw new ArgumentNullException(nameof(owner));

            this.Name = name;
            this.Owner = owner;
            this.TypeId = typeId;
            this.DatetimeUTC = DateTime.UtcNow;
        }

        [Obsolete("for an common type", true)]//для получения сущности из хранилища
        public Content() { } 

    }
}
