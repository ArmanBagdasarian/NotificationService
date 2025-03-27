using Microsoft.EntityFrameworkCore;
using NotificationService.Entities;

namespace NotificationService.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) 
        {

        }

        public DbSet<Notification> Notifications { get; set; }
       
       
    }
}
