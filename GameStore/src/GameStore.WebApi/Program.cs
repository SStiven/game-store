using GameStore.Application;
using GameStore.Infrastructure.DateTimeServices;
using GameStore.Persistence;
using GameStore.WebApi;
using GameStore.WebApi.Extensions;
using GameStore.WebApi.Middleware;
using GameStore.WebApi.ModelBinders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddValidators();

builder.Services.AddSingleton<GameStoreExceptionMiddleware>();

builder.Services.UseCustomCors();

builder.Services.AddControllers(options =>
{
    options.ModelBinderProviders.Insert(0, new PaymentRequestModelBinderProvider());
});

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<RequestLoggingMiddleware>();

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
app.UseCors("AllowAllOriginsMethodsHeaders");
app.UseTotalGamesHeader();

app.Run();
