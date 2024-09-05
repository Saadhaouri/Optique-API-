using Core.App.Interfaces;
using Core.App.Interfaces.IServices;
using Core.App.IServices;
using Core.App.Services;
using Core.Application.Interface.IRepositories;
using Core.Application.Services;
using Infra.Repository;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Optique_Domaine.Entities;
using Optique_Infrastructure.Repositories;
using Para.Infrastructure.Repository;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OpDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection") ??
       throw new InvalidOperationException("Connection string is not found ")
  ));

// AUTOMAPPER CONFIGURATION 
builder.Services.AddAutoMapper(typeof(Program));

//  Identity 
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<OpDbContext>()
    .AddDefaultTokenProviders();

// Link between interfaces and Class

builder.Services.AddScoped<IProduitRepository, ProduitRepository>();
builder.Services.AddScoped<IFournisseurRepository, FournisseurRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAchatRepository, AchatRepository>();
builder.Services.AddScoped<IFactureRepository, FactureRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IVenteService, VenteService>();
builder.Services.AddScoped<IVenteRepository, VenteRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IProduitService, ProduitService>();
builder.Services.AddScoped<IFournisseurService, FournisseurService>();
builder.Services.AddScoped<IAchatService, AchatService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IVisiteRepository, VisiteRepository>();
builder.Services.AddScoped<IVisiteService, VisiteService>();
builder.Services.AddScoped<IFactureService, FactureService>();
//builder.Services.AddScoped<IVenteRepository, VenteRepository>();
//builder.Services.AddScoped<IVenteService, VenteService>();


builder.Services.AddControllers();

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", builder =>
    {
        builder.WithOrigins("http://localhost:5173")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("AllowLocalhost");
app.MapControllers();

app.Run();
