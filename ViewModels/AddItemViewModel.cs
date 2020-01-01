using System.Reactive;
using ReactiveUI;
using Todo.Models;
namespace Todo.ViewModels
{
    public class AddItemViewModel:ViewModelBase
    {
        string _descryption;
        public string Descryption
        {
            get => _descryption;
            set => this.RaiseAndSetIfChanged(ref _descryption, value);
        }
        public AddItemViewModel()
        {
            var okEnabled = this.WhenAnyValue(
                x => x.Descryption,
                x => !string.IsNullOrWhiteSpace(x)
            );
            Ok = ReactiveCommand.Create(
                () => new TodoItem { ItemDescription = Descryption }, 
                okEnabled
            ); 
            Cancel = ReactiveCommand.Create(() => {});
       }
       public ReactiveCommand<Unit, TodoItem> Ok {get;}
       public ReactiveCommand<Unit, Unit> Cancel {get;}
    }
}

