using GroceryStore.Backend.Business.Managers;
using GroceryStore.Backend.Business.Managers.Interface;
using GroceryStore.Backend.Business.UoW;
using System.Text;
using GroceryStore.Backend.DAL.Data.DbContext;
using GroceryStore.Backend.DAL.IdentityUserExtend;
using GroceryStore.Backend.DAL.Repository;
using GroceryStore.Backend.DAL.Repository.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace GroceryStore.Backend.Presentation;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddDbContext<GroceryDbContext>(options =>
        {
            options.UseSqlite(builder.Configuration.GetConnectionString("GroceryStoreConnection"));
            options.UseLoggerFactory(LoggerFactory.Create(builder => { builder.AddConsole(); }));
        });

        builder.Services.AddControllers().AddNewtonsoftJson();

        builder.Services.AddCors(option =>
        {
            option.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });
        });

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<GroceryDbContext>();

        builder.Services.AddAuthentication(option =>
        {
            option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(option =>
            {
                option.SaveToken = true;
                option.RequireHttpsMetadata = false;
                option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JWT:ValidAudience"],
                    ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
                };
            });

        builder.Services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequiredLength = 8;
            options.Password.RequiredUniqueChars = 0;
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = false;
        });

        // Business Managers
        builder.Services.AddScoped<ICategoryManager, CategoryManager>();
        builder.Services.AddScoped<IProductManager, ProductManager>();
        builder.Services.AddScoped<IAccountManager, AccountManager>();
        builder.Services.AddScoped<ICartManager, CartManager>();
        builder.Services.AddScoped<IOrderManager, OrderManager>();
        builder.Services.AddScoped<IReviewManager, ReviewManager>();

        //UoW
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Repository
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<IAccountRepository, AccountRepository>();
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<ICartRepository, CartRepository>();
        builder.Services.AddScoped<IOrderRepository, OrderRepository>();
        builder.Services.AddScoped<IReviewRepository, ReviewRepository>();


        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseStaticFiles();

        app.UseRouting();

        app.UseCors();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}

