using GameStore.Application;
using GameStore.Persistence;
using GameStore.WebApi;
using GameStore.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddValidators();

builder.Services.AddSingleton<GameStoreExceptionMiddleware>();

var app = builder.Build();

app.UseExceptionHandler(applicationBuilder =>
{
    applicationBuilder.UseMiddleware<GameStoreExceptionMiddleware>();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();

app.Run();
