
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RBProducts.Application.Contexts;
using RBProducts.Application.Services.Products.Commands.Delete;
using RBProducts.Application.Services.Products.Commands.Insert;
using RBProducts.Application.Services.Products.Commands.Update;
using RBProducts.Application.Services.Products.Queries.GetProducts;
using RBProducts.Endpoint.WebAPI.Middlewares;
using RBProducts.Endpoint.WebAPI.Services.Security.Login;
using RBProducts.Persistence.Contexts;
using System.Text;

namespace RBProducts.Endpoint.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            Services(builder.Services,builder.Configuration);
            var app = builder.Build();
            Middlewares(app);
            app.UseDefaultIdentity(builder.Configuration);
            app.UseDefaultMigrate<DataBaseContext>();
            app.Run();
        }

        public static void Services(IServiceCollection services , ConfigurationManager config)
        {
            services.AddScoped<IDataBaseContext, DataBaseContext>();
            services.AddScoped<IGetProductsService, GetProductsService>();
            services.AddScoped<IInsertProductService, InsertProductService>();
            services.AddScoped<IDeleteProductService, DeleteProductService>();
            services.AddScoped<IUpdateProductService, UpdateProductService>();
            services.AddScoped<ICheckLoginService, CheckLoginService>();

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<DataBaseContext>(o => o
                    .UseSqlServer(config.GetConnectionString("DefaultConnection")));
            
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<DataBaseContext>()
                .AddDefaultTokenProviders();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = false , ValidateIssuer = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Secret"]))
                };
            });

            var app = builder.Build();

        }
        public static void Middlewares(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();
            app.UseFileServer();
        }
    }
}