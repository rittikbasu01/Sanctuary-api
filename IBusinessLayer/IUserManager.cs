using Sanctuary.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IBusinessLayer
{
    /// <summary>
    /// interface for the class UserManager
    /// </summary>
    public interface IUserManager
    {
        /// <summary>
        /// creates an new user
        /// </summary>
        /// <param name="user">user</param>
        Task<OperationResult> CreateUser(User user);

        /// <summary>
        /// gets the user with email and password
        /// </summary>
        /// <param name="email">email</param>
        /// <param name="password">password</param>
        /// <returns>user</returns>
        Task<OperationResult> GetUser(string email, string password);

        /// <summary>
        /// gets all users
        /// </summary>
        /// <returns>list of users</returns>
        Task<OperationResult> GetUsers();

        /// <summary>
        /// gets the user with email
        /// </summary>
        /// <param name="email">email</param>
        /// <returns>user</returns>
        Task<OperationResult> GetUser(string email);

        /// <summary>
        /// update the password of an existing user
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
        /// email for forgot password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<OperationResult> SendPasswosrd(string email, int key);

        /// <summary>
        /// updating user as admin using email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<OperationResult> AddAdmin(string email);

        /// <summary>
        /// delete user as admin using email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<OperationResult> DeleteAdmin(string email);
    }
}

