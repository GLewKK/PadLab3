using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Pad.Domain.Entities;
using Pad.Representation.Abstractions;

namespace Pad.Representation.Implementations
{
    public class UserConfigurationRepository : IUserConfigurationRepository
    {
        private readonly ObjectContext _context = null;

        public UserConfigurationRepository(IOptions<Settings> settings)
        {
            _context = new ObjectContext(settings);
        }
        public async Task<IEnumerable<UserConfiguration>> GetAll()
        {
            return await _context.UserConfigurations.Find(x => true).ToListAsync();
        }

        public UserConfiguration GetByUserId(string id)
        {
             return _context.UserConfigurations.Find(x => x.UserId == Guid.Parse(id)).FirstOrDefault();
        }

        public void Add(UserConfiguration configuration)
        {

             _context.UserConfigurations.InsertOne(configuration);
        }

        public async Task<string> Update(Guid id, UserConfiguration configuration)
        {
            await _context.UserConfigurations.ReplaceOneAsync(x => x.Id == id, configuration);

            return string.Empty;
        }
    }
}
