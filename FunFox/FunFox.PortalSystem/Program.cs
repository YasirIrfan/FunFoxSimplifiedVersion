using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using FunFox.PortalSystem.Application;
using FunFox.PortalSystem.Application.Repositories;
using FunFox.PortalSystem.Application.Services;
using FunFox.PortalSystem.Infrastructure;
using FunFox.PortalSystem.Infrastructure.DbContexts;
using FunFox.PortalSystem.Infrastructure.Repositories;
using FunFox.PortalSystem.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

Log.Logger = logger;
try
{
    builder.Host.UseSerilog();

    // Add services to the container.
    if (builder.Environment.IsDevelopment())
    {
        builder.Services.AddWebOptimizer(minifyJavaScript: false, minifyCss: false);
    }
    else
    {
        builder.Services.AddWebOptimizer();
    }

    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), builder =>
        {
            builder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            builder.EnableRetryOnFailure(3);
        });
    });
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();

    builder.Services.AddDefaultIdentity<User>(o =>
    {
        o.SignIn.RequireConfirmedAccount = true;
        o.Password.RequiredLength = 8;
    })
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

    builder.Services.AddInfrastructureModule();
    builder.Services.AddApplicationModule();

    builder.Services.AddControllersWithViews()
        .AddJsonOptions(jsonOptions =>
        {
            jsonOptions.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            jsonOptions.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });

    builder.Services.ConfigureApplicationCookie(options =>
    {
        options.LoginPath = "/Account/Login";
    });
    
    var app = builder.Build();

    app.UseSerilogRequestLogging();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseMigrationsEndPoint();
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseWebOptimizer();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Dashboards}/{action=Dashboard_1}/{id?}");

    app.Seed();

    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, ex.Message);
}