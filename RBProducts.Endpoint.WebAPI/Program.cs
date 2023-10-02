
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RBProducts.Application.Contexts;
using RBProducts.Application.Services.Products.Commands.Delete;
using RBProducts.Application.Services.Products.Commands.Insert;
using RBProducts.Application.Services.Products.Commands.Update;
using RBProducts.Application.Services.Products.Queries.GetProducts;
using RBProducts.Common.Models;
using RBProducts.Endpoint.WebAPI.Middlewares;
using RBProducts.Endpoint.WebAPI.Services.Security.Login;
using RBProducts.Endpoint.WebAPI.Utils;
using RBProducts.Persistence.Contexts;
using System.Net;
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
            services.AddAutoMapper(typeof(Program));
            services.AddScoped<IDataBaseContext, DataBaseContext>();
            services.AddScoped<IGetProductsService, GetProductsService>();
            services.AddScoped<IInsertProductService, InsertProductService>();
            services.AddScoped<IDeleteProductService, DeleteProductService>();
            services.AddScoped<IUpdateProductService, UpdateProductService>();
            services.AddScoped<ILoginService, LoginService>();

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<DataBaseContext>(o => o
                    .UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddControllers(option => {
                // option.Filters.Add<ValidationFilter>();
            });
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


        }
        public static void Middlewares(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                
            }
            app.Use(async (context, next) =>
            {
                await next();

                if (context.Response.StatusCode == (int)HttpStatusCode.Unauthorized) // 401
                {
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(new OperationResultDto<Exception>()
                    {
                        IsSuccess = false,
                        Message = "Token is not valid"
                    }));
                }
            });
            app.UseExceptionHandler(exceptionHandlerApp =>
            {
                exceptionHandlerApp.Run(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "application/json";
                    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    var msg = "";
                    var ex = exceptionHandlerPathFeature?.Error;
                    if (ex is FileNotFoundException)
                    {
                        msg = "مسیر فایل درخواستی یافت نشد";
                    }
                    else { msg = ex.Message; }
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(new OperationResultDto<Exception>() { 
                        Message = msg, 
                        IsSuccess = false, 
                        Result = app.Environment.IsDevelopment() ? ex : null }));
                });
            });
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();
            app.UseFileServer();
        }
    }
}