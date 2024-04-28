using BlogPost.Data.DbContexts;
using BlogPost.Data.Interfaces;
using BlogPost.Data.Repositories;

using BlogPost.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Serilog;

using BlogPost.Application.Common.Validators;
using BlogPost.Application.Interfaces;
using BlogPost.Application.Services;

using BlogPost.WebApi.Configurations;
using BlogPost.WebApi.Middlewares;
using Application.Services;



var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// Cache
builder.Services.AddMemoryCache();



// Serilog
builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration));



// Db Context
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDb"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});



// Unit Of Work
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();



// Services
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IAdminService, AdminService>();
builder.Services.AddTransient<IAuthManager, AuthManager>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ICommentService, CommentService>();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddTransient<IOwnerService, OwnerService>();
builder.Services.AddTransient<IPhoneService, PhoneServie>();
builder.Services.AddTransient<IPostService, PostService>();
builder.Services.AddTransient<IUserService, UserService>();



// Configures
builder.Services.ConfigureJwtAuthorize(builder.Configuration);
builder.Services.ConfigurationSwaggerAuthorize(builder.Configuration);

// Validators
builder.Services.AddScoped<IValidator<Category>, CategoryValidator>();
builder.Services.AddScoped<IValidator<Comment>, CommentValidator>();
builder.Services.AddScoped<IValidator<Post>, PostValidator>();
builder.Services.AddScoped<IValidator<User>, UserValidator>();



var app = builder.Build();



// Configure the HTTP request pipeline.
// Middlewares
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionHandleMiddleware>();

app.Run();
