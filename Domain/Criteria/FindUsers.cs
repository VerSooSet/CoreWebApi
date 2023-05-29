using Queries.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Criteria
{
    public record FindUsers(string Search) : ICriterion;
}
