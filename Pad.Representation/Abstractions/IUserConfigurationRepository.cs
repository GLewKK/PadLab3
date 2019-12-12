using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pad.Domain.Entities;

namespace Pad.Representation.Abstractions
{
    public interface IUserConfigurationRepository
    {
        Task<IEnumerable<UserConfiguration>> GetAll();
        UserConfiguration GetByUserId(string id);
        void Add(UserConfiguration configuration);
        Task<string> Update(Guid id, UserConfiguration configuration);
    }
}
