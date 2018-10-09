using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiSkeleton.DTO;

namespace WebApiSkeleton.Models.Interfaces
{
    public interface IUWHUsersModel
    {
        Task<List<UWHUsers>> Get();
        Task<bool> Delete(int id);
        Task<UWHUsers> Update(int id, UWHUsers user);
        Task<List<UWHUsers>> Save(List<UWHUsers> userList);
        Task<UWHUsers> Get(int id);
    }
}
