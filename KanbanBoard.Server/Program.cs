using KanbanBoard.DataAccess;
using KanbanBoard.DataAccess.Seeds;
using KanbanBoard.Entities;
using KanbanBoard.Repository;
using KanbanBoard.Repository.Interface;
using KanbanBoard.Service;
using KanbanBoard.Service.Interface;
using KanbanBoard.Service.Profiles;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<AppConfig>(builder.Configuration);

// DATABASE
builder.Services.AddDbContext<KanbanBoardDbContext>(options =>
{
    var connectionString = Environment.GetEnvironmentVariable("Kanban_ConnectionString") ?? builder.Configuration.GetConnectionString("db");
    options.UseSqlServer(connectionString);
});

//// ASP.NET IDENTITY
builder.Services.AddIdentity<KanbanBoardLoginIdentity, IdentityRole>(o =>
{
    o.Password.RequireDigit = true;
    o.Password.RequireLowercase = true;
    o.Password.RequireUppercase = true;
    o.Password.RequireNonAlphanumeric = true;
    o.Password.RequiredLength = 6;

    o.User.RequireUniqueEmail = true;

    o.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    o.Lockout.MaxFailedAccessAttempts = 3;
    o.Lockout.AllowedForNewUsers = true;
}).AddEntityFrameworkStores<KanbanBoardDbContext>()
.AddDefaultTokenProviders();

// REPOSITORY
builder.Services.AddTransient<ICardRepository, CardRepository>();
builder.Services.AddTransient<IPriorityRepository, PriorityRepository>();
builder.Services.AddTransient<IProjectRepository, ProjectRepository>();
builder.Services.AddTransient<IStageRepository, StageRepository>();
builder.Services.AddTransient<ITeamRepository, TeamRepository>();
builder.Services.AddTransient<ITemplateRepository, TemplateRepository>();


// MAPPER
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<CardProfile>();
    config.AddProfile<PriorityProfile>();
    config.AddProfile<ProjectProfile>();
    config.AddProfile<StageProfile>();
    config.AddProfile<TeamProfile>();
    config.AddProfile<TemplateProfile>();
});

// SERVICE
builder.Services.AddTransient<ICardService, CardService>();
builder.Services.AddTransient<IPriorityService, PriorityService>();
builder.Services.AddTransient<IProjectService, ProjectService>();
builder.Services.AddTransient<IStageService, StageService>();
builder.Services.AddTransient<ITeamService, TeamService>();
builder.Services.AddTransient<ITemplateService, TemplateService>();
builder.Services.AddTransient<ILoginService, LoginService>();

// AUTHENTICATION
builder.Services
    .AddAuthentication(config =>
    {
        config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(config =>
    {
        var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]!);
        config.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    await LoginSeed.Seed(scope.ServiceProvider);
}

app.Run();
