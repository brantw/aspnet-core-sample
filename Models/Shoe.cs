using MongoDB.Bson;

namespace ShoeStore.Models
{
    public class Shoe
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public string Brand { get; set; }

        public Gender Gender { get; set; }

        public decimal Size { get; set; }

        public decimal Price { get; set; }
    }
}