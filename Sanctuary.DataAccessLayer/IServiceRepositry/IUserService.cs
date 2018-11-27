using Sanctuary.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sanctuary.DataAccessLayer.IServiceRepositry
{
    /// <summary>
    /// interface for UserService
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// gets all users
        /// </summary>
        /// <returns>list of users</returns>
        Task<OperationResult> GetUsers();

        /// <summary>
        /// creates a new user
        /// </summary>
        /// <param name="user">user</param>
        Task<OperationResult> CreateUser(User user);

        /// <summary>
        /// get an existing user
        /// </summary>
        /// <param name="email">email</param>
        /// <param name="password">password</param>
        /// <returns>user</returns>
        Task<OperationResult> GetUser(string email, string password);

        /// <summary>
        /// get an existing user
        /// </summary>
        /// <param name="email">email</param>
        /// <returns>user</returns>
        Task<OperationResult> GetUser(string email);

        /// <summary>
        ///  update the password of an existing user
        /// </summary>
        /// <param name="user">user</param>
        /// <returns>boolean</returns>
        Task<OperationResult> UpdateUser(User user);

        /// <summary>
        /// deletes user
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>boolean</returns>
        Task<OperationResult> DeleteUser(Guid id);

        /// <summary>
        ///  update the admin for existing user
        /// </summary>
        /// <param name="user">user</param>
        /// <returns>boolean</returns>
        Task<OperationResult> AddAdmin(string email);

        /// <summary>
        ///  delete the admin for existing user
        /// </summary>
        /// <param name="user">user</param>
        /// <returns>boolean</returns>
        Task<OperationResult> DeleteAdmin(string email);
    }
}
