using Queries.Abstractions;

namespace Domain.Criteria
{
    public record FindContentItems(string Search): ICriterion;
    
}
