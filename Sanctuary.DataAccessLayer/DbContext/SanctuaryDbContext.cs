using System.Data.Entity;
using Sanctuary.Entities;

namespace Sanctuary.DataAccessLayer.DbContext
{
    /// <summary>
    /// SanctuaryDbContext class with base DbContext
    /// </summary>
    public class SanctuaryDbContext : System.Data.Entity.DbContext
    {
        /// <summary>
        /// constructor for class SanctuaryDbContext with base DbContext
        /// </summary>
        public SanctuaryDbContext() : base("name = SanctuaryDb")
        {

        }

        /// <summary>
        /// List of all users
        /// </summary>
        public virtual DbSet<User> Users { get; set; }

        /// <summary>
        /// List of all bookings
        /// </summary>
        public virtual DbSet<Booking> Bookings { get; set; }

        /// <summary>
        /// list of all locations
        /// </summary>
        public virtual DbSet<Location> Locations { get; set; }

        /// <summary>
        /// list of all assets
        /// </summary>
        public virtual DbSet<Assets> Assets { get; set; }

        /// <summary>
        /// list of all user amounts
        /// </summary>
        public virtual DbSet<UserAmount> UserAmount { get; set; }
    }
}
