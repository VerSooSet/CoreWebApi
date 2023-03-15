using Domain.Abstractions;
using System.Xml.Linq;

namespace Domain.Entitiyes
{
    public class User : IEntity
    {
        protected const int maxPasswordLength = 12;
        public long Id { get; set; }
        public string Login { get; set; }

        public string Password
        {
            get => Password;
            set
            {
                if (value.Length > maxPasswordLength)
                    throw new ArgumentOutOfRangeException(nameof(value));
            }
        }
        public long City { get; set; }

        [Obsolete("for an common type", true)]
        public User(){ }

        protected internal User(string Login,string Password, long CityId)
        {
            if (string.IsNullOrWhiteSpace(Login) && string.IsNullOrWhiteSpace(Password))
                throw new ArgumentException(String.Format("Val cannot be null or whitespace. {0}: {1} , {2}: {3}", nameof(Login), Login, nameof(Password), Password ));
            
            this.Login = Login;
            this.Password = Password;
            City = CityId;
        }
    }

   
}
