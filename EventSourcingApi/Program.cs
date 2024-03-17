using EventSourcing.Application.Services;
using EventSourcing.Domain.Entities;
using EventSourcing.Persistance;
using EventSourcing.Persistance.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistance();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(EventSourcing.Application.RegisterMediatR).Assembly));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IRoomRepository, RoomRepository>();
builder.Services.AddTransient<IReseravtionService, ReservationService>();


builder.Services.AddDbContext<BookingDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// konfiguracja dla dbContext
builder.Services.AddIdentity<User, Role>()
        .AddEntityFrameworkStores<BookingDbContext>()
        .AddDefaultTokenProviders();



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]))
        };
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(policy => policy.WithOrigins("http://localhost:3000")
        .WithMethods("GET", "POST", "PUT", "DELETE", "OPTIONS")
        .AllowAnyHeader()
        .AllowCredentials());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();
