using Sanctuary.DataAccessLayer.IServiceRepositry;
using Sanctuary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanctuary.BusinessLayerTest.FakeDataLayer
{
    /// <summary>
    /// fake UserService for CRUD operations
    /// </summary>
    public class FakeUserService : IUserService
    {

        /// <summary>
        /// List of users for performing CRUD operations
        /// </summary>
        List<TblUser> users = new List<TblUser>()
        {
            new TblUser() { UserId = new Guid("40d24c94-3ea1-4d8d-8e72-2d4e841df05c"), FirstName="deepak", LastName = "tiwari", Email = "deepak.tiwari@gmail.com", CompanyName = "mindtree", Password = "12345678", PhoneNumber = "9876543210", SecurityQuestion = 1, SecurityQuestionAnswer = "sample", IsDeleted = false},
            new TblUser() { UserId = new Guid("40d24c95-3ea1-4d8d-8e72-2d4e841df05c"), FirstName="Brhamaiha", LastName = "shaik", Email = "Brhamaiha.shaik@gmail.com", CompanyName = "mindtree", Password = "qwertyui", PhoneNumber = "9876543210", SecurityQuestion = 2, SecurityQuestionAnswer = "mindtree", IsDeleted = false},
            new TblUser() { UserId = new Guid("40d24c96-3ea1-4d8d-8e72-2d4e841df05c"), FirstName="shamil", LastName = "s", Email = "shamil371@gmail.com", CompanyName = "mindtree", Password = "abcdefghi", PhoneNumber = "9876543210", SecurityQuestion = 3, SecurityQuestionAnswer = "liverpool", IsDeleted = false},
            new TblUser() { UserId = new Guid("40d24c97-3ea1-4d8d-8e72-2d4e841df05c"), FirstName="sanket", LastName = "c", Email = "sanket.c@gmail.com", CompanyName = "mindtree", Password = "11223344", PhoneNumber = "9876543210", SecurityQuestion = 2, SecurityQuestionAnswer = "pole", IsDeleted = false},
            new TblUser() { UserId = new Guid("40d24c98-3ea1-4d8d-8e72-2d4e841df05c"), FirstName="saubarna", LastName = "d", Email = "saubarna.d@gmail.com", CompanyName = "mindtree", Password = "abbcccdddd", PhoneNumber = "9876543210", SecurityQuestion = 1, SecurityQuestionAnswer = "apple", IsDeleted = false}
        };


        /// <summary>
        /// fake method to create a new user
        /// </summary>
        /// <param name="user">user</param>
        public async Task<OperationResult> CreateUser(TblUser user)
        {
            OperationResult result = new OperationResult()
            {
                Status = true
            };
            return result;
        }

        /// <summary>
        /// fake method to gets all the users
        /// </summary>
        /// <returns>list of users</returns>
        public async Task<List<TblUser>> GetUsers()
        {
            return users;
        }

        /// <summary>
        /// fake method to get an existing user
        /// </summary>
        /// <param name="email">email</param>
        /// <returns>user</returns>
        public async Task<TblUser> GetUser(string email)
        {
            foreach (TblUser user in users)
            {
                if (user.Email == email)
                {
                    return user;
                }
            }
            return null;
        }

        /// <summary>
        /// fake method to get an existing user with email and password
        /// </summary>
        /// <param name="email">email</param>
        /// <param name="password">password</param>
        public async Task<OperationResult> GetUser(string email, string password)
        {
            foreach (TblUser user in users)
            {
                if (user.Email == email)
                {
                    if (user.Password == password)
                    {
                        return new OperationResult()
                        {
                            Status = true
                        };
                    }
                    break;
                }
            }
            return null;
        }

        /// <summary>
        /// fake method to update the password of an existing user
        /// </summary>
        /// <param name="user">user</param>
        /// <returns>boolean</returns>
        public async Task<bool> UpdateUser(TblUser testuser)
        {
            foreach (TblUser user in users)
            {
                if (user.UserId == testuser.UserId)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// fake method to delete user
        /// </summary>
        /// <param name="id">userid</param>
        /// <returns>boolean</returns>
        public async Task<bool> DeleteUser(Guid id)
        {
            foreach (TblUser user in users)
            {
                if (user.UserId == id)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
