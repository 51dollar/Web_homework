using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Repository;
using MVC.Service;

namespace MVC
{
    public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")
                ));
			builder.Services.AddScoped<IFriendRepository, FriendRepository>();

			if(builder.Environment.IsDevelopment())
				builder.Services.AddScoped<IFriendService, FriendService>();
			else
				builder.Services.AddScoped<IFriendService, StubFriendService>();

            builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

            var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
