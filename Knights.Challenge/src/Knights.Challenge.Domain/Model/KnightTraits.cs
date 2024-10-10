using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Knights.Challenge.Domain.Model
{
    public class KnightTraits
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }        
        public int Age { get; set; }
        public int Weapons { get; set; }
        public string Attribute { get; set; }
        public double Attack { get; set; }
        public double Experience { get; set; }
        public bool IsHero { get; set; }
    }
}
