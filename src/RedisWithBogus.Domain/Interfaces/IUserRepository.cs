using RedisWithBogus.Domain.Entities;
using System.Collections.Generic;

namespace RedisWithBogus.Domain.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
    }
}
