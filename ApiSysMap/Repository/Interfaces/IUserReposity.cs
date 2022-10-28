using ApiSysMap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSysMap.Repository.Interfaces
{
    interface IUserReposity
    {
        Task<List<UserModels>> GetAllUser();
        Task<UserModels> GetUserId(int id);
        Task<UserModels> Add(UserModels user);
        Task<UserModels> Update(UserModels user, int id);
        Task<bool> Delete(int id);
    }
}
