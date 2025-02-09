using Instagram.Dal;
using Microsoft.EntityFrameworkCore;

namespace Instagram.Server.Configurations;

public static class DataBaseConfiguration
{
    public static void ConfigureDataBase(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DataBaseConnection");

        builder.Services.AddDbContext<MainContext>(b =>
            b.UseSqlServer(connectionString, options =>
                options.MigrationsAssembly("Instagram.Dal"))); // ✅ Migrations fayllari qayerda joylashganini ko‘rsatish
    }



    //public static void ConfigureDataBase(this WebApplicationBuilder builder)
    //{
    //    var connectionString = builder.Configuration.GetConnectionString("DataBaseConnection");
    //    builder.Services.AddDbContext<MainContext>(b => b.UseSqlServer(connectionString));
    //}
}
