using BL;
using DAL;
using Flights;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

DBActions db = new DBActions(builder.Configuration);
string connStr = db.GetConnectionString("SiteDB");
builder.Services.AddScoped<BLManager>(x => new BLManager(connStr));


var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();
builder.Services.AddCors(options =>
{
    var frontend_url = configuration.GetValue<string>("frontend_url");
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontend_url).AllowAnyMethod().AllowAnyHeader();
    });
});
var app = builder.Build();
app.UseHttpsRedirection();
app.UseCors();
app.MapControllers();
app.Run();

