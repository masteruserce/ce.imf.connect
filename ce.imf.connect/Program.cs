using ce.imf.connect;
using ce.imf.connect.application.Service.Abstraction;
using ce.imf.connect.application.Service.Catalog;
using ce.imf.connect.common.Helpers;
using ce.imf.connect.infra;
using ce.imf.connect.infra.Repository.Abstraction;
using ce.imf.connect.infra.Repository.Catalog;
using ce.imf.connect.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "OCR API", Version = "v1" });

    // 👇 Add this line to support file upload
    c.OperationFilter<FileUploadOperation>();
});

// Configure SQL DB for use with Entity Framework
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("crmApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});


builder.Services.AddScoped<IFormRepository, FormRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IFormDataValueRepository, FormDataValueRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPostalCodeRepository, PostCodeRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
//builder.Services.AddScoped<IGenericRepository<AutoInsuranceFormDataValues>, IGenericRepository<AutoInsuranceFormDataValues>>();
//builder.Services.AddScoped<IGenericRepository<LifeInsuranceFormDataValues>, IGenericRepository<LifeInsuranceFormDataValues>>();
//builder.Services.AddScoped<IGenericRepository<CropInsuranceFormDataValues>, IGenericRepository<CropInsuranceFormDataValues>>();
//builder.Services.AddScoped<IGenericRepository<CommercialInsuranceFormDataValues>, IGenericRepository<CommercialInsuranceFormDataValues>>();
//builder.Services.AddScoped<IGenericRepository<TravelInsuranceFormDataValues>, IGenericRepository<TravelInsuranceFormDataValues>>();
//builder.Services.AddScoped<IGenericRepository<PropertyInsuranceFormDataValues>, IGenericRepository<PropertyInsuranceFormDataValues>>();
//builder.Services.AddScoped<IGenericRepository<HealthInsuranceFormDataValues>, IGenericRepository<HealthInsuranceFormDataValues>>();
//builder.Services.AddScoped<IGenericRepository<MarineInsuranceFormDataValues>, IGenericRepository<MarineInsuranceFormDataValues>>();

builder.Services.AddScoped<IFormService, FormService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IFormDataValueService, FormDataValueService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPostalCodeService, PostalCodeService>();

builder.Services.AddAuthorization(); // Add default authorization services
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<JwtHelper>();

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "ce.imf.connect",
            ValidAudience = "ce.imf.connect.users",
            IssuerSigningKeyResolver = (token, securityToken, kid, validationParameters) =>
            {
                // Extract clientId claim from token
                var jwt = new JwtSecurityToken(token);
                var clientId = jwt.Claims.FirstOrDefault(c => c.Type == "clientId")?.Value;

                if (string.IsNullOrEmpty(clientId))
                    return Enumerable.Empty<SecurityKey>();

                using var scope = builder.Services.BuildServiceProvider().CreateScope();
                var repo = scope.ServiceProvider.GetRequiredService<IClientRepository>();

                // 🔑 Sync call using GetAwaiter().GetResult()
                var client = repo.GetByIdAsync(Guid.Parse(clientId)).GetAwaiter().GetResult();

                if (client == null) return Enumerable.Empty<SecurityKey>();

                var secretKey = client.UserPassword + "ce.imf.connect.users";
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

                return new[] { key };
            }
        };
    });



builder.Services.AddAuthorization();
var app = builder.Build();

// Enable Swagger UI only in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Redirect HTTP to HTTPS
app.UseAuthentication();  // Apply authentication middleware
app.UseAuthorization();   // Apply authorization middleware
app.MapControllers();     // Map controller routes
app.UseCors("crmApp");
app.Run();
