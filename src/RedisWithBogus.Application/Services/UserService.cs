using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using RedisWithBogus.Application.Interfaces;
using RedisWithBogus.Domain.Entities;
using RedisWithBogus.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace RedisWithBogus.Application.Services
{
    public class UserService : IUserService
    {
        private const string _key_all_users = "all_users";
        private readonly IDistributedCache _cache;
        private readonly IUserRepository _repository;

        public UserService(
            IDistributedCache cache,
            IUserRepository repository)
        {
            _cache = cache;
            _repository = repository;
        }

        public IEnumerable<User> GetUsers()
        {
            var cacheString = _cache.GetString(_key_all_users);

            if (string.IsNullOrWhiteSpace(cacheString))
            {
                var cacheEntryOptions = 
                    new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(1));

                var users = _repository.GetUsers();

                _cache.SetString(_key_all_users, JsonConvert.SerializeObject(users), cacheEntryOptions);

                return users;
            }

            return JsonConvert.DeserializeObject<IEnumerable<User>>(cacheString);
        }
    }
}