using IBusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sanctuary.BusinessLayerTest.FakeBusinessLayer;
using Sanctuary.BusinessLayerTest.FakeDataLayer;
using Sanctuary.Entities;
using System;


namespace Sanctuary.BusinessLayerTest
{
    [TestClass]
    public class UserManagerTest
    {

        /// <summary>
        /// interface of user manager
        /// </summary>
        private readonly IUserManager fakeUserManager;

        /// <summary>
        /// Constructor for the class UserManagerTest
        /// </summary>
        public UserManagerTest()
        {
            fakeUserManager = new FakeUserManager(new FakeUserService());
        }


        #region Unit test methods for CreateUser() method

        /// <summary>
        /// Unit test method create for user with valid data
        /// </summary>
        [TestMethod]
        public void UserManager_CreateUser_ValidTest()
        {
            var result = fakeUserManager.CreateUser(new User()
            {
                FirstName = "Jacob",
                LastName = "George",
                Email = "jacobgeorge@gmail.com",
                CompanyName = "mindtree",
                Password = "Qwerty_371",
                PhoneNumber = "9876543210",
                SecurityQuestion = 2,
                SecurityQuestionAnswer = "Javahar Navodaya"
            }).Result;
            Assert.IsTrue(result.Status);
        }


        /// <summary>
        /// Unit test method for create user with invalid name
        /// </summary>
        [TestMethod]
        public void UserManager_CreateUser_InvalidName_Test()
        {
            var result = fakeUserManager.CreateUser(new User() { }).Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.CreateUser(new User() { FirstName = "", LastName = "" }).Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.CreateUser(new User() { FirstName = "Shamil371", LastName = "s" }).Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.CreateUser(new User() { FirstName = "Shamil@371", LastName = "s" }).Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.CreateUser(new User() { FirstName = "Shamil", LastName = "s3" }).Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.CreateUser(new User() { FirstName = "Shamil", LastName = "s@36" }).Result;
            Assert.IsFalse(result.Status);
        }


        /// <summary>
        /// Unit test method for create user with invalid email
        /// </summary>
        [TestMethod]
        public void UserManager_CreateUser_InvalidEmail_Test()
        {
            var result = fakeUserManager.CreateUser(new User() { FirstName = "Shamil", LastName = "s", Email = "@." }).Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.CreateUser(new User() { FirstName = "Shamil", LastName = "s", Email = "" }).Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.CreateUser(new User() { FirstName = "Shamil", LastName = "s", Email = "shamil@." }).Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.CreateUser(new User() { FirstName = "Shamil", LastName = "s", Email = "shamil@" }).Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.CreateUser(new User() { FirstName = "Shamil", LastName = "s", Email = "shamil." }).Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.CreateUser(new User() { FirstName = "Shamil", LastName = "s", Email = "shamil@gmail." }).Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.CreateUser(new User() { FirstName = "Shamil", LastName = "s", Email = "shamil" }).Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.CreateUser(new User() { FirstName = "Shamil", LastName = "s", Email = "shamil.@" }).Result;
            Assert.IsFalse(result.Status);
        }


        /// <summary>
        /// Unit test method for create user with invalid company name
        /// </summary>
        [TestMethod]
        public void UserManager_CreateUser_InvalidCompanyName_Test()
        {
            var result = fakeUserManager.CreateUser(new User() { FirstName = "Shamil", LastName = "s", Email = "shamil@gmail.com" }).Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.CreateUser(new User() { FirstName = "Shamil", LastName = "s", Email = "shamil@gmail.com", CompanyName = "" }).Result;
            Assert.IsFalse(result.Status);
        }


        /// <summary>
        /// Unit test method for create user with invalid password
        /// </summary>
        [TestMethod]
        public void UserManager_CreateUser_InvalidPassword_Test()
        {
            var result = fakeUserManager.CreateUser(new User() { FirstName = "Shamil", LastName = "s", Email = "shamil@gmail.com", CompanyName = "mindtree" }).Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.CreateUser(new User() { FirstName = "Shamil", LastName = "s", Email = "shamil@gmail.com", CompanyName = "mindtree", Password = "" }).Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.CreateUser(new User() { FirstName = "Shamil", LastName = "s", Email = "shamil@gmail.com", CompanyName = "mindtree", Password = "qwerty" }).Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.CreateUser(new User() { FirstName = "Shamil", LastName = "s", Email = "shamil@gmail.com", CompanyName = "mindtree", Password = "        " }).Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.CreateUser(new User() { FirstName = "Shamil", LastName = "s", Email = "shamil@gmail.com", CompanyName = "mindtree", Password = "   Qwert" }).Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.CreateUser(new User() { FirstName = "Shamil", LastName = "s", Email = "shamil@gmail.com", CompanyName = "mindtree", Password = "qwer  ty" }).Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.CreateUser(new User() { FirstName = "Shamil", LastName = "s", Email = "shamil@gmail.com", CompanyName = "mindtree", Password = "qwe@tyui" }).Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.CreateUser(new User() { FirstName = "Shamil", LastName = "s", Email = "shamil@gmail.com", CompanyName = "mindtree", Password = "qwer#1ty" }).Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.CreateUser(new User() { FirstName = "Shamil", LastName = "s", Email = "shamil@gmail.com", CompanyName = "mindtree", Password = "Qwerty_ui" }).Result;
            Assert.IsFalse(result.Status);
        }


        /// <summary>
        /// Unit test method for create user with invalid phone number
        /// </summary>
        [TestMethod]
        public void UserManager_CreateUser_InvalidPhoneNumber_Test()
        {
            var result = fakeUserManager.CreateUser(new User() { FirstName = "Shamil", LastName = "s", Email = "shamil@gmail.com", CompanyName = "mindtree", Password = "qwerty123" }).Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.CreateUser(new User() { FirstName = "Shamil", LastName = "s", Email = "shamil@gmail.com", CompanyName = "mindtree", Password = "qwerty123", PhoneNumber = "" }).Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.CreateUser(new User() { FirstName = "Shamil", LastName = "s", Email = "shamil@gmail.com", CompanyName = "mindtree", Password = "qwerty123", PhoneNumber = "123" }).Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.CreateUser(new User() { FirstName = "Shamil", LastName = "s", Email = "shamil@gmail.com", CompanyName = "mindtree", Password = "qwerty123", PhoneNumber = "0123456789" }).Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.CreateUser(new User() { FirstName = "Shamil", LastName = "s", Email = "shamil@gmail.com", CompanyName = "mindtree", Password = "qwerty123", PhoneNumber = "0000000000" }).Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.CreateUser(new User() { FirstName = "Shamil", LastName = "s", Email = "shamil@gmail.com", CompanyName = "mindtree", Password = "qwerty123", PhoneNumber = "abcdefghij" }).Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.CreateUser(new User() { FirstName = "Shamil", LastName = "s", Email = "shamil@gmail.com", CompanyName = "mindtree", Password = "qwerty123", PhoneNumber = "1234abcdef" }).Result;
            Assert.IsFalse(result.Status);
        }


        /// <summary>
        /// Unit test method for create user with invalid security answer
        /// </summary>
        [TestMethod]
        public void UserManager_CreateUser_InvalidSecurityAnswer_Test()
        {
            var result = fakeUserManager.CreateUser(new User() { FirstName = "Shamil", LastName = "s", Email = "shamil@gmail.com", CompanyName = "mindtree", Password = "qwerty123", PhoneNumber = "1234567890" }).Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.CreateUser(new User() { FirstName = "Shamil", LastName = "s", Email = "shamil@gmail.com", CompanyName = "mindtree", Password = "qwerty123", PhoneNumber = "1234567890", SecurityQuestionAnswer = "" }).Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.CreateUser(new User() { FirstName = "Shamil", LastName = "s", Email = "shamil@gmail.com", CompanyName = "mindtree", Password = "qwerty123", PhoneNumber = "1234567890", SecurityQuestionAnswer = "my security answer is Nothing" }).Result;
            Assert.IsFalse(result.Status);
        }

        #endregion


        #region Unit test methods for GetUser() method

        /// <summary>
        /// Unit test method for fetching all the user details for valid condition
        /// </summary>
        [TestMethod]
        public void UserManager_GetUser_ValidTest()
        {
            var result = fakeUserManager.GetUsers().Result;
            int count = (int)result.Result;
            Assert.IsTrue(count == 5);
            
        }


        /// <summary>
        /// Unit test method for fetching all the user details for invalid condition
        /// </summary>
        [TestMethod]
        public void UserManager_GetUser_InvalidTest()
        {
            var result = fakeUserManager.GetUsers().Result;
            int count = (int)result.Result;
            Assert.IsFalse(count == 6);
        }

        #endregion

        #region Unit test methods for GetUser() method with param email

        /// <summary>
        /// Unit test method for fetching user details with valid email id
        /// </summary>
        [TestMethod]
        public void UserManager_GetUser_ValidEmail_Test()
        {
            User testUser = new User()
            {
                Email = "shamil371@gmail.com"
            };

            var result = fakeUserManager.GetUser(testUser.Email).Result;
            Assert.IsTrue(result.Status);
        }


        /// <summary>
        /// Unit test method for fetching user details with invalid email id
        /// </summary>
        [TestMethod]
        public void UserManager_GetUser_InvalidEmail_Test()
        {
            User testUser = new User();

            var result = fakeUserManager.GetUser(testUser.Email).Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.GetUser(testUser.Email = "").Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.GetUser(testUser.Email = "@.").Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.GetUser(testUser.Email = "shamil@.").Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.GetUser(testUser.Email = "shamil@").Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.GetUser(testUser.Email = "shamil.").Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.GetUser(testUser.Email = "shamil@gmail").Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.GetUser(testUser.Email = "shamil@gmail.").Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.GetUser(testUser.Email = "shamil@gmail.com").Result;
            Assert.IsFalse(result.Status);

        }

        #endregion


        #region Unit test methods for GetUser() method with param email and password

        /// <summary>
        /// Unit test method for fetching user details with valid email id and password
        /// </summary>
        [TestMethod]
        public void UserManager_GetUser_ValidEmail_Password_Test()
        {
            User testUser = new User()
            {
                Email = "shamil371@gmail.com",
                Password = "abcdefghi",
            };

            var result = fakeUserManager.GetUser(testUser.Email, testUser.Password).Result;
            Assert.IsTrue(result.Status);
        }


        /// <summary>
        /// Unit test method for fetching user details with invalid email id and password
        /// </summary>
        [TestMethod]
        public void UserManager_GetUser_InvalidEmail_Password_Test()
        {
            User testUser = new User();

            var result = fakeUserManager.GetUser(testUser.Email, testUser.Password).Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.GetUser(testUser.Email = "", testUser.Password = "").Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.GetUser(testUser.Email = "shamil@gmail.com", testUser.Password = "").Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.GetUser(testUser.Email = "", testUser.Password = "qwertyui").Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.GetUser(testUser.Email = "shamil@gmail.com", testUser.Password = "12345678").Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.GetUser(testUser.Email = "shamil@gmail.com", testUser.Password = "abc").Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.GetUser(testUser.Email = "shamil371@gmail.com", testUser.Password = "12345678").Result;
            Assert.IsFalse(result.Status);
        }

        #endregion

        #region Unit test methods for UpdateUser() method

        /// <summary>
        /// Unit test method for updating user details with valid user id
        /// </summary>
        [TestMethod]
        public void UserManager_UpdateUser_ValidTest()
        {
            var result = fakeUserManager.UpdateUser(new User() { UserId = new Guid("40d24c96-3ea1-4d8d-8e72-2d4e841df05c") }).Result;
            Assert.IsTrue(result.Status);
        }


        /// <summary>
        /// Unit test method for updating user details with invalid user id
        /// </summary>
        [TestMethod]
        public void UserManager_UpdateUser_InvalidUserId_Test()
        {

            var result = fakeUserManager.UpdateUser(new User()).Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.UpdateUser(new User() { UserId = new Guid("40d24c67-3ea1-4d8d-8e72-2d4e841df05c") }).Result;
            Assert.IsFalse(result.Status);
        }

        #endregion


        #region Unit test methods for DeleteUser() method

        /// <summary>
        /// Unit test method for deleting user with valid id
        /// </summary>
        [TestMethod]
        public void UserManager_DeleteUser_ValidTest()
        {
            User testUser = new User()
            {
                UserId = new Guid("40d24c96-3ea1-4d8d-8e72-2d4e841df05c")
            };

            var result = fakeUserManager.DeleteUser(testUser.UserId).Result;
            Assert.IsTrue(result.Status);
        }


        /// <summary>
        /// Unit test method for deleting user with invalid id
        /// </summary>
        [TestMethod]
        public void UserManager_DeleteUser_InvalidId_Test()
        {
            User testUser = new User();

            var result = fakeUserManager.DeleteUser(testUser.UserId).Result;
            Assert.IsFalse(result.Status);

            result = fakeUserManager.DeleteUser(testUser.UserId = new Guid("40d24c46-3ea1-4d8d-8e72-2d4e841df05c")).Result;
            Assert.IsFalse(result.Status);
        }

        #endregion



    }
}
