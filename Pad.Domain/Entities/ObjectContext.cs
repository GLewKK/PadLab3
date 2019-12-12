using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Pad.Domain.Entities
{
    public class ObjectContext
    {
        public IConfiguration Configuration { get; }
        private IMongoDatabase _database = null;

        public ObjectContext(IOptions<Settings> settings)
        {
            Configuration = settings.Value.ConfigurationRoot;
            settings.Value.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
            settings.Value.Database = Configuration.GetSection("MongoConnection:Database").Value;

            var client = new MongoClient(settings.Value.ConnectionString);

            if (client != null)
            {
                _database = client.GetDatabase(settings.Value.Database);
            }
        }

        public IMongoCollection<UserConfiguration> UserConfigurations => _database.GetCollection<UserConfiguration>(nameof(UserConfiguration));
    }

    public class Settings
    {
        public string ConnectionString;
        public string Database;
        public IConfiguration ConfigurationRoot;
    }

    
}
