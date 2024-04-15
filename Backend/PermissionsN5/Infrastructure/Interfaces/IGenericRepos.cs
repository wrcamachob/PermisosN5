using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IGenericRepos<Entity> where Entity : class
    {
        Task<int> RequestPermission(Entity entity);
        Task<int> ModifyPermission(Entity entity);        
        Task<IEnumerable<Entity>> GetPermissions();

    }
}
