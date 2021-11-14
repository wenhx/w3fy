using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace W3fy.Portal;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages();

        services.AddDbContext<Data.W3fyDbContext>(options =>
            options.UseSqlite("Data Source=..\\..\\database\\W3fy.db"));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            InitializeDevelopmentDatabase(app);
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
        });
    }

    static void InitializeDevelopmentDatabase(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        Data.DevelopmentDataSeeder.Initialize(scope.ServiceProvider);
    }
}
