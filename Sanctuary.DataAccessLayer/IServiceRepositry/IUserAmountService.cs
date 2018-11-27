using Sanctuary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanctuary.DataAccessLayer.IServiceRepositry
{
    /// <summary>
    /// interface for UserAmountService
    /// </summary>
    public interface IUserAmountService
    {
        /// <summary>
        /// get an existing user amount details
        /// </summary>
        /// <param name="email">email</param>
        /// <returns>user</returns>
        Task<UserAmount> GetUserAmount(string email);
    }
}
