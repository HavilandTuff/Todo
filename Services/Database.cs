using System.Collections.Generic;
using Todo.Models;
namespace Todo.Services
{
    public class Database
    {
        public IEnumerable<TodoItem> GetItems() => new[]
        {
            new TodoItem { ItemDescription = "Walk the dog."},
            new TodoItem { ItemDescription = "Buy some milk."},
            new TodoItem { ItemDescription = "Learn some Avalonia", IsChecked = true},
        };
    }
}