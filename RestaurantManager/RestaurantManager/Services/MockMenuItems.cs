using RestaurantManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManager.Services
{
    public class MockMenuItems : IMenuItemStore<MenuItem>
    {
        public List<MenuItem> menuItems;

        public MockMenuItems()
        {
            menuItems = new List<MenuItem>()
            {
                new MenuItem { Id = "1", Name = "First menu", Description="This is the menu description." },
                new MenuItem { Id = "2", Name = "Second menu", Description="This is the menu description." },
                new MenuItem { Id = "3", Name = "Third menu", Description="This is the menu description." },
                new MenuItem { Id = "4", Name = "Fourth menu", Description="This is the menu description." },
                new MenuItem { Id = "5", Name = "Fifth menu", Description="This is the menu description." },
                new MenuItem { Id = "6", Name = "Sixth menu", Description="This is the menu description." }
            };
        }

        public async Task<bool> AddMenuAsync(MenuItem item)
        {
            menuItems.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateMenuAsync(MenuItem item)
        {
            var oldItem = menuItems.Where((MenuItem arg) => arg.Id == item.Id).FirstOrDefault();
            menuItems.Remove(oldItem);
            menuItems.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteMenuAsync(string id)
        {
            var oldItem = menuItems.Where((MenuItem arg) => arg.Id == id).FirstOrDefault();
            menuItems.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<MenuItem> GetMenuAsync(string id)
        {
            return await Task.FromResult(menuItems.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<MenuItem>> GetMenusAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(menuItems);
        }
    }
}
