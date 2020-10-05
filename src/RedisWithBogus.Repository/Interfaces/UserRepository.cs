using Bogus;
using RedisWithBogus.Domain.Entities;
using RedisWithBogus.Domain.Interfaces;
using System.Collections.Generic;

namespace RedisWithBogus.Repository.Interfaces
{
    public class UserRepository : IUserRepository
    {
        public IEnumerable<User> GetUsers()
        {
            var users = new Faker<User>()
                .RuleFor(c => c.Id, f => f.Random.Guid())
                .RuleFor(c => c.Name, f => f.Name.FullName())
                .RuleFor(c => c.Birthday, f => f.Date.Past(15))
                .Generate(3);

            return users;
        }
    }
}
