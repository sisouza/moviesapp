using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace webapp.Models
{
    public class Movie
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }

    }
}