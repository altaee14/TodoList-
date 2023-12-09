using System.Collections.ObjectModel;
using System.Collections.Specialized;
using TodoList.ViewModel;

namespace TodoList;

public partial class MainPage : ContentPage
{
    
    
	public MainPage()
    {
        InitializeComponent();
        BindingContext = new ItemViewModel();
    }
}