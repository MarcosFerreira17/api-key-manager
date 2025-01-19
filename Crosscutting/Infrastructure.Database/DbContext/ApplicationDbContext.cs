using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.DbContext;

public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<ApiUser> ApiUsers { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    {
    }
}