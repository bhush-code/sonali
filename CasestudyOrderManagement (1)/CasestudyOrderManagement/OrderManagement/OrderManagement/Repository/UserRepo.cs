using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace OrderManagement.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly Order_75827Context _context;

        public UserRepo(Order_75827Context context)
        {
            _context = context;
        }

        //to get details of all users
        public async Task<IEnumerable<Users>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        //to get details of particular user by userid
        public async Task<Users> GetUsers(int Userid)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.ID == Userid);
        }

        //to Login details
        public async Task<Users> loginCheck(string email, string password)
        {
            Users result = await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public async Task<Users> AddUser(Users users)
        {
            var result = await _context.Users.AddAsync(users);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        //to update an existing user
        public async Task<Users> UpdateUser(Users users)
        {
            var result = await _context.Users.FirstOrDefaultAsync(u => u.ID == users.ID);
            if (result != null)
            {
                result.ID = users.ID;
                result.Name = users.Name;
                result.Email = users.Email;
                result.Type = users.Type;
                result.Status = users.Status;
                await _context.SaveChangesAsync();
            }
            return result;
        }

        //to delete an existing user
        public async Task<Users> DeleteUser(int Userid)
        {
            var result = await _context.Users.FirstOrDefaultAsync(u => u.ID == Userid);
            if (result != null)
            {
                _context.Users.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}