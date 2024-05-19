using CoreLayer.Services.Implementation;
using CoreLayer.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using NakShop.Data.Context;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;

services.AddControllersWithViews();

services.AddTransient<IPostService, PostService>();
services.AddTransient<IAboutUsService, AboutUsService>();
services.AddTransient<IContactUsService, ContactUsService>();
services.AddTransient<ICommentService, CommentService>();
services.AddTransient<IFAQService, FAQsService>();
services.AddTransient<IMessageService, MessageService>();
services.AddTransient<IServiceService, ServiceService>();
services.AddTransient<ISliderService, SliderService>();

services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Debug()
                        .WriteTo.File($"{AppDomain.CurrentDomain.BaseDirectory}\\Logs\\Log.txt", rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true, fileSizeLimitBytes: 10240)
                        .CreateLogger();

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

app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.Run();
