using System;
using System.Collections.Generic;
using System.Text;
using System.Reactive.Linq;
using ReactiveUI;
using Todo.Services;
using Todo.Models;

namespace Todo.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ViewModelBase _content;
        public MainWindowViewModel(Database db)
        {
           Content =  List = new TodoListViewModel(db.GetItems());
        }
        public ViewModelBase Content
        {
            get => _content;
            private set => this.RaiseAndSetIfChanged(ref _content, value);
        }
        public TodoListViewModel List { get; }
        public void AddItem()
        {
            var vm = new AddItemViewModel();
            Observable.Merge(
                vm.Ok,
                vm.Cancel.Select(_ => (TodoItem)null))
                .Take(1)
                .Subscribe(model => 
                {
                    if(model != null)
                    {
                        List.Items.Add(model);
                    }
                    Content = List;
                });
            Content = vm;
        }
        public void ClearFinishedItems(Database db)
        {
            
            foreach( TodoItem item in db.GetItems())
            {
                if( item.IsChecked == true)
                    {
                        List.Items.Remove(item);
                    }
            }
            Content = List;
        }
    }
}
