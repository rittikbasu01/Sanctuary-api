using Sanctuary.DataAccessLayer.DbContext;
using Sanctuary.DataAccessLayer.IServiceRepositry;
using Sanctuary.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanctuary.DataAccessLayer.ServiceRepositry
{
    public class UserAmountService : IUserAmountService
    {
        /// <summary>
        /// Db context class for the database
        /// </summary>
        private readonly SanctuaryDbContext SanctuaryDbContext;

        /// <summary>
        /// constructor for the user amount service
        /// </summary>
        /// <param name="sanctuaryDbContext">sanctuaryDbContext</param>
        public UserAmountService()
        {
            this.SanctuaryDbContext = new SanctuaryDbContext();
        }

        public async Task<UserAmount> GetUserAmount(string email)
        {

            try
            {
                UserAmount userAmountDetails = await this.SanctuaryDbContext.UserAmount.Where(userAmount => userAmount.User_Email.Equals(email)).SingleOrDefaultAsync<UserAmount>();
                return userAmountDetails;
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
