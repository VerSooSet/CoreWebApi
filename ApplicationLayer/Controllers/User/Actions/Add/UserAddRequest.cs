using Api.Requests.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace ApplicationLayer.Controllers.User.Actions.Add
{
    public class UserAddRequest : IRequest<UserAddResponse>
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public long CityId { get; set; }
    }
}
