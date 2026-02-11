namespace MongoTutorial.Models
{
    public class CreateTodoViewModel
    {
        public string title { get; set; }
        public bool isDone = false;
        public DateTime date => DateTime.Now;
    }
}
