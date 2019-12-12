using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Pad.Domain.Enums;

namespace Pad.Domain.Entities
{
    public class UserConfiguration
    {
        [BsonId]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public BackgroundColor BackgroundColor { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string ImageSrc { get; set; }
    }
}
