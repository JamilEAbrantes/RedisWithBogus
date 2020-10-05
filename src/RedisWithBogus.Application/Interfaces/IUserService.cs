using RedisWithBogus.Domain.Entities;
using System.Collections.Generic;

namespace RedisWithBogus.Application.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
    }
}
