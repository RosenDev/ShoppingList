using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using ShoppingList;
using ShoppingList.ActionFilters;
using ShoppingList.Configuration;
using ShoppingList.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAppServices(builder.Configuration);
builder.Services.AddControllers(options =>
{
    options.Filters.Add<HttpResponseExceptionFilter>();
});
builder.Services.AddDateOnlyTimeOnlyStringConverters();
builder.Services.AddCors(x => x.AddDefaultPolicy(opts =>
{
    var corsSettings = builder.Configuration.GetSection("CorsSettings").Get<CorsSettings>();
    opts.AllowAnyMethod();
    opts.AllowAnyHeader();
    opts.SetIsOriginAllowedToAllowWildcardSubdomains();
    opts.WithOrigins(corsSettings.FrontEndUrl);
}));

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using var scope = app.Services.CreateScope();

var dbContext = scope.ServiceProvider.GetRequiredService<ShoppingListDbContext>();

var pendingMigrations = await dbContext.Database.GetPendingMigrationsAsync();

if(pendingMigrations.Count() > 0)
{
    await dbContext.Database.MigrateAsync();
}

app.UseAuthentication();

app.UseAuthorization();

app.UseCors();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
