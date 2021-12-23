using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantManager.Services
{
    public interface IMenuItemStore<T>
    {
        Task<bool> AddMenuAsync(T MenuItem);
        Task<bool> UpdateMenuAsync(T MenuItem);
        Task<bool> DeleteMenuAsync(string id);
        Task<T> GetMenuAsync(string id);
        Task<IEnumerable<T>> GetMenusAsync(bool forceRefresh = false);
    }
}
