using System.Text;
using System.Text.Json.Serialization;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using MyAPI.Data;
using MyAPI.ForumApp.Data;
using MyAPI.Services.AutoMapper;
using MyAPI.Services.JWT;
using MyAPI.Services.PasswordHash;
using MyAPI.Services.Startup;
using IStartup = MyAPI.Services.Startup.IStartup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options => { options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; });
//builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateLifetime = true,
        ValidateAudience = false,
        ValidIssuer = "",
        ValidateIssuer = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["secretkey"]))
    };
});
builder.Services.AddDbContext<DataContext>();
builder.Services.AddDbContext<ForumAppDbContext>();
builder.Services.AddAutoMapper(typeof(AutoProfile));
builder.Services.AddAutoMapper(typeof(ForumAppProfile));
builder.Services.AddScoped<IStartup,Startup>();
builder.Services.AddScoped<IStorageStartup,StorageStartup>();
builder.Services.AddScoped<IPasswordHash, PasswordHash>();
builder.Services.AddScoped<IJWT, JWT>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: "CorsPolicy", policyBuilder =>
    {
        policyBuilder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
    });
});

var app = builder.Build();

var servicescope = app.Services.CreateScope();
var services = servicescope.ServiceProvider;
var startupservice = services.GetRequiredService<IStartup>();
startupservice.ExecuteServices();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "Storage")),
    RequestPath = "/storage"
});
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
