using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using TezMektepKz;
using TezMektepKz.Data;
using TezMektepKz.Models.Identity;
using TezMektepKz.Repositories.Implementations;
using TezMektepKz.Repositories.Interfaces;
using TezMektepKz.Services.Implementations;
using TezMektepKz.Services.Interfaces;
using TezMektepKz.Localization;

var builder = WebApplication.CreateBuilder(args);

// Подключение строки подключения
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                      ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddDefaultIdentity<AspNetUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Подключение Razor и локализации аннотаций
builder.Services.AddControllersWithViews()
    .AddViewLocalization()
    .AddDataAnnotationsLocalization(options =>
    {
        options.DataAnnotationLocalizerProvider = (type, factory) =>
            factory.Create(typeof(SharedResource));
    });

builder.Services.AddRazorPages()
    .AddViewLocalization()
    .AddDataAnnotationsLocalization(options =>
    {
        options.DataAnnotationLocalizerProvider = (type, factory) =>
            factory.Create(typeof(SharedResource));
    });

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// DI
builder.Services.AddScoped<IOrganizationRepository, OrganizationRepository>();
builder.Services.AddScoped<IOrganizationService, OrganizationService>();
builder.Services.AddScoped<IGradeRepository, GradeRepository>();
builder.Services.AddScoped<IGradeService, GradeService>();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddScoped<IIndividualNumberService, IndividualNumberService>();

var app = builder.Build();

// Культуры
var cultures = new[] { "kk", "ru" };
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(cultures[0])
    .AddSupportedCultures(cultures).AddSupportedUICultures(cultures);
app.UseRequestLocalization(localizationOptions);

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

// Роутинг
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

// Обработка исключений
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();
