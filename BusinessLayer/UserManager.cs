using IBusinessLayer;
using System.Collections.Generic;
using Sanctuary.DataAccessLayer.IServiceRepositry;
using Sanctuary.Entities;
using System.Threading.Tasks;
using System;
using System.Text.RegularExpressions;
using System.Net;
using Sanctuary.Handlers;

namespace BusinessLayer
{
    /// <summary>
    /// manages user services
    /// </summary>
    public class UserManager : IUserManager
    {
        /// <summary>
        /// interface of user service
        /// </summary>
        private readonly IUserService UserService;
        
        private EmailNotifications EmailNotification { get; set; }
        /// <summary>
        /// constructor for the class user manager
        /// </summary>
        /// <param name="userService">userservice</param>
        public UserManager(IUserService userService)
        {
            this.UserService = userService;
            this.EmailNotification = new EmailNotifications();
        }

        /// <summary>
        /// get all the users
        /// </summary>
        /// <returns>list of users</returns>
        public async Task<OperationResult> GetUsers()
        {
            return await this.UserService.GetUsers();
        }

        /// <summary>
        /// create a new user
        /// </summary>
        /// <param name="user">user</param>
        public async Task<OperationResult> CreateUser(User user)
        {
            return await this.UserService.CreateUser(user);
        }

        /// <summary>
        /// gets the user with the email and password
        /// </summary>
        /// <param name="email">email</param>
        /// <param name="password">password</param>
        /// <returns>user</returns>
        public async Task<OperationResult> GetUser(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return new OperationResult()
                {
                    Status = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Invalid Email Id"
                };
            }

            if (!Regex.IsMatch(email, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"))
            {
                return new OperationResult()
                {
                    Status = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Invalid Email Id"
                };
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return new OperationResult()
                {
                    Status = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Password cannot be empty"
                };
            }
            if (password.Trim().Length < 8)
            {
                return new OperationResult()
                {
                    Status = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Password should have atleast 8 characters"
                };
            }
            if (Regex.IsMatch(password, @"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=])(?=\\S+$).{8,}$"))
            {
                return new OperationResult()
                {
                    Status = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Invalid password"
                };
            }

            return await this.UserService.GetUser(email, password);
        }

        /// <summary>
        /// gets the user with the email
        /// </summary>
        /// <param name="email">email</param>
        /// <returns>user</returns>
        public async Task<OperationResult> GetUser(string email)
        {
            return await this.UserService.GetUser(email);
        }
        
        public async Task<OperationResult> SendPasswosrd(string email, int key)
        {
            OperationResult result = await this.GetUser(email);
            if(!result.Status)
            {
                result.Message = "email Id does not exists";
                return result;
            }
            try
            {
                User tempUser = new User();
                tempUser = (User)result.Result;
                this.EmailNotification.SendPassword(email, tempUser.Password);
            }
            catch (Exception)
            {
                result.Message = "email Id does not exists";
            }
            return result;
        }
        /// <summary>
        /// update the password of an existing user
        /// </summary>
        /// <param name="user">user</param>
        /// <returns>boolean</returns>
        public async Task<OperationResult> UpdateUser(User user)
        {
            return await this.UserService.UpdateUser(user);
        }

        /// <summary>
        /// deletes user
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>Operation result</returns>
        public async Task<OperationResult> DeleteUser(Guid id)
        {
            return await this.UserService.DeleteUser(id);
        }

        /// <summary>
        /// update the admin for existing user
        /// </summary>
        /// <param name="user">user</param>
        /// <returns>boolean</returns>
        public async Task<OperationResult> AddAdmin(string email)
        {
            return await this.UserService.AddAdmin(email);
        }

        /// <summary>
        /// delete the admin for existing user
        /// </summary>
        /// <param name="user">user</param>
        /// <returns>boolean</returns>
        public async Task<OperationResult> DeleteAdmin(string email)
        {
            return await this.UserService.DeleteAdmin(email);
        }
    }
}
