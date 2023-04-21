using Domain.Abstractions;
using Queries.Abstractions;


namespace Domain.Criteria
{
    public class FindById : ICriterion
    {
        public FindById(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
