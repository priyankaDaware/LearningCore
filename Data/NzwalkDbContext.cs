using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalksAPI.Data
{
    public class NzwalkDbContext:DbContext
    {

        public NzwalkDbContext(DbContextOptions<NzwalkDbContext> dbContextOptions) : base(dbContextOptions)
        { 
        }

        public DbSet<WalkDifficulty> Difficulties { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }
    }
}   
