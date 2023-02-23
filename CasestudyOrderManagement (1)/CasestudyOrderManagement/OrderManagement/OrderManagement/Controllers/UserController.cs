using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Models;
using OrderManagement.Repository;

namespace OrderManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepo;

        public UserController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpPost("{login}")]
        public async Task<ActionResult<Users>> Login(string email, string password)
        {
            try
            {
                var returnType = await _userRepo.loginCheck(email, password);
                if (returnType == null)
                {
                    return StatusCode(StatusCodes.Status203NonAuthoritative, "Not Authorized");
                }
                else
                {
                    return returnType;
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Login Error......");
            }
        }

        // GET: api/Users/5
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetAllUsers()
        {
            try
            {
                return (await _userRepo.GetAllUsers()).ToList();
            }
            catch (Exception ex)
            {
                ex.ToString();
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetAllUsersById(int id)
        {
            try
            {
                var result = await _userRepo.GetUsers(id);
                if (result == null) return NotFound();
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<Users>> CreateUser(Users users)
        {
            try
            {
                if (users == null)
                {
                    return BadRequest();
                }
                var createUser = await _userRepo.AddUser(users);
                return CreatedAtAction(nameof(GetAllUsersById), new { id = createUser.ID }, createUser);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while creating new user..");
            }

        }

        //PUT: api/Users
        [HttpPut("{id}")]
        public async Task<ActionResult<Users>> UpdateUser(int id, Users users)
        {
            try
            {
                if (id != users.ID)
                {
                    return BadRequest("UserID mismatch....");
                }
                var userToUpdate = await _userRepo.GetUsers(id);
                if (userToUpdate == null)
                {
                    return NotFound("user with ID {id} not found...");
                }
                return await _userRepo.UpdateUser(users);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating data..");

            }
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<Users> DeleteUsers(int id)
        {
            try
            {
                var userToDelete = await _userRepo.GetUsers(id);
                if (userToDelete == null)
                {
                    NotFound($"user with ID {id} found");
                }
                await _userRepo.DeleteUser(id);
                return userToDelete;

            }
            catch (Exception)
            {
                StatusCode(StatusCodes.Status500InternalServerError, "Error while deleting user..");
            }
            return null;

        }
    }
}