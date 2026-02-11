using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoTutorial.Entities;
using MongoTutorial.Models;
using MongoTutorial.Settings;
using SharpCompress.Compressors.Xz;

namespace MongoTutorial.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMongoCollection<Todo> _todos;

        public HomeController( IOptions<DatabaseSettings> settings, IMongoClient client )
        {
            var mongoSettings = settings.Value;
            var database = client.GetDatabase(mongoSettings.DatabaseName);

            _todos = database.GetCollection<Todo>(mongoSettings.CollectionName);

        }


        public async Task<IActionResult> Index()
        {
            var todolar = await _todos.Find(x => true).ToListAsync();
            return View(todolar);
        }

        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Ekle(CreateTodoViewModel todo)
        {
            var olusturulacak = new Todo();
            olusturulacak.title = todo.title;
            olusturulacak.createdAt = todo.date;
            olusturulacak.isDone = todo.isDone;
            await _todos.InsertOneAsync(olusturulacak);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Tamamlanmadi(string id)
        {
            await _todos.UpdateOneAsync(x => x.TodoId == id, Builders<Todo>.Update.Set(x => x.isDone, false));
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Tamamlandi(string id)
        {
            await _todos.UpdateOneAsync(x => x.TodoId == id, Builders<Todo>.Update.Set(x => x.isDone, true));
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Sil(string id)
        {
            await _todos.DeleteOneAsync(x => x.TodoId == id);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Guncelle(string id)
        {
            var todo = await _todos.Find(x => x.TodoId == id).FirstOrDefaultAsync();

            UpdateTodoViewModel utodo = new UpdateTodoViewModel();
            utodo.TodoId = todo.TodoId;
            utodo.title = todo.title;

            return View(utodo);
        }

        [HttpPost]
        public async Task<IActionResult> Guncelle(UpdateTodoViewModel todo)
        {
            await _todos.UpdateOneAsync(x => x.TodoId == todo.TodoId, Builders<Todo>.Update.Set(x => x.title, todo.title));
            return RedirectToAction("Index");
        }



    }
}
