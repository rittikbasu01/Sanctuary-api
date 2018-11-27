using IBusinessLayer;
using Sanctuary.DataAccessLayer.IServiceRepositry;
using Sanctuary.Entities;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sanctuary.BusinessLayerTest.FakeBusinessLayer
{

    /// <summary>
    /// manages fake user services
    /// </summary>
    public class FakeUserManager : IUserManager
    {

        /// <summary>
        /// interface of user service
        /// </summary>
        public IUserService fakeUserService;

        /// <summary>
        /// Constructor of fake user manager class
        /// </summary>
        /// <param name="fakeUserService">Fake data layer object</param>
        public FakeUserManager(IUserService fakeUserService)
        {
            this.fakeUserService = fakeUserService;
        }


        /// <summary>
        /// Method for creating user
        /// </summary>
        /// <param name="user">Tbluser</param>
        /// <returns>Result class object</returns>
        public async Task<OperationResult> CreateUser(User user)
        {
            OperationResult result = new OperationResult();

            if (user == null)
            {
                result.Status = false;
                return result;
            }


            if (string.IsNullOrWhiteSpace(user.FirstName))
            {
                result.Status = false;
                return result;
            }
            if (!Regex.IsMatch(user.FirstName, @"^[a-zA-Z]*$"))
            {
                result.Status = false;
                return result;
            }
            if (string.IsNullOrWhiteSpace(user.LastName))
            {
                result.Status = false;
                return result;
            }
            if (!Regex.IsMatch(user.LastName, @"^[a-zA-Z]*$"))
            {
                result.Status = false;
                return result;
            }


            if (!Regex.IsMatch(user.Email, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"))
            {
                result.Status = false;
                return result;
            }


            if (string.IsNullOrWhiteSpace(user.CompanyName))
            {
                result.Status = false;
                return result;
            }

            if (string.IsNullOrWhiteSpace(user.Password))
            {
                result.Status = false;
                return result;
            }
            if (user.Password.Trim().Length < 8)
            {
                result.Status = false;
                return result;
            }
            if (Regex.IsMatch(user.Password, @"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=])(?=\\S+$).{8,}$"))
            {
                result.Status = false;
                return result;
            }


            if (string.IsNullOrWhiteSpace(user.PhoneNumber))
            {
                result.Status = false;
                return result;
            }
            if (!Regex.IsMatch(user.PhoneNumber, @"^\(?([1-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$"))
            {
                result.Status = false;
                return result;
            }


            if (string.IsNullOrWhiteSpace(user.SecurityQuestionAnswer))
            {
                result.Status = false;
                return result;
            }
            if (user.SecurityQuestionAnswer.Trim().Length > 21)
            {
                result.Status = false;
                return result;
            }

            return await fakeUserService.CreateUser(user);

        }

        /// <summary>
        /// Fake method for fetching all the user details from fake repository
        /// </summary>
        /// <returns></returns>
        public async Task<OperationResult> GetUsers()
        {
            return await fakeUserService.GetUsers();
        }

        /// <summary>
        /// Fake method for fetching the user details from fake repository with email id
        /// </summary>
        /// <returns></returns>
        public async Task<OperationResult> GetUser(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return new OperationResult()
                {
                    Status = false,
                };
            }

            if (!Regex.IsMatch(email, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"))
            {
                return new OperationResult()
                {
                    Status = false,
                };
            }

            return await fakeUserService.GetUser(email);
        }

        /// <summary>
        /// Fake method for fetching the user details from fake repository with email id and password
        /// </summary>
        /// <returns></returns>
        public async Task<OperationResult> GetUser(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return new OperationResult()
                {
                    Status = false
                };
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return new OperationResult()
                {
                    Status = false
                };
            }

            if (password.Length < 8)
            {
                return new OperationResult()
                {
                    Status = false
                };
            }

            return await fakeUserService.GetUser(email, password);
        }

        /// <summary>
        /// Fake method for updating the user details from fake repository
        /// </summary>
        /// <returns></returns>
        public async Task<OperationResult> UpdateUser(User user)
        {
            if (user.UserId == null)
            {
                return new OperationResult()
                {
                    Status = false
                };
            }

            return await fakeUserService.UpdateUser(user);
        }

        /// <summary>
        /// Fake method for deleting user details from fake repository
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>bool</returns>
        public async Task<OperationResult> DeleteUser(Guid id)
        {
            return await fakeUserService.DeleteUser(id);
        }

        public async Task<OperationResult> SendPasswosrd(string email, int key)
        {
            return new OperationResult();
        }
    }
}
