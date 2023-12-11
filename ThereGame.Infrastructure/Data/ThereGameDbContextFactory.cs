namespace Inspirer.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class InspirerDbContextFactory : IDesignTimeDbContextFactory<ThereGameDbContext>
{
    public ThereGameDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ThereGameDbContext>();

        optionsBuilder.UseNpgsql("User ID=admin;Password=XDd1UeO2uAtp2oPj9Pe2SVsFpQXzf4Zn;Host=dpg-cl30qfot3kic73d59ppg-a.frankfurt-postgres.render.com;Port=5432;Database=main_bh1v;Pooling=true;");

        return new ThereGameDbContext(optionsBuilder.Options);
    }
}