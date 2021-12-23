using RestaurantManager.Models;
using RestaurantManager.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RestaurantManager.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {

        public ObservableCollection<Models.MenuItem> MenuItems { get; }
        public Command LoadMenusCommand { get; }
        public Command AddMenuCommand { get; }
        public Command<Item> MenuTapped { get; }

        public MenuViewModel()
        {
            Title = "Browse";
            MenuItems = new ObservableCollection<Models.MenuItem>();
            LoadMenusCommand = new Command(async () => await ExecuteLoadMenusCommand());

            AddMenuCommand = new Command(OnAddMenu);
        }

        async Task ExecuteLoadMenusCommand()
        {
            IsBusy = true;

            try
            {
                MenuItems.Clear();
                var items = await MenuStore.GetMenusAsync(true);
                foreach (var menu in items)
                {
                    MenuItems.Add(menu);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        private async void OnAddMenu(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }
    }
}