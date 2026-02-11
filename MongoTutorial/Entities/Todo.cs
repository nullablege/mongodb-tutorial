using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoTutorial.Entities
{
    public class Todo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TodoId { get; set; }
        public string title { get; set; }
        public bool isDone { get; set; } 
        public DateTime createdAt { get; set; }
    }
}
