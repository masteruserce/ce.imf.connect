using ce.imf.connect;
using ce.imf.connect.application.Service.Abstraction;
using ce.imf.connect.application.Service.Catalog;
using ce.imf.connect.infra;
using ce.imf.connect.infra.Repository.Abstraction;
using ce.imf.connect.infra.Repository.Catalog;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
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

// Configure JWT Bearer authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false, // Not validating issuer for simplicity
            ValidateAudience = false, // Not validating audience for simplicity
            ValidateLifetime = true, // Validate token expiry
            ValidateIssuerSigningKey = true, // Ensure key is valid
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super-secret-key"))
        };
    });
builder.Services.AddScoped<ISourcingDetailsRepository, SourcingDetailsRepository>();
builder.Services.AddScoped<ISourcingDetailsService, SourcingDetailsService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddAuthorization(); // Add default authorization services
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
