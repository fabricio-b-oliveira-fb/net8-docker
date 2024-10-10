using Knights.Challenge.API.Configuration;
using Knights.Challenge.Repository.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ServicesRegister(builder.Configuration);
builder.Services.AddAutoMapper(builder.Configuration);

builder.Services.Configure<KnightsChallengeDataBaseSettings>(
builder.Configuration.GetSection("KnightsChallengeDataBase"));
builder.Services.AddSingleton<MongoContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
