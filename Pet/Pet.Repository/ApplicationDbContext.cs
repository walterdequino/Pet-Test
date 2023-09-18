using Microsoft.EntityFrameworkCore;

using Pets.Repository.Entities;

namespace Pets.Repository
{
    /// <summary>
    /// Application Db Context
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Pets
        /// </summary>
        public DbSet<Pet> Pets { get; set; }
    }
}
