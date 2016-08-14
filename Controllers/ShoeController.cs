using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ShoeStore.Infrastructure;
using ShoeStore.Models;

namespace ShoeStore.Controllers
{
    public class ShoeController : Controller
    {
        private readonly IMongoCollection<Shoe> _shoesCollection;

        public ShoeController(IMongoDbProvider mongo)
        {
            _shoesCollection = mongo.Database.GetCollection<Shoe>(mongo.ShoeCollectionName);
        }

        public async Task<IActionResult> Index()
        {
            var filter = Builders<Shoe>.Filter.Empty;
            var shoes = await _shoesCollection
                .Find(filter)
                .ToListAsync();
            
            return View(shoes);
        }
    }
}