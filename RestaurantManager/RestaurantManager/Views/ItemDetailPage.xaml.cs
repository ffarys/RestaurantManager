using RestaurantManager.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace RestaurantManager.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}