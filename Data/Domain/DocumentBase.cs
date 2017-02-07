using MongoDB.Bson.Serialization.Attributes;

namespace Data.Domain
{
    public class DocumentBase
    {
        [BsonId]
        public string _id;
    }
}
