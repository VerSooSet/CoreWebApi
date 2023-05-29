using Domain.Abstractions;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Entitiyes
{
    public class User : IEntity, IHasName
    {
        protected const int maxPasswordLength = 12;
        public long Id { get; set; }
        public string Login {
            get;

            [MemberNotNull(nameof(Login))]
            set;
        }

        public string Password
        {
            get => Password;

            [MemberNotNull(nameof(Password))]
            set
            {
                if (value == null) { 
                    Password = String.Empty;
                    return;
                }
                if (value.Length > maxPasswordLength)
                    throw new ArgumentOutOfRangeException(nameof(value));
            }
        }

        public string Name 
        { 
            get => Login;
        }

        public long City { get; set; }

        [Obsolete("for an common type", true)]
        public User(){ }

        protected internal User(string Login,string Password, long CityId)
        {
            if (string.IsNullOrWhiteSpace(Login) && string.IsNullOrWhiteSpace(Password))
                throw new ArgumentException(String.Format("{0} cannot be null or whitespace on Id: {1}", nameof(Login), Id));
            
            this.Login = Login;
            this.Password = Password;
            City = CityId;
        }
    }

   
}
