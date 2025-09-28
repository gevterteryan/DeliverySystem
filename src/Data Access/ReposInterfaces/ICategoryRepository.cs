using Data_Access.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data_Access.ReposInterfaces
{
    public interface ICategoryRepository
    {
        
        Task<List<Category>> GetCategoriesAsync();
    }
}
