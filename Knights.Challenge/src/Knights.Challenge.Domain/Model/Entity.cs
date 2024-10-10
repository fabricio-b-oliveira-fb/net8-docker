using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Knights.Challenge.Domain.Model
{
    public abstract class Entity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; private set; }
        public bool IsValid { get; private set; } = true;

        protected Entity() {}

        public void SetEntityState(bool state)
        {
            IsValid = state;
        }
    }
}
