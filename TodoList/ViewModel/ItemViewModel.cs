using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;

namespace TodoList.ViewModel
{
    internal class ItemViewModel : INotifyPropertyChanged
    {
        string name = "";

        public event PropertyChangedEventHandler? PropertyChanged;
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand TaskDoneCommand { get; set; }
        public ObservableCollection<ItemToDo> Items { get; set; } = new();

        public class ItemToDo
        {
            public string NameDo { get; set; } = "";
            public ItemToDo(string name)
            {
                NameDo = name;
            }
        }



        public ItemViewModel()
        {
            AddCommand = new Command(() =>
            {
                if(NameDo != "")
                Items.Add(new ItemToDo(NameDo));
                NameDo = "";
            });

            DeleteCommand = new Command((object? args) =>
            {
                if (args is ItemToDo itemdo)
                Items.Remove(itemdo);
            });

            TaskDoneCommand = new Command(() =>
            {

            });
        }

        

        public string NameDo
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged();
                }
            }
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
