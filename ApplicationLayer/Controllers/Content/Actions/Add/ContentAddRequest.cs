using Api.Requests.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace ApplicationLayer.Controllers.Content.Actions.Add
{
    public class ContentAddRequest: IRequest<ContentAddResponse>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public long OwnerId { get; set; }
        [Required]
        public long TypeId { get; set; }
    }
}
