using EventSourcing.Application.Services;
using EventSourcing.Domain.Entities;
using EventSourcing.Persistance;
using EventSourcing.Persistance.Repositories;
using EventSourcingApi;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistance();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(EventSourcing.Application.RegisterMediatR).Assembly));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IRoomRepository, RoomRepository>();
builder.Services.AddTransient<IReseravtionService, ReservationService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUserContext, UserConterxt>();
builder.Services.AddScoped<IOpinionRepository, OpinionRepository>();


var jwtOptions = builder.Configuration.GetSection("JwtOptions").Get<JwtOptions>() ?? throw new InvalidOperationException("JwtOptions section is missing in configuration.");

builder.Services.AddSingleton(jwtOptions);




builder.Services.AddDbContext<BookingDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<User, Role>()
        .AddEntityFrameworkStores<BookingDbContext>()
        .AddDefaultTokenProviders();





builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = "Bearer";
    option.DefaultScheme = "Bearer";
    option.DefaultChallengeScheme = "Bearer";
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false; //
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = jwtOptions.Issuer,
        ValidAudience = jwtOptions.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SigningKey)),
    };
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(policy => policy.WithOrigins("http://localhost:4200")
        .WithMethods("GET", "POST", "PUT", "DELETE", "OPTIONS")
        .AllowAnyHeader()
        .AllowCredentials());

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();



app.Run();
