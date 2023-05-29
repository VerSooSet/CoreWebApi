using Domain.Entitiyes;

namespace ApplicationLayer.Controllers.Content
{
    public class ContentDto
    {
        public string Name { get; init; }
        public string OwnerName { get; init; }
        public string TypeName { get; init; }
        public DateTime DatetimeUTC { get; init; }
    }
}
