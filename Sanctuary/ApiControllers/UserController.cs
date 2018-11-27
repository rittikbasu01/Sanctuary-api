using IBusinessLayer;
using Sanctuary.Entities;
using Sanctuary.Filters;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Sanctuary.ApiControllers
{
    /// <summary>
    /// User Api Controller
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("User")]
    public class UserController : ApiController
    {
        /// <summary>
        /// user manager
        /// </summary>
        private readonly IUserManager UserManager;

        /// <summary>
        /// constructor for the user controller
        /// </summary>
        /// <param name="userManager">usermanager</param>
        public UserController(IUserManager userManager)
        {
            this.UserManager = userManager;
        }


        /// <summary>
        /// Get all the users
        /// </summary>
        /// <returns>list of users</returns>
        [HttpGet]
        [Route("all")]
        [AllowAnonymous]
        //[JwtAuthentication]
        public async Task<OperationResult> GetUsers()
        {
            return await this.UserManager.GetUsers();
        }

        /// <summary>
        /// login user api call
        /// </summary>
        /// <param name="email">email</param>
        /// <param name="password">password</param>
        /// <returns>User</returns>
        [HttpGet]
        [Route("login")]
        [AllowAnonymous]
        public async Task<OperationResult> GetUser(string email, string password)
        {
            OperationResult result = await this.UserManager.GetUser(email, password);
            if(result == null)
            {
                return result;
            }
            if(result.Status == false)
            {
                return result;
            }
            if (result.StatusCode != HttpStatusCode.OK)
            {
                result.Result = null;
                return result;
            }
            result.Message = JwtManager.GenerateToken((User)result.Result);
            
            return result;            
        }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             

        /// <summary>
        /// forgot password user api call
        /// </summary>
        /// <param name="email">email</param>
        /// <returns>User</returns>
        [HttpGet]
        [Route("forgotPassword")]
        [AllowAnonymous]
        public async Task<OperationResult> GetUser(string email)
        {
            return await this.UserManager.GetUser(email);
        }

        /// <summary>
        /// create a user api call
        /// </summary>
        /// <param name="user">user object</param>
        [HttpPost]
        [Route("Create")]
        [AllowAnonymous]
        public async Task<OperationResult> PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return new OperationResult()
                {
                    Status = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Bad Request",
                    Result = ModelState
                };
            }
            OperationResult result = await this.UserManager.CreateUser(user);
            if (result.StatusCode != HttpStatusCode.Created)
            {
                return result;
            }
            result.Message = JwtManager.GenerateToken(user);
            return result;
        }

        /// <summary>
        /// update a user
        /// </summary>
        /// <param name="user">user object</param>
        [HttpPut]
        [Route("Update")]
        [AllowAnonymous]
        //[JwtAuthentication]
        public async Task<OperationResult> PutUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return new OperationResult()
                {
                    Status = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Bad Request",
                    Result = ModelState
                };
            }
            return await this.UserManager.UpdateUser(user);
            
        }

        /// <summary>
        /// delete a user
        /// </summary>
        /// <param name="id">user id</param>
        [HttpDelete]
        [Route("delete")]
        [AllowAnonymous]
        //[JwtAuthentication]
        public async Task<OperationResult> DeleteUser(Guid id)
        {
            return await this.UserManager.DeleteUser(id);
        }

        [HttpGet]
        [Route("sendEmail")]
        [AllowAnonymous]
        public async Task<OperationResult> SendPassword(string email, int key)
        {
             return await this.UserManager.SendPasswosrd(email, key);
        }

        [HttpPut]
        [Route("addAdmin")]
        [AllowAnonymous]
        public async Task<OperationResult> AddAdmin(User user)
        {
            string email = user.Email;
            if (email == null)
            {
                return new OperationResult()
                {
                    Status = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Bad Request",
                    Result = ModelState
                };
            }
            return await this.UserManager.AddAdmin(email);

        }

        [HttpPut]
        [Route("deleteAdmin")]
        [AllowAnonymous]
        public async Task<OperationResult> DeleteAdmin(User user)
        {
            string email = user.Email;
            if (email == null)
            {
                return new OperationResult()
                {
                    Status = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Bad Request",
                    Result = ModelState
                };
            }
            return await this.UserManager.DeleteAdmin(email);

        }
    }
}
