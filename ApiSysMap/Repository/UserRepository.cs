using ApiSysMap.Models;
using ApiSysMap.Data;
using ApiSysMap.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApiSysMap.Repository
{
    public class UserRepository : IUserReposity
    {
        private readonly SystemSalesDBContex _dbcontex;

        public UserRepository(SystemSalesDBContex systemSalesDBContex)
        {
            _dbcontex = systemSalesDBContex;
        }

        public async Task<List<UserModels>> GetAllUser()
        {
            return await _dbcontex.User.ToListAsync();
        }

        public async Task<UserModels> GetUserId(int id)
        {
            return  await _dbcontex.User.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserModels> Add(UserModels user)
        {
            await _dbcontex.User.AddAsync(user);
            await _dbcontex.SaveChangesAsync();
            return user;
        }

        public async Task<UserModels> Update(UserModels user, int id)
        {
            UserModels userForId = await GetUserId(id);

            if(userForId == null)
            {
                throw new Exception("User for ID: " + id + " Not found.");
            }

            userForId.Name = user.Name;
            userForId.Email = user.Email;

            _dbcontex.User.Update(userForId);
            await _dbcontex.SaveChangesAsync();

            return userForId;
        }

        public async Task<bool> Delete(int id)
        {
            UserModels userForId = await GetUserId(id);

            if (userForId == null)
            {
                throw new Exception("User for ID: " + id + " Not found.");
            }

            _dbcontex.User.Remove(userForId);
            await _dbcontex.SaveChangesAsync();

            return true;
        }
    }
}
