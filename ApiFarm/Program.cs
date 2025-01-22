using FarmAPI;
using FarmAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
DotNetEnv.Env.Load();
string? domain = Environment.GetEnvironmentVariable("API_URL")
      ?? throw new Exception("API_URL environment variable is not set");

builder.WebHost.UseUrls(domain);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

var task = app.RunAsync();

//rodando os testes (pode tirar isso)
await ApiTester.RunTests();

//rodar o servidor depois dos teste
await task;
