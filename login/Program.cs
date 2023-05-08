using Microsoft.EntityFrameworkCore;
using Repository;
using Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IUsersRepository, UsersRepository>();
builder.Services.AddTransient<IUsersService, UsersService>();
builder.Services.AddTransient<IPasswordService, PasswordService>();

builder.Services.AddControllers();





builder.Services.AddDbContext<MakeUpContext>(options => options.UseSqlServer("Data Source=srv2\\PUPILS;Integrated Security=True"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
