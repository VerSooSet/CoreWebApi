using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitiyes
{
    public class User : IEntity
    {
        public long Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Login { get; set; }
        public long City { get; set; }
    }
}
