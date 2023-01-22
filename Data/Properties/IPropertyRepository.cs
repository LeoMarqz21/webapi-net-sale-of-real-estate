
using WebApiNet.Models;

namespace WebApiNet.Data.Properties;

public interface IPropertyRepository
{
    Task<bool> SaveChangesAsync();
    Task<IEnumerable<Property>> GetAllAsync();
    Task<Property> FindByIdAsync(int id);
    Task CreateAsync(Property property);
    Task DeleteAsync(int id);
}