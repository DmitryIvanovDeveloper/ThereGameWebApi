namespace ThereGame.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class ThereGameDbContextFactory : IDesignTimeDbContextFactory<ThereGameDbContext>
{
    public ThereGameDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ThereGameDbContext>();
        
        optionsBuilder.UseNpgsql("User ID=admin;Password=zN81fUfa1SZxcYHvp1IoaaHBtL7mE7IY;Host=dpg-clsanntetvis73b7cjv0-a.frankfurt-postgres.render.com;Port=5432;Database=maindb_cxi8;Pooling=true;");
        return new ThereGameDbContext(optionsBuilder.Options);
    }
}