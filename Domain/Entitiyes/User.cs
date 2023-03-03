using Domain.Abstractions;
using System.Xml.Linq;

namespace Domain.Entitiyes
{
    public class User : IEntity
    {
        public long Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Login { get; set; }
        public string Password
        {
            get => Password;
            set
            {
                if (value.Length > 24)
                    throw new ArgumentOutOfRangeException(nameof(value));
            }
        }
        public long City { get; set; }

        [Obsolete("for an common type", true)]
        public User(){ }

        protected internal User(string Login,string Password, long CityId)
        {
            Login = Login;
            Password = Password;
            City = CityId;
        }
    }

   
}
