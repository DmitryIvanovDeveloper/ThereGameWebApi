var builder = WebApplication.CreateBuilder(args);

builder.Services.AddThereGame(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseThereGame();
app.UseThereGameAuth();
app.UseCors("corspolicy");

app.Run();


