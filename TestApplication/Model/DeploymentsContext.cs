using Microsoft.EntityFrameworkCore;

namespace TestApplication.Model
{
    public class DeploymentsContext : DbContext
    {
        // Configuring database context options
        // it is the context code with constructor
        public DeploymentsContext(DbContextOptions<DeploymentsContext> options)
            : base(options)
        {
        }
        // it gets and sets the Deployments items
        public DbSet<Deployment> DeploymentItems { get; set; }

    }
}
