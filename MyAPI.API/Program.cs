using System.Text;
using System.Text.Json.Serialization;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using MyAPI.EShopApp;
using MyAPI.EShopApp.Services;
using MyAPI.ForumApp;
using MyAPI.ForumApp.Services;
using MyAPI.Services;
using IStartup = MyAPI.Services.Startup.IStartup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options => { options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; });
builder.Services.AddAuthorization();
builder.Services.AddHttpsRedirection(opt => opt.HttpsPort = 443);
builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    //options.Audience = "http://localhost:4200";
    //options.Authority = "http://localhost:5010";
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateLifetime = true,
        ValidateAudience = false,
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["URL"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["secretkey"]))
    };
});

builder.Services.AddServices();
builder.Services.AddEShopServices();
builder.Services.AddForumAppServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(type => type.ToString());
});
/*
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: "CorsPolicy", policyBuilder =>
    {
        policyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});
*/

var app = builder.Build();
var startupservice = app.Services.CreateScope().ServiceProvider.GetRequiredService<IStartup>();
var forumAppStartup = app.Services.CreateScope().ServiceProvider.GetRequiredService<ForumAppStartup>();
var eshopAppStartup = app.Services.CreateScope().ServiceProvider.GetRequiredService<EShopAppStartup>();
startupservice.ExecuteServices();
forumAppStartup.ExecuteServices();
eshopAppStartup.ExecuteServices();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(corsPolicyBuilder => corsPolicyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
if (app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}
app.UseStaticFiles(new StaticFileOptions {
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "Storage")),
    RequestPath = "/storage"
});
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run(builder.Configuration["URL"]);


