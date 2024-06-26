using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using MookApi.Context;
using MookApi.Controllers;
using MookApi.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "mook.Api.1.0.0", Version = "v1" });
});

builder.Services.AddTransient<CommentDataService, CommentDataService>();
builder.Services.AddTransient<RequestDataService, RequestDataService>();
builder.Services.AddTransient<StudentDataService, StudentDataService>();
builder.Services.AddTransient<BookDataService, BookDataService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy",
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
});



builder.Services.AddDbContext<AppDbContext>(opt=>
 opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

app.UseCors("MyPolicy");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSwaggerUI(c => c.DefaultModelExpandDepth(-2));
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "tenet.Api.1.0.0 v1"));
}
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
