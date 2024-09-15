using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MillionRealStateCompany.Application.Mappers;
using MillionRealStateCompany.Web.Extensions;
using MillionRealStateCompany.Web.Middlewares;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(DomainToResponseMapper));
builder.Services.AddConfiguratorGeneral(builder.Configuration);
builder.Services.AddInfrastructor();
builder.Services.AddServices();
builder.Services.AddUnitWork();
builder.Services.AddDataBaseDefault(builder.Configuration.GetConnectionString("MillionRealStateCompanyBd"));
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Million Real State Company",
        Description = "",
        Contact = new OpenApiContact () { Name = "test", Email = "test@test.com" }
    });
    

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});

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
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddExceptionHandler<GenericExceptionHandle>();
builder.Services.AddProblemDetails();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => 
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

if(!Directory.Exists(Path.Combine(builder.Environment.ContentRootPath, "fileProperties"))) 
{
    Directory.CreateDirectory(Path.Combine(builder.Environment.ContentRootPath, "fileProperties"));
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "fileProperties")),
    RequestPath = "/Resources"
});
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) 
    .AllowCredentials());
app.UseExceptionHandler();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseStatusCodePages();

app.MapControllers();

app.Run();