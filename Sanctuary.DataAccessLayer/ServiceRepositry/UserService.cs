using Sanctuary.DataAccessLayer.DbContext;
using Sanctuary.DataAccessLayer.IServiceRepositry;
using Sanctuary.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Sanctuary.DataAccessLayer.ServiceRepositry
{
    /// <summary>
    /// UserService which does crud operations on User table
    /// </summary>
    public class UserService : IUserService
    {
        /// <summary>
        /// Db context class for the database
        /// </summary>
        private readonly SanctuaryDbContext SanctuaryDbContext;

        /// <summary>
        /// constructor for the user service
        /// </summary>
        /// <param name="sanctuaryDbContext">sanctuaryDbContext</param>
        public UserService()
        {
            this.SanctuaryDbContext = new SanctuaryDbContext();
        }

        /// <summary>
        /// gets all the users
        /// </summary>
        /// <returns>list of users</returns>
        public async Task<OperationResult> GetUsers()
        {
            var result = this.SanctuaryDbContext.Users.ToListAsync<User>();
            if (result == null)
            {
                return new OperationResult()
                {
                    Status = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "No users found"
                };
            }

            return new OperationResult()
            {
                Status = true,
                StatusCode = HttpStatusCode.OK,
                Result = result
            };

        }

        /// <summary>
        /// creates a new user
        /// </summary>
        /// <param name="user">user</param>
        public async Task<OperationResult> CreateUser(User user)
        {
            try
            {
                UserAmount userAmount = new UserAmount()
                {
                    User_Id = user.UserId,
                    User_Email = user.Email
                    
                };
                this.SanctuaryDbContext.Users.Add(user);
                this.SanctuaryDbContext.UserAmount.Add(userAmount);
                await this.SanctuaryDbContext.SaveChangesAsync();
                return new OperationResult()
                {
                    StatusCode = HttpStatusCode.Created,
                    Status = true
                };
            }
            catch (Exception)
            {
                return new OperationResult()
                {
                    Message = "User with EmailId already exists",
                    StatusCode = HttpStatusCode.InternalServerError,
                    Status = false
                };
            }
        }

        /// <summary>
        /// get an existing user
        /// </summary>
        /// <param name="email">email</param>
        /// <param name="password">password</param>
        /// <returns>Operation Result</returns>
        public async Task<OperationResult> GetUser(string email, string password)
        {
            try
            {
                User tempUser = await this.SanctuaryDbContext.Users.Where(user => (user.Email == email && user.Password.Equals(password) && user.IsDeleted == false)).SingleOrDefaultAsync<User>();
                if (tempUser == null || !tempUser.Password.Equals(password))
                {
                    return new OperationResult()
                    {
                        Status = false,
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = "Invalid email/password. Try again"
                    };
                }
                
                return new OperationResult()
                {
                    Status = true,
                    StatusCode = HttpStatusCode.OK,
                    Result = tempUser
                };
            }
            catch (Exception e)
            {
                return new OperationResult()
                {
                    Status = true,
                    StatusCode = HttpStatusCode.OK,

                };
            }
        }

        /// <summary>
        /// get an existing user
        /// </summary>
        /// <param name="email">email</param>
        /// <returns>user</returns>
        public async Task<OperationResult> GetUser(string email)
        {
            User userDetails = await this.SanctuaryDbContext.Users.Where(user => user.Email == email && user.IsDeleted == false).SingleOrDefaultAsync();
            if (userDetails == null)
            {
                return new OperationResult()
                {
                    Status = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Email Id does not exists"
                };
            }

            return new OperationResult()
            {
                Status = true,
                StatusCode = HttpStatusCode.OK,
                Result = userDetails
            };
        }

        /// <summary>
        /// update the password of an existing user
        /// </summary>
        /// <param name="user">user</param>
        /// <returns>Operation result</returns>
        public async Task<OperationResult> UpdateUser(User user)
        {
            try
            {
                User tempUser = this.SanctuaryDbContext.Users.Where(newUser => newUser.Email == user.Email).Single<User>();
                user.UserId = tempUser.UserId;
                this.SanctuaryDbContext.Entry(tempUser).CurrentValues.SetValues(user);
                await this.SanctuaryDbContext.SaveChangesAsync();
                return new OperationResult()
                {
                    Status = true,
                    StatusCode = HttpStatusCode.OK,
                    Message = "Updated Successfully"
                };
            }
            catch (Exception)
            {
                return new OperationResult()
                {
                    Status = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "User does not exists"
                };
            }
        }

        /// <summary>
        /// delete user
        /// </summary>
        /// <param name="id">userid</param>
        /// <returns>Operation result</returns>
        public async Task<OperationResult> DeleteUser(Guid id)
        {

            try
            {
                User tempUser = this.SanctuaryDbContext.Users.Where(newUser => newUser.UserId == id).Single<User>();
                tempUser.IsDeleted = true;
                this.SanctuaryDbContext.Entry(tempUser).CurrentValues.SetValues(tempUser);
                await this.SanctuaryDbContext.SaveChangesAsync();
                return new OperationResult()
                {
                    Status = true,
                    StatusCode = HttpStatusCode.OK,
                    Message = "Deleted Successfully"
                };
            }
            catch (Exception)
            {
                return new OperationResult()
                {
                    Status = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "User does not exists"
                };
            }
        }

        /// <summary>
        /// update theadmin for existing user
        /// </summary>
        /// <param name="user">user</param>
        /// <returns>Operation result</returns>
        public async Task<OperationResult> AddAdmin(string email)
        {
            try
            {
                User tempUser = this.SanctuaryDbContext.Users.Where(newUser => newUser.Email == email).Single<User>();
                tempUser.IsAdmin = true;
                // this.SanctuaryDbContext.Entry(tempUser).CurrentValues.SetValues(user);
                await this.SanctuaryDbContext.SaveChangesAsync();
                return new OperationResult()
                {
                    Status = true,
                    StatusCode = HttpStatusCode.OK,
                    Message = "Updated Successfully"
                };
            }
            catch (Exception)
            {
                return new OperationResult()
                {
                    Status = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "User does not exists"
                };
            }
        }
        /// <summary>
        /// delete theadmin for existing user
        /// </summary>
        /// <param name="user">user</param>
        /// <returns>Operation result</returns>
        public async Task<OperationResult> DeleteAdmin(string email)
        {
            try
            {
                User tempUser = this.SanctuaryDbContext.Users.Where(newUser => newUser.Email == email).Single<User>();
                tempUser.IsAdmin = false;
                // this.SanctuaryDbContext.Entry(tempUser).CurrentValues.SetValues(user);
                await this.SanctuaryDbContext.SaveChangesAsync();
                return new OperationResult()
                {
                    Status = true,
                    StatusCode = HttpStatusCode.OK,
                    Message = "Updated Successfully"
                };
            }
            catch (Exception)
            {
                return new OperationResult()
                {
                    Status = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "User does not exists"
                };
            }

        }
    }
}

