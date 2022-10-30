using ApiSysMap.Models;
using ApiSysMap.Repository.Interfaces;
using ApiSysMap.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSysMap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase 
    {
        public interface IUserReposity : IDisposable
        {
            Task<List<UserModels>> GetAllUser();
            Task<UserModels> GetUserId(int id);
            Task<UserModels> Add(UserModels user);
            Task<UserModels> Update(UserModels user, int id);
            Task<bool> Delete(int id);
        }

        private readonly IUserReposity _userReposity;

        public UserController(IUserReposity userReposity)
        {
            _userReposity = userReposity;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModels>>> GetAllUser()
        {
            List<UserModels> user = await _userReposity.GetAllUser();
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModels>> GetUserId(int id)
        {
            UserModels user = await _userReposity.GetUserId(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserModels>> Add([FromBody]UserModels userModels)
        {
            UserModels user = await _userReposity.Add(userModels);
            return Ok(user);
        }

    }
}
