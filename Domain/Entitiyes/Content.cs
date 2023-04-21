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

        protected internal Content(string Name, User Owner, long TypeId)
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentException(String.Format("Val cannot be null or whitespace. {0}: {1}", nameof(Name), Name));

            if (Owner == null)
                throw new ArgumentNullException(nameof(Owner));

            this.Name = Name;
            this.Owner = Owner;
            this.TypeId = TypeId;
            this.DatetimeUTC = DateTime.UtcNow;
        }

        [Obsolete("for an common type", true)]//для получения сущности из хранилища
        public Content() { } 

    }
}
