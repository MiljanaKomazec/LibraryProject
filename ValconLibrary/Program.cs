using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using ValconLibrary.Authentication;
using ValconLibrary.Data;
using ValconLibrary.Data.Repository.Authors;
using ValconLibrary.Data.Repository.BookRents;
using ValconLibrary.Data.Repository.Books;
using ValconLibrary.Data.Repository.Users;
using ValconLibrary.DTO.BookRents;
using ValconLibrary.DTO.Books;
using ValconLibrary.EmailService;
using ValconLibrary.Entities;
using ValconLibrary.Middleware;
using ValconLibrary.Service.Authors;
using ValconLibrary.Service.BookRents;
using ValconLibrary.Service.Books;
using ValconLibrary.Service.Users;
using ValconLibrary.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddDbContext<LibraryContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryDB"))
       .LogTo(Console.WriteLine, LogLevel.Information);
});

var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = configuration["Jwt:Issuer"],
            ValidAudience = configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true
        };
    });
builder.Services.Configure<SmtpSettings>(configuration.GetSection("SmtpSettings"));
builder.Services.AddTransient<IEmailService, EmailService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthenticationHelper, AuthenticationHelper>();
builder.Services.AddScoped<IValidator<User>, UserValidator>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IValidator<Author>, AuthorValidator>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IValidator<BookCreateDTO>, BookCreateValidator>();
builder.Services.AddScoped<IBookRentRepository, BookRentRepository>();
builder.Services.AddScoped<IBookRentService, BookRentService>();
builder.Services.AddScoped<IValidator<BookRentDTO>, BookRentValidator>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
