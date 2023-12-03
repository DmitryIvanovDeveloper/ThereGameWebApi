
using Microsoft.Extensions.Primitives;
using ThereGame.Buisness.Communication.Dialogue;
using ThereGame.Buisness.Communication.Libraries.Tenses;
using ThereGame.Buisness.Interactor;

var BDService = new BDService();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/api/levels/{id}/dialogs", () =>
{
    return BDService.GetDialogues();
});

app.Run();