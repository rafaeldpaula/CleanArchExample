using CleanArchExample.Domain.Entities;
using CleanArchExample.Domain.Enums;

namespace CleanArchExample.Domain.Specifications;

public class ActiveUserSpecification : ISpecification<User>
{
    public bool IsSatisfiedBy(User user)
    {
        return user.Status == UserStatus.Active;
    }
}
