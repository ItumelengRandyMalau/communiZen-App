
using Microsoft.Maui.Controls;

namespace Zenfull
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new Zenfull.ViewModel.MainPageViewModel();
        }
    }
}




